using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiObjectsTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
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
        private readonly TcSmokeHelpers mSmokeHelpers= new TcSmokeHelpers();
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

        /// <summary>
        /// Repeating:
        ///     Smoke test: creating test items, adding bend and cut solutions to parts, testing..., deleting the test items.
        /// Endless
        /// </summary>
        //[TestMethod, UniqueName( "4E5079D6-6820-4C01-B623-E1BB86AD8825" )]
        //[Tag( "Smoke" )]
        public void EndlessMiniSmokeTest()
        {
            Act( () =>
            {
                while( true )
                {
                    HomeZone.MainTabControl.AddNewTab();
                    DoSmokeTest();
                }
            } );
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
            var about = HomeZone.GotoMainMenu().OpenAboutDialog();

            Assert.IsTrue( about.IsVisible, "About dialog is not visible" );

            var componentsDlg = about.ShowThirdPartyComponents();

            Assert.IsTrue( componentsDlg.IsVisible, "Components dialog is not visible" );
            Assert.AreNotEqual( 0, componentsDlg.HomeZoneLicenseCount, "HomeZone grid does not contain licenses" );

            //var license = componentsDlg.GetHomeZoneLicenseRow( 0 );
            //Assert.IsFalse(string.IsNullOrEmpty(license.Component));
            //license.ShowLicenseText();

            var licenseTextDlg = componentsDlg.ShowLicenseText();
            Assert.IsTrue( licenseTextDlg.IsVisible, "License text dialog is not visible" );
            licenseTextDlg.Close();

            componentsDlg.Close();

            about.Close();
        }
    }
}
