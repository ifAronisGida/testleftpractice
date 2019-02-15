using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.UiObjectsTests.Dialogs
{
    [TestClass]
    public class Tc3rdPartyComponentsDialogTest : TcBaseTestClass
    {
        [TestMethod, UniqueName( "CF8FF340-D41A-4D6E-AF97-2C46DC83537E" )]
        public void ShowLicensesTest()
        {
            Act( () =>
            {
                var about = HomeZone.GotoMainMenu().OpenAboutDialog();

                Assert.IsTrue( about.IsVisible,"About dialog is not visible" );

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

            } );
        }
    }
}
