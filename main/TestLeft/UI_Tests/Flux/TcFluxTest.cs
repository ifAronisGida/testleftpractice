using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Flux;
using TestLeft.TestLeftBase.PageObjects.Machine;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;
using Trumpf.AutoTest.Utilities;

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

        /// <summary>
        /// Gets the extended test environment.
        /// Creates / deletes the test machine used by the test methods
        /// </summary>
        public override IDoSequence TestEnvironment => base.TestEnvironment
            .Do( CreateTestMachine, DeleteTestMachine, "TestMachine" );

        /// <summary>
        /// Creates a new part with bend solution, opens it and closes Flux.
        /// </summary>
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319A" )]
        public void FluxOpenCloseTest()
        {
            Act( () =>
            {
                var namePrefix = TcSettings.NamePrefix + Guid.NewGuid();
                var parts = HomeZoneApp.Goto<TcParts>();

                // first part
                parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                parts.SingleDetail.Name = namePrefix + "1";

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

                parts.SingleDetail.Name = namePrefix + "2";

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
            } );
        }

        private void CreateTestMachine()
        {
            mTestMachineName = TcSettings.NamePrefix + Guid.NewGuid();

            var machines = HomeZoneApp.Goto<TcMachines>();

            machines.VisibleOnScreen.WaitFor();

            machines.NewBendMachine( "TruBend 5320 (6-axes) B23", mTestMachineName );

            Assert.IsTrue( machines.Toolbar.SaveButton.Enabled );
            machines.SaveMachine();
            Assert.IsFalse( machines.Toolbar.SaveButton.Enabled );

            machines.WaitForDetailOverlayAppear( TcSettings.MachineOverlayAppearTimeout );
            machines.WaitForDetailOverlayDisappear( TcSettings.MachineOverlayDisappearTimeout );
        }

        private void DeleteTestMachine()
        {
            var machines = HomeZoneApp.Goto<TcMachines>();

            machines.VisibleOnScreen.WaitFor();
            machines.ResultColumn.SelectItem( mTestMachineName );

            Assert.IsTrue( machines.Toolbar.DeleteButton.Enabled );
            machines.DeleteMachine();
            Assert.IsFalse( machines.Toolbar.DeleteButton.Enabled );
        }
    }
}
