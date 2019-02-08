using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiObjects.PageObjects.Flux;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.FluxTests.Flux
{
    /// <summary>
    /// This test class contains Flux specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public sealed class TcFluxTest : TcBaseTestClass
    {
        private string mTestMachineName;

        private readonly TimeSpan mConfigureMachineOverlay = TimeSpan.FromSeconds( 20 );

        /// <summary>
        /// Creates a new part with bend solution, opens it and closes Flux.
        /// </summary>
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319A" )]
        [Tag( "Flux" )]
        public void FluxOpenCloseTest()
        {
            ExecuteUITest( DoFluxOpenClose, "Flux Open and Close Test" );
        }

        /// <summary>
        /// Creates a new part with bend solution, opens it, saves and closes Flux.
        /// </summary>
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319C" )]
        [Tag( "Flux" )]
        public void FluxSaveAndCloseTest()
        {
            ExecuteUITest( DoFluxSaveAndCloseTest, "Flux Save and Close Test" );
        }

        /// <summary>
        /// Boost part with Flux
        /// </summary>
        [ TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319D" )]
        [Tag( "Flux" )]
        public void BoostPartSucessTest()
        {
            ExecuteUITest( DoBoostPartSucessTest, "Flux Boost Part Test" );
        }

        /// <summary>
        /// Boosts a part with error (missing clampings)
        /// </summary>
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319E" )]
        [Tag( "Flux" )]
        public void BoostSolutionWithErrorTest()
        {
            ExecuteUITest( DoBoostSolutionWithErrorTest, "Boost Solution with Errors");
        }

        /// <summary>
        /// checks if part can be released
        /// </summary>
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319F" )]
        [Tag( "Flux" )]
        public void ReleaseBoostedPart()
        {
            ExecuteUITest(DoReleaseBoostedPart, "Release Boosted Part");
        }

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
        /// Closes a changed part without saving
        /// </summary>
        [ TestMethod, UniqueName( "511d5620-52c1-4735-9fc4-370a62552eca" )]
        [Tag( "Flux" )]
        public void CloseWithoutSave()
        {
            ExecuteUITest( DoCloseWithoutSave, "Close Flux without Saving" );
        }

        /// <summary>
        /// Implementation of the Flux open and close test
        /// </summary>
        private void DoFluxOpenClose()
        {
            CreateTestMachine();

            var namePrefix = TestSettings.NamePrefix + Guid.NewGuid();
            var parts = HomeZone.GotoParts();

            // first part
            parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            parts.SingleDetail.Name.Value = namePrefix + "1";

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.OpenBendSolution( "Bend1" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );

            var flux = FluxApp;

            var visible = flux.IsMainWindowVisible( TestSettings.FluxBoostAndStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            if( visible )
            {
                flux.CloseApp();

                parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );
            }

            Assert.IsTrue( visible );

            //second part
            parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            parts.SingleDetail.Name.Value = namePrefix + "2";

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.OpenBendSolution( "Bend1" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );

            flux = FluxApp;

            visible = flux.IsMainWindowVisible( TestSettings.FluxBoostAndStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            if( visible )
            {
                flux.CloseApp();

                parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );
            }

            Assert.IsTrue( visible, "Flux window was not visible." );

            // delete the 2 parts
            parts.ResultColumn.SelectItems( namePrefix );
            parts.Toolbar.Delete();
            parts.ResultColumn.ClearSearch();

            DeleteTestMachine();

        }

        /// <summary>
        /// Implementation of the Flux save and close test
        /// </summary>
        private void DoFluxSaveAndCloseTest()
        {
            CreateTestMachine();

            var parts = HomeZone.GotoParts();
            string solutionName = "Bend1";

            parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.OpenBendSolution( solutionName );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );

            var flux = FluxApp;
            bool visible = flux.IsMainWindowVisible( TestSettings.FluxBoostAndStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            if( visible )
            {
                flux.SaveAndClosePartInFlux();
                parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );
            }

            var isManual = parts.SingleDetailBendSolutions.IsManuallyChanged( solutionName );
            Assert.IsTrue( isManual );

            parts.Toolbar.Delete();
            DeleteTestMachine();
        }

        /// <summary>
        /// Implementation of the Boost part success test
        /// </summary>
        private void DoBoostPartSucessTest()
        {
            CreateTestMachine();
            var parts = HomeZone.GotoParts();
            string solutionName = "Bend1";

            parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.BoostSolution( solutionName );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            parts.SingleDetailBendSolutions.OpenSolutionDetail( solutionName );

            Assert.IsTrue( parts.SingleDetailBendSolutions.NcButtonVisible( solutionName ) );
            Assert.IsTrue( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( solutionName ) );
            Assert.IsFalse( parts.SingleDetailBendSolutions.ReleaseButtonVisible( solutionName ) );

            parts.Toolbar.Delete();
            DeleteTestMachine();
        }

        /// <summary>
        /// Implementation of the Boost solution with error test
        /// </summary>
        private void DoBoostSolutionWithErrorTest()
        {
            string testMachine = "TruBend 3066 (2-axes, Asia) B26";
            CreateTestMachine( testMachine );

            var parts = HomeZone.GotoParts();
            string solutionName = "Bend1";

            parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.BoostSolution( solutionName );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            parts.SingleDetailBendSolutions.OpenSolutionDetail( solutionName );

            Assert.IsFalse( parts.SingleDetailBendSolutions.NcButtonVisible( solutionName ) );
            Assert.IsFalse( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( solutionName ) );
            Assert.IsFalse( parts.SingleDetailBendSolutions.ReleaseButtonVisible( solutionName ) );

            parts.Toolbar.Delete();
            DeleteTestMachine( testMachine );
        }

        /// <summary>
        /// Implemenation of the release boosted part test
        /// </summary>
        private void DoReleaseBoostedPart()
        {
            CreateTestMachine();

            var parts = HomeZone.GotoParts();
            string solutionName = "Bend1";

            parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.BoostSolution( solutionName );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            // freigeben
            parts.SingleDetailBendSolutions.ToggleReleaseButton( solutionName );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            parts.SingleDetailBendSolutions.OpenSolutionDetail( solutionName );

            Assert.IsTrue( parts.SingleDetailBendSolutions.NcButtonVisible( solutionName ) );
            Assert.IsTrue( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( solutionName ) );
            Assert.IsTrue( parts.SingleDetailBendSolutions.ReleaseButtonVisible( solutionName ) );

            // widerrufen
            parts.SingleDetailBendSolutions.ToggleReleaseButton( solutionName );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            Assert.IsTrue( parts.SingleDetailBendSolutions.NcButtonVisible( solutionName ) );
            Assert.IsTrue( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( solutionName ) );
            Assert.IsFalse( parts.SingleDetailBendSolutions.ReleaseButtonVisible( solutionName ) );

            parts.Toolbar.Delete();
            DeleteTestMachine();
        }

        /// <summary>
        /// Implementation of the confugre machine test
        /// </summary>
        private void DoConfigureMachineTest()
        {

            string machineName = "TruBend 5320 (6-axes) B23";
            CreateTestMachine( machineName );

            // open dialog
            OpenMachineConfiguration( machineName );
            Thread.Sleep( mConfigureMachineOverlay );
            TcFluxConfigureMachine flux = new TcFluxConfigureMachine( Driver );
            bool visible = flux.MachineDialogVisible( TestSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            if( visible )
            {
                flux.CloseMachienDialog();
                Thread.Sleep( mConfigureMachineOverlay );
            }

            DeleteTestMachine( machineName );
        }

        /// <summary>
        /// Implementation of the close without save test
        /// </summary>
        private void DoCloseWithoutSave()
        {
            CreateTestMachine();

            var parts = HomeZone.GotoParts();
            string solutionName = "Bend1";

            parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.OpenBendSolution( solutionName );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );

            var flux = FluxApp;
            bool visible = flux.IsMainWindowVisible( TestSettings.FluxBoostAndStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            if( visible )
            {
                flux.ChangeSolution();
                parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );
            }
            parts.Toolbar.Delete();
            DeleteTestMachine();
        }

        /// <summary>
        /// create a test machine
        /// </summary>
        /// <param name="machineName">machine name</param>
        private void CreateTestMachine( string machineName = null )
        {
            mTestMachineName = TestSettings.NamePrefix + Guid.NewGuid();

            var machines = HomeZone.GotoMachines();

            if( machineName == null )
            {
                machines.NewBendMachine( "TruBend 5320 (6-axes) B23", mTestMachineName );
            }
            else
            {
                machines.NewBendMachine( machineName, machineName );
            }

            Assert.IsTrue( machines.Toolbar.CanSave );
            machines.Toolbar.Save();
            Assert.IsFalse( machines.Toolbar.CanSave );

            machines.WaitForDetailOverlayAppear( TestSettings.MachineOverlayAppearTimeout );
            machines.WaitForDetailOverlayDisappear( TestSettings.MachineOverlayDisappearTimeout );
        }

        
        /// <summary>
        /// Delete the test machine
        /// </summary>
        /// <param name="machineName"></param>
        private void DeleteTestMachine( string machineName = null )
        {
            var machines = HomeZone.GotoMachines();

            if( machineName == null )
            {
                machines.ResultColumn.SelectItem( mTestMachineName );
            }
            else
            {
                machines.ResultColumn.SelectItem( machineName );
            }

            Assert.IsTrue( machines.Toolbar.CanDelete );
            machines.Toolbar.Delete();
            machines.ResultColumn.ClearSearch();
            Assert.IsFalse( machines.Toolbar.CanDelete );
        }

        /// <summary>
        /// Open the machine configuration
        /// </summary>
        /// <param name="machineName"></param>
        private void OpenMachineConfiguration( string machineName )
        {
            var machines = HomeZone.GotoMachines();
            machines.ResultColumn.SelectItem( machineName );
            machines.Detail.OpenMachineConfigurationBend();
        }
    }
}
