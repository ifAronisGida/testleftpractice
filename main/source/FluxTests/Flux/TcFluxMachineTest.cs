using HomeZone.UiObjectInterfaces.Machine;
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
    public sealed class TcFluxMachineTest : TcBaseTestClassFlux
    {
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

            string machineType = "TruBend 5320 (6-axes) B23";
            mMachineHelper.CreateAndSaveBendMachine( TestSettings, HomeZone.Machines, machineType );

            HomeZone.Machines.Detail.OpenMachineConfigurationBend();
            Flux.MachineConfigurationDialogExists.WaitFor( TestSettings.FluxStartTimeout );
            Flux.MachineConfigurationDialog.Close();

            Thread.Sleep( mConfigureMachineOverlay ); //TODO: can be refactored with a dynamic timeout
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
        }
    }
}
