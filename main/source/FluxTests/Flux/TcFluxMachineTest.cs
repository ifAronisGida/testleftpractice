using HomeZone.UiCommonFunctions;
using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiObjectInterfaces.Machine;
using HomeZone.UiObjects.PageObjects.Flux;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.FluxTests.Flux
{
    /// <summary>
    /// This test class contains Flux machine specific tests.
    /// </summary>
    [TestClass]
    public sealed class TcFluxMachineTest : TcBaseTestClass
    {
        /// <summary>
        /// machine helper
        /// </summary>
        private TcMachinePageObjectHelper mMachineHelper = new TcMachinePageObjectHelper();

        /// <summary>
        /// timeout to open the configure machine dialog. TODO: has to be refactored to a dynamic timout
        /// </summary>
        private readonly TimeSpan mConfigureMachineOverlay = TimeSpan.FromSeconds( 20 );

        /// <summary>
        /// Opens/Closes configure machine dialog
        /// </summary>
        [TestMethod, UniqueName( "511d5620-52c1-4735-9fc4-370a62552eca" )]
        [Tag( "Flux" )]
        public void ConfigureMachineTest()
        {
            ExecuteUITest( DoConfigureMachineTest, "Configure Machine" );
        }

        /// <summary>
        /// Create Flux bend workplaces for all available machine templates
        /// </summary>
        [TestMethod, UniqueName( "60D92E29-A475-4A80-8F06-F5158611223E" )]
        [Tag( "Flux" )]
        public void CreateWorkplacesForAllBendMachines()
        {
            ExecuteUITest( DoCreateWorkplacesForAllBendMachines, "Create Bend Workplaces For All Bend Machines" );
        }

        /// <summary>
        /// Implementation of the confugre machine test
        /// </summary>
        private void DoConfigureMachineTest()
        {

            string machineName = "TruBend 5320 (6-axes) B23";
            mMachineHelper.CreateAndSaveBendMachine( TestSettings, HomeZone.Machines, machineName );

            // open dialog
            var machines = HomeZone.GotoMachines();
            machines.ResultColumn.SelectItem( machineName );
            machines.Detail.OpenMachineConfigurationBend();

            Thread.Sleep( mConfigureMachineOverlay ); //TODO: can be refactored so that Window is captured as soon as it appears -> no Sleep required
            TcFluxConfigureMachine flux = new TcFluxConfigureMachine( Driver );
            bool visible = flux.MachineDialogVisible( TestSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            flux.CloseMachienDialog();
            Thread.Sleep( mConfigureMachineOverlay );

            mMachineHelper.DeleteCreatedMachines( HomeZone.Machines );
        }

        /// <summary>
        /// Implementation of the create workplaces for all bend machines test
        /// </summary>
        private void DoCreateWorkplacesForAllBendMachines()
        {
            TiMachines machines = HomeZone.GotoMachines();
            foreach( var machineName in machines.Detail.GetAvailableBendMachineTemplates() )
            {
                mMachineHelper.CreateAndSaveBendMachine( TestSettings, machines, machineName );
                Assert.IsTrue( machines.Detail.IsPreviewImageAvailable(), "No preview image is available for this machine template" );
            }
            mMachineHelper.DeleteCreatedMachines( machines );
        }
    }
}
