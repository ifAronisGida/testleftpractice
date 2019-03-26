using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.FluxTests.DataMigration
{
    [TestClass]
    public sealed class TcDataManagerTest : TcBaseTestClass
    {
        private static string S_TESTDATA_SUB_PATH = "DataMigration/TestData";
        private static string S_CSV_FILE_ENDING_FILTER = "*.csv";
        private static string S_REMOVE_CONTENT_AFTER_CHARACHTER = "@";
        private static int S_LINE_NUMBER_CONTAINING_DATE = 0;

        /// <summary>
        /// Opens and closes the DataManager Bend.
        /// </summary>
        [TestMethod, UniqueName( "CB70F6D8-44BA-4A45-A6D4-55F16347E2DA" )]
        [Tag( "DataMigration" )]
        public void OpenAndCloseDataManagerBendTest()
        {
            ExecuteUITest( DoOpenAndCloseDataManagerBendTest, "Open and Close Datamanager" );
        }

        /// <summary>
        /// Export all die deduction value test
        /// </summary>
        [TestMethod, UniqueName( "F66E71B5-26D9-43FD-9CF1-EA4022D449DB" )]
        [Tag( "DataMigration" )]
        public void ExportAllDieDeductionValueTest()
        {
            ExecuteUITest( DoExportAllDieDeductionValueTest, "Export Die Deduction Values" );
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

        /// <summary>
        /// Implementation of the export all deduction value test
        /// </summary>
        private void DoExportAllDieDeductionValueTest()
        {
            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();
            bendSettings.OpenDataManagerBend();

            DatamanagerBend.MainWindowExists.WaitFor( TestSettings.FluxStartTimeout );

            DatamanagerBend.DeductionValues.Goto();
            DatamanagerBend.DeductionValues.ExportTBSCSV();
            DatamanagerBend.DeductionValues.TBSExportDialog.SelectAll();
            DatamanagerBend.DeductionValues.TBSExportDialog.Export();
            DatamanagerBend.Close();

            settingsDialog.Cancel();

            string desktopPath = Environment.GetFolderPath( Environment.SpecialFolder.Desktop );
            List<string> generatedCSVFileList = Directory.GetFiles( desktopPath, S_CSV_FILE_ENDING_FILTER ).ToList();

            string testDataPath = Path.Combine( Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location ), S_TESTDATA_SUB_PATH );
            Dictionary<string, string> baselineDictionary = Directory.GetFiles( testDataPath, S_CSV_FILE_ENDING_FILTER ).ToDictionary( item => Path.GetFileName( item ), item => item );

            foreach( var item in generatedCSVFileList )
            {
                string originalFilePath = baselineDictionary[Path.GetFileName( item )];
                List<string> originalFile = File.ReadAllLines( originalFilePath ).ToList();
                int cutIndex = originalFile[S_LINE_NUMBER_CONTAINING_DATE].IndexOf( S_REMOVE_CONTENT_AFTER_CHARACHTER );
                originalFile[S_LINE_NUMBER_CONTAINING_DATE] = originalFile[S_LINE_NUMBER_CONTAINING_DATE].Substring( S_LINE_NUMBER_CONTAINING_DATE, cutIndex );

                List<string> testfile = File.ReadAllLines( item ).ToList();
                cutIndex = testfile[S_LINE_NUMBER_CONTAINING_DATE].IndexOf( S_REMOVE_CONTENT_AFTER_CHARACHTER );
                testfile[S_LINE_NUMBER_CONTAINING_DATE] = testfile[S_LINE_NUMBER_CONTAINING_DATE].Substring( S_LINE_NUMBER_CONTAINING_DATE, cutIndex );

                Assert.IsTrue( testfile.SequenceEqual( originalFile ), "Following csv file differs from baseline: " + Path.GetFileName( item ) );
                File.Delete( item );
            }
        }
    }
}