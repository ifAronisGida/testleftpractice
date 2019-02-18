using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.FluxTests.DataMigration
{
    [TestClass]
    public sealed class TcDataManagerTest : TcBaseTestClass
    {
        /// <summary>
        /// Opens and closes the DataManager Bend.
        /// </summary>
        [TestMethod, UniqueName( "CB70F6D8-44BA-4A45-A6D4-55F16347E2DA" )]
        [Tag( "BendSettings" )]
        public void OpenAndCloseDataManagerBendTest()
        {
            ExecuteUITest( DoOpenAndCloseDataManagerBendTest, "Open and Close Datamanager" );
        }

        /// <summary>
        /// Implemenation of the opean and close datamanager test
        /// </summary>
        private void DoOpenAndCloseDataManagerBendTest()
        {
            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();

            Assert.IsTrue( bendSettings.IsVisible );

            bendSettings.OpenDataManagerBend();

            settingsDialog.Cancel();
        }
    }
}