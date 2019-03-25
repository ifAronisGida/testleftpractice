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
        [Tag( "DataMigration" )]
        public void OpenAndCloseDataManagerBendTest()
        {
            ExecuteUITest( DoOpenAndCloseDataManagerBendTest, "Open and Close Datamanager" );
        }

        [TestMethod, UniqueName( "F66E71B5-26D9-43FD-9CF1-EA4022D449DB" )]
        [Tag( "DataMigration" )]
        public void ExportDieDeductionValueTest()
        {
            ExecuteUITest( DoExportDieDeductionValueTest, "Export Die Deduction Values" );
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

            DatamanagerBend.MainWindowExists.WaitFor( TestSettings.FluxStartTimeout );
            DatamanagerBend.Close();

            settingsDialog.Cancel();
        }

        private void DoExportDieDeductionValueTest()
        {
            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();
            bendSettings.OpenDataManagerBend();

            DatamanagerBend.MainWindowExists.WaitFor( TestSettings.FluxStartTimeout );

            DatamanagerBend.DeductionValues.Goto();
            DatamanagerBend.DeductionValues.ExportTBSCSV();
            DatamanagerBend.DeductionValues.TBSExportDialog.SelectAll();


            DatamanagerBend.Close();


            settingsDialog.Cancel();
        }
    }
}