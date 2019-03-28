using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.FluxTests.Flux
{
    /// <summary>
    /// This test class contains Flux specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public sealed class TcFluxTest : TcBaseTestClassFlux
    {
        private const string S_FLUX_MACHINE_5320 = "TruBend 5320 (6-axes) B23";

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
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319D" )]
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
            ExecuteUITest( DoBoostSolutionWithErrorTest, "Boost Solution with Errors" );
        }

        /// <summary>
        /// checks if part can be released
        /// </summary>
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319F" )]
        [Tag( "Flux" )]
        public void ReleaseBoostedPart()
        {
            ExecuteUITest( DoReleaseBoostedPart, "Release Boosted Part" );
        }

        /// <summary>
        /// Closes a changed part without saving
        /// </summary>
        [TestMethod, UniqueName( "511d5620-52c1-4735-9fc4-370a62552eca" )]
        [Tag( "Flux" )]
        public void CloseWithoutSave()
        {
            ExecuteUITest( DoCloseWithoutSave, "Close Flux without Saving" );
        }

        [TestMethod, UniqueName( "B02AAB6B-6B37-471D-9023-8985CE43A0A3" )]
        [Tag( "Flux" )]
        public void BoostAllShowcaseParts()
        {
            ExecuteUITest( DoBoostAllShowcaseParts, "Boost All Showcase Parts" );
        }

        /// <summary>
        /// Implementation of the Flux open and close test
        /// </summary>
        private void DoFluxOpenClose()
        {
            mMachineHelper.CreateAndSaveBendMachine( TestSettings, HomeZone.Machines, S_FLUX_MACHINE_5320 );


            var namePrefix = TestSettings.NamePrefix + Guid.NewGuid();
            var parts = HomeZone.GotoParts();

            // first part
            mPartHelper.ImportPart( TestSettings, parts, @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );
            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.OpenBendSolution( "Bend1" );
            parts.WaitForDetailOverlayAppear();

            var flux = FluxApp;

            var visible = flux.IsMainWindowVisible( TestSettings.FluxBoostAndStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            flux.CloseApp();
            parts.WaitForDetailOverlayDisappear();

            Assert.IsTrue( visible );

            //second part
            mPartHelper.ImportPart( TestSettings, parts, @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.OpenBendSolution( "Bend1" );
            parts.WaitForDetailOverlayAppear();

            visible = flux.IsMainWindowVisible( TestSettings.FluxBoostAndStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            flux.CloseApp();
            parts.WaitForDetailOverlayDisappear();

            Assert.IsTrue( visible, "Flux window was not visible." );
        }

        /// <summary>
        /// Implementation of the Flux save and close test
        /// </summary>
        private void DoFluxSaveAndCloseTest()
        {
            mMachineHelper.CreateAndSaveBendMachine( TestSettings, HomeZone.Machines, S_FLUX_MACHINE_5320 );

            var parts = HomeZone.GotoParts();
            string solutionName = "Bend1";

            mPartHelper.ImportPart( TestSettings, parts, @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.OpenBendSolution( solutionName );
            parts.WaitForDetailOverlayAppear();

            var flux = FluxApp;
            bool visible = flux.IsMainWindowVisible( TestSettings.FluxBoostAndStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            flux.SaveAndClosePartInFlux();
            parts.WaitForDetailOverlayDisappear();

            var isManual = parts.SingleDetailBendSolutions.IsManuallyChanged( solutionName );
            Assert.IsTrue( isManual );
        }

        /// <summary>
        /// Implementation of the Boost part success test
        /// </summary>
        private void DoBoostPartSucessTest()
        {
            mMachineHelper.CreateAndSaveBendMachine( TestSettings, HomeZone.Machines, S_FLUX_MACHINE_5320 );
            var parts = HomeZone.GotoParts();
            string solutionName = "Bend1";

            mPartHelper.ImportPart( TestSettings, parts, @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.BoostSolution( solutionName );
            parts.WaitForDetailOverlayAppear();
            parts.WaitForDetailOverlayDisappear();

            parts.SingleDetailBendSolutions.OpenSolutionDetail( solutionName );

            Assert.IsTrue( parts.SingleDetailBendSolutions.NcButtonVisible( solutionName ), "NC Button is disabled" );
            Assert.IsTrue( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( solutionName ), "Setup Plan Button is disabled" );
            Assert.IsFalse( parts.SingleDetailBendSolutions.ReleaseButtonVisible( solutionName ), "Release Button is disabled" );
        }

        /// <summary>
        /// Implementation of the Boost solution with error test
        /// </summary>
        private void DoBoostSolutionWithErrorTest()
        {
            string testMachine = "TruBend 3066 (2-axes, Asia) B26";
            mMachineHelper.CreateAndSaveBendMachine( TestSettings, HomeZone.Machines, testMachine );

            var parts = HomeZone.GotoParts();
            string solutionName = "Bend1";

            mPartHelper.ImportPart( TestSettings, parts, @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.BoostSolution( solutionName );
            parts.WaitForDetailOverlayAppear();
            parts.WaitForDetailOverlayDisappear();

            parts.SingleDetailBendSolutions.OpenSolutionDetail( solutionName );

            Assert.IsFalse( parts.SingleDetailBendSolutions.NcButtonVisible( solutionName ) );
            Assert.IsFalse( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( solutionName ) );
            Assert.IsFalse( parts.SingleDetailBendSolutions.ReleaseButtonVisible( solutionName ) );
        }

        /// <summary>
        /// Implemenation of the release boosted part test
        /// </summary>
        private void DoReleaseBoostedPart()
        {
            mMachineHelper.CreateAndSaveBendMachine( TestSettings, HomeZone.Machines, S_FLUX_MACHINE_5320 );

            var parts = HomeZone.GotoParts();
            string solutionName = "Bend1";

            mPartHelper.ImportPart( TestSettings, parts, @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.BoostSolution( solutionName );
            parts.WaitForDetailOverlayAppear();
            parts.WaitForDetailOverlayDisappear();

            // freigeben
            parts.SingleDetailBendSolutions.ToggleReleaseButton( solutionName );
            parts.WaitForDetailOverlayAppear();
            parts.WaitForDetailOverlayDisappear();

            parts.SingleDetailBendSolutions.OpenSolutionDetail( solutionName );

            Assert.IsTrue( parts.SingleDetailBendSolutions.NcButtonVisible( solutionName ) );
            Assert.IsTrue( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( solutionName ) );
            Assert.IsTrue( parts.SingleDetailBendSolutions.ReleaseButtonVisible( solutionName ) );

            // widerrufen
            parts.SingleDetailBendSolutions.ToggleUnreleaseButton( solutionName );
            parts.WaitForDetailOverlayAppear();
            parts.WaitForDetailOverlayDisappear();

            Assert.IsTrue( parts.SingleDetailBendSolutions.NcButtonVisible( solutionName ) );
            Assert.IsTrue( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( solutionName ) );
            Assert.IsFalse( parts.SingleDetailBendSolutions.ReleaseButtonVisible( solutionName ) );
        }

        /// <summary>
        /// Implementation of the close without save test
        /// </summary>
        private void DoCloseWithoutSave()
        {
            mMachineHelper.CreateAndSaveBendMachine( TestSettings, HomeZone.Machines, S_FLUX_MACHINE_5320 );

            var parts = HomeZone.GotoParts();
            string solutionName = "Bend1";

            mPartHelper.ImportPart( TestSettings, parts, @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.OpenBendSolution( solutionName );
            parts.WaitForDetailOverlayAppear();

            var flux = FluxApp;
            bool visible = flux.IsMainWindowVisible( TestSettings.FluxBoostAndStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            flux.ChangeSolution();
            parts.WaitForDetailOverlayDisappear();
        }

        /// <summary>
        /// Implementation of the Boost all showcase parts test
        /// </summary>
        private void DoBoostAllShowcaseParts()
        {
            string bendSolutionName = "Bend1";
            string samplesPath = @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase";
            List<string> showcasePartList = new List<string>()
            {
                "Halter_rechts.scdoc",
                "Lochgitter.scdoc",
                "Lueftergehauese.scdoc",
                "Motorhalter.scdoc",
                "Pumpenhalter.scdoc",
                "Rueckwand.scdoc",
                "Traeger.scdoc",
                "Umlenker.scdoc",
                "Wanne.scdoc",
                "Zugwinkel.scdoc",
                "Abdeckblech.scdoc",
                //"Abdeckung_mitExtAttributen.scdoc", //no material assigned automatically -> no boosted design per default
                "Aufnahmegehaeuse.scdoc",
                "Bruecke.scdoc",
                "Demoteil.geo",
                "Distanzblech.scdoc",
                "Eckwinkel.scdoc",
                "Entluefterwinkel.scdoc",
                "Halteplatte.scdoc"
            };

            mMachineHelper.CreateAndSaveBendMachine( TestSettings, HomeZone.Machines, S_FLUX_MACHINE_5320 );

            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();
            bendSettings.AddDefaultBendProgram();
            settingsDialog.Save();

            TiParts parts = HomeZone.GotoParts();
            foreach( var item in showcasePartList )
            {
                mPartHelper.ImportPart( TestSettings, parts, Path.Combine( samplesPath, item ) );
            }
            parts.ResultColumn.SelectAll();
            parts.Toolbar.WaitForBoostButtonEnabled();
            parts.Toolbar.Boost();

            int timeoutCount = 0;
            foreach( var item in showcasePartList )
            {
                parts.ResultColumn.SelectItems( Path.GetFileNameWithoutExtension( item ) );
                bool waitSuccess = false;
                do
                {
                    waitSuccess = parts.WaitForDetailOverlayDisappear();
                    timeoutCount++;
                } while( !waitSuccess && timeoutCount < showcasePartList.Count ); //wait max: number of parts * timeout

                Assert.AreEqual( TcAppLangDependentStrings.ReleaseMissing, parts.SingleDetailBendSolutions.SingleBendSolutionStateToolTip( bendSolutionName ), "Bend solution has wrong state" );
                Assert.IsFalse( parts.SingleDetailBendSolutions.IsManuallyChanged( bendSolutionName ), "Bend solution indicates manual change but there is none" );
                parts.SingleDetailBendSolutions.OpenSolutionDetail( bendSolutionName );
                Assert.IsTrue( parts.SingleDetailBendSolutions.SetupPlanButtonVisible( bendSolutionName ), "Setup plan is missing for boosted solution" );
                Assert.IsTrue( parts.SingleDetailBendSolutions.NcButtonVisible( bendSolutionName ), "NC code is missing for boosted solution" );
            }
        }
    }
}
