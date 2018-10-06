using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjectInterfaces.Machine;
using PageObjectInterfaces.Part;
using TestLeft.TestLeftBase.PageObjects.Flux;
using TestLeft.TestLeftBase.PageObjects.Machine;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Flux
{
    /// <summary>
    /// This test class contains Flux specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcFluxTest : TcBaseTestClass
    {
        private string mTestMachineName;

        private readonly TimeSpan CONFIGURE_MACHINE_OVERLAY = TimeSpan.FromSeconds( 20 );

        ///// <summary>
        ///// Gets the extended test environment.
        ///// Creates / deletes the test machine used by the test methods
        ///// </summary>
        //public override IDoSequence TestEnvironment => base.TestEnvironment
        //.Do( CreateTestMachine, DeleteTestMachine, "TestMachine" );

        /// <summary>
        /// Creates a new part with bend solution, opens it and closes Flux.
        /// </summary>
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319A" )]
        public void FluxOpenCloseTest()
        {
            Act( () =>
            {
                CreateTestMachine();

                var namePrefix = TcSettings.NamePrefix + Guid.NewGuid();
                var parts = HomeZoneApp.Goto<TiParts, TcParts>();

                // first part
                parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                parts.SingleDetail.Name.Value = namePrefix + "1";

                parts.SingleDetailBendSolutions.New();
                parts.SingleDetailBendSolutions.OpenBendSolution( "Bend1" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );

                var flux = new TcFlux( Driver );

                var visible = flux.MainWindowVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                if( visible )
                {
                    flux.CloseApp();

                    parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
                }

                Assert.IsTrue( visible );

                //second part
                parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                parts.SingleDetail.Name.Value = namePrefix + "2";

                parts.SingleDetailBendSolutions.New();
                parts.SingleDetailBendSolutions.OpenBendSolution( "Bend1" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );

                flux = new TcFlux( Driver );

                visible = flux.MainWindowVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                if( visible )
                {
                    flux.CloseApp();

                    parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
                }

                Assert.IsTrue( visible, "Flux window was not visible." );

                // delete the 2 parts
                parts.ResultColumn.SelectItems( namePrefix );
                parts.DeletePart();

                DeleteTestMachine();
            } );
        }

        /// <summary>
        /// Creates a new part with bend solution, opens it, saves and closes Flux.
        /// </summary>
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319C" )]
        public void FluxSaveAndCloseTest()
        {
            Act( () =>
            {
                CreateTestMachine();

                Trace.WriteLine( @"Starting Flux open / close test." );
                var parts = HomeZoneApp.Goto<TiParts, TcParts>();
                string solutionName = "Bend1";

                parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                parts.SingleDetailBendSolutions.New();
                parts.SingleDetailBendSolutions.OpenBendSolution( solutionName );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );

                var flux = new TcFlux( Driver );
                bool visible = flux.MainWindowVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                if( visible )
                {
                    flux.SaveAndClosePartInFlux();
                    parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
                }

                // TODO: manuelle änderung detektieren
                var isManual = parts.SingleDetailBendSolutions.IsManuallyChanged( solutionName );
                Assert.IsTrue( isManual );

                parts.DeletePart();
                DeleteTestMachine();
            } );
        }

        /// <summary>
        /// Boost part with Flux
        /// </summary>
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319D" )]
        public void BoostPartSucessTest()
        {
            Act( () =>
             {
                 CreateTestMachine();
                 Trace.WriteLine( @"Starting Flux boost test." );
                 var parts = HomeZoneApp.Goto<TiParts, TcParts>();
                 string solutionName = "Bend1";

                 parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                 parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                 parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                 parts.SingleDetailBendSolutions.New();
                 parts.SingleDetailBendSolutions.BoostSolution( solutionName );
                 parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                 parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                 parts.SingleDetailBendSolutions.OpenSolutionDetail( solutionName );

                 Assert.IsTrue( parts.SingleDetailBendSolutions.NcButtonVisible( solutionName ) );
                 Assert.IsTrue( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( solutionName ) );
                 Assert.IsFalse( parts.SingleDetailBendSolutions.ReleaseButtonVisible( solutionName ) );

                 parts.DeletePart();
                 DeleteTestMachine();
             } );
        }

        /// <summary>
        /// Boosts a part with error (missing clampings)
        /// </summary>
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319E" )]
        public void BoostSolutionWithErrorTest()
        {
            Act( () =>
             {
                 string testMachine = "TruBend 3066 (2-axes, Asia) B26";
                 CreateTestMachine( testMachine );

                 Trace.WriteLine( @"Starting Flux boost with errors test." );
                 var parts = HomeZoneApp.Goto<TiParts, TcParts>();
                 string solutionName = "Bend1";

                 parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                 parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                 parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                 parts.SingleDetailBendSolutions.New();
                 parts.SingleDetailBendSolutions.BoostSolution( solutionName );
                 parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                 parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                 parts.SingleDetailBendSolutions.OpenSolutionDetail( solutionName );

                 Assert.IsFalse( parts.SingleDetailBendSolutions.NcButtonVisible( solutionName ) );
                 Assert.IsFalse( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( solutionName ) );
                 Assert.IsFalse( parts.SingleDetailBendSolutions.ReleaseButtonVisible( solutionName ) );

                 parts.DeletePart();
                 DeleteTestMachine( testMachine );
             } );
        }

        /// <summary>
        /// checks if part can be released
        /// </summary>
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319F" )]
        public void ReleaseBoostedPart()
        {
            Act( () =>
            {
                CreateTestMachine();
                Trace.WriteLine( @"Starting Flux release solution after boost test." );
                var parts = HomeZoneApp.Goto<TiParts, TcParts>();
                string solutionName = "Bend1";

                parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                parts.SingleDetailBendSolutions.New();
                parts.SingleDetailBendSolutions.BoostSolution( solutionName );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                // freigeben
                parts.SingleDetailBendSolutions.ToggleReleaseButton( solutionName );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                parts.SingleDetailBendSolutions.OpenSolutionDetail( solutionName );

                Assert.IsTrue( parts.SingleDetailBendSolutions.NcButtonVisible( solutionName ) );
                Assert.IsTrue( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( solutionName ) );
                Assert.IsTrue( parts.SingleDetailBendSolutions.ReleaseButtonVisible( solutionName ) );

                // widerrufen
                parts.SingleDetailBendSolutions.ToggleReleaseButton( solutionName );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                Assert.IsTrue( parts.SingleDetailBendSolutions.NcButtonVisible( solutionName ) );
                Assert.IsTrue( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( solutionName ) );
                Assert.IsFalse( parts.SingleDetailBendSolutions.ReleaseButtonVisible( solutionName ) );

                parts.DeletePart();
                DeleteTestMachine();
            } );
        }

        /// <summary>
        /// Opens/Closes configure machine dialog
        /// </summary>
        [TestMethod, UniqueName( "511d5620-52c1-4735-9fc4-370a62552eca" )]
        public void ConfigureMachineTest()
        {
            Act( () =>
             {
                 Trace.WriteLine( @"Starting configure machine test." );
                 string machineName = "TruBend 5320 (6-axes) B23";
                 CreateTestMachine( machineName );

                 // open dialog
                 OpenMachineConfiguration( machineName );
                 Thread.Sleep( CONFIGURE_MACHINE_OVERLAY );
                 TcFluxConfigureMachine flux = new TcFluxConfigureMachine( Driver );
                 bool visible = flux.MachineDialogVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                 if( visible )
                 {
                     flux.CloseMachienDialog();
                     Thread.Sleep( CONFIGURE_MACHINE_OVERLAY );
                 }

                 DeleteTestMachine( machineName );
             } );
        }

        /// <summary>
        /// Closes a changed part without saving
        /// </summary>
        [TestMethod, UniqueName( "511d5620-52c1-4735-9fc4-370a62552eca" )]
        public void CloseWithoutSave()
        {
            Act( () =>
             {
                 CreateTestMachine();
                 Trace.WriteLine( @"Starting Flux close without save test." );
                 var parts = HomeZoneApp.Goto<TiParts, TcParts>();
                 string solutionName = "Bend1";

                 parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                 parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                 parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                 parts.SingleDetailBendSolutions.New();
                 parts.SingleDetailBendSolutions.OpenBendSolution( solutionName );
                 parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );

                 var flux = new TcFlux( Driver );
                 bool visible = flux.MainWindowVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                 if( visible )
                 {
                     flux.ChangeSolution();
                     parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
                 }
                 parts.DeletePart();
                 DeleteTestMachine();
             } );
        }











        private void CreateTestMachine( string machineName = null )
        {
            mTestMachineName = TcSettings.NamePrefix + Guid.NewGuid();

            var machines = HomeZoneApp.Goto<TiMachines, TcMachines>();

            if( machineName == null )
            {
                machines.NewBendMachine( "TruBend 5320 (6-axes) B23", mTestMachineName );
            }
            else
            {
                machines.NewBendMachine( machineName, machineName );
            }

            Assert.IsTrue( machines.Toolbar.SaveButton.Enabled );
            machines.SaveMachine();
            Assert.IsFalse( machines.Toolbar.SaveButton.Enabled );

            machines.WaitForDetailOverlayAppear( TcSettings.MachineOverlayAppearTimeout );
            machines.WaitForDetailOverlayDisappear( TcSettings.MachineOverlayDisappearTimeout );
        }

        private void DeleteTestMachine( string machineName = null )
        {
            var machines = HomeZoneApp.Goto<TiMachines, TcMachines>();

            if( machineName == null )
            {
                machines.ResultColumn.SelectItem( mTestMachineName );
            }
            else
            {
                machines.ResultColumn.SelectItem( machineName );
            }

            Assert.IsTrue( machines.Toolbar.DeleteButton.Enabled );
            machines.DeleteMachine();
            Assert.IsFalse( machines.Toolbar.DeleteButton.Enabled );
        }

        private void OpenMachineConfiguration( string machineName )
        {
            var machines = HomeZoneApp.Goto<TiMachines, TcMachines>();
            machines.ResultColumn.SelectItem( machineName );
            machines.Detail.OpenMachineConfigurationBend();
        }
    }
}
