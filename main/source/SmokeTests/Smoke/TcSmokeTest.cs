using System;
using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiObjectsTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using Trumpf.Coparoo.Desktop.Waiting;
using UiCommonFunctions.Utilities;

namespace HomeZone.SmokeTests.Smoke
{
    /// <summary>
    /// This test class contains smoke tests and supporting test methods.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcSmokeTest : TcBaseTestClass
    {
        private readonly TcSmokeHelpers mSmokeHelpers = new TcSmokeHelpers();
        private readonly TcSmokeTestsPart mSmokeTestsPart = new TcSmokeTestsPart();

        /// <summary>
        /// Smoke test: creating test items, adding bend and cut solutions to parts, testing..., deleting the test items.
        /// </summary>
        [TestMethod, UniqueName( "524A05EA-D25E-423E-8974-EF4CC6B7F8F0" )]
        //[Tag( "Smoke" )]
        public void SmokeTest()
        {
            //ExecuteUITest( DoThirdPartyLicenseTest, "Checking third party licenses" );
            ExecuteUITest( DoSmokeTest, "Running HomeZone Smoke Test" );
        }

        /// <summary>
        /// Checking third party licenses.
        /// </summary>
        [TestMethod, UniqueName( "273476C1-F42B-4A87-A71A-31389D54771F" )]
        //[Tag( "Smoke" )]
        public void ThirdPartyLicenseTest()
        {
            ExecuteUITest( DoThirdPartyLicenseTest, "Checking third party licenses" );
        }

        private void DoSmokeTest()
        {
            mSmokeHelpers.DoCreateTestItems();

            //TODO
            //testing...
            mSmokeTestsPart.ExecutePartSmokeTests();

            mSmokeHelpers.DoDeleteTestItems();
        }

        private void DoThirdPartyLicenseTest()
        {
            Log.Info( "Opening the About dialog." );
            var about = HomeZone.GotoMainMenu().OpenAboutDialog();

            Assert.IsTrue( about.IsVisible, "About dialog is not visible" );
            Log.Info( "About dialog successfully opened." );

            Log.Info( "Opening the 3rd party components dialog." );
            var componentsDlg = about.ShowThirdPartyComponents();
            Wait.For( () => componentsDlg.IsVisible, TimeSpan.FromSeconds( 15 ) );
            Assert.IsTrue( componentsDlg.IsVisible, "Components dialog is not visible" );
            Log.Info( "3rd party components dialog successfully opened." );
            Assert.AreNotEqual( 0, componentsDlg.HomeZoneLicenseCount, "HomeZone grid does not contain licenses" );
            Log.Info( "Some HomeZone licenses are visible." );

            Log.Info( "Opening the license text dialog." );
            var licenseTextDlg = componentsDlg.ShowLicenseText();
            Wait.For( () => licenseTextDlg.IsVisible, TimeSpan.FromSeconds( 15 ) );
            Assert.IsTrue( licenseTextDlg.IsVisible, "License text dialog is not visible" );
            Log.Info( "License text dialog successfully opened." );
            licenseTextDlg.Close();

            componentsDlg.Close();

            about.Close();
            Log.Info( "ThirdPartyLicenseTest successfully finished." );
        }
    }
}
