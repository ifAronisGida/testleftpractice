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
        private const string S_TESTDATA_SUB_PATH = "DataMigration/TestData";
        private const string S_CSV_FILE_ENDING_FILTER = "*.csv";
        private const string S_REMOVE_CONTENT_AFTER_CHARACHTER = "@";
        private const string S_NO_CSV_FILES_EXPORTED = "No csv files have been exported";
        private const string S_ARVX_FILE_ENDING_FILTER = "*.arvx";
        private const string S_CUSTOM_MATERIAL_NAME = "1.234";

        private const int S_LINE_NUMBER_CONTAINING_DATE = 0;

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
        /// Export and import all die deduction values
        /// </summary>
        [TestMethod, UniqueName( "A4206A59-605D-4F78-9F55-F8B6A51D459B" )]
        [Tag( "DataMigration" )]
        public void MigrateAllDieDeductionValueTest()
        {
            ExecuteUITest( DoMigrateAllDieDeductionValueTest, "Export all die deduction values and import them in Flux" );
        }

        /// <summary>
        /// Migrate test coining deduction values
        /// </summary>
        [TestMethod, UniqueName( "7CC54046-D16A-4A0A-983A-18E217D0FBA8" )]
        [Tag( "DataMigration" )]
        public void MigrateTestCoiningDeductionValuesTest()
        {
            ExecuteUITest( DoMigrateTestCoiningDeductionValuesTest, "Export specified coining deduction values and import them in Flux" );
        }

        /// <summary>
        /// Implementation of the open and close datamanager test
        /// </summary>
        private void DoOpenAndCloseDataManagerBendTest()
        {
            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();

            Assert.IsTrue( bendSettings.IsVisible );

            bendSettings.OpenDataManagerBend();

            DatamanagerBend.MainWindowExists.WaitFor( TestSettings.DatamanagerBendStartTimeout );
            DatamanagerBend.Close();

            settingsDialog.Cancel();
        }

        /// <summary>
        /// Execute the export and import all die deduction value test
        /// </summary>
        private void DoMigrateAllDieDeductionValueTest()
        {
            ImportTestDeductionValues();

            List<Action> actionList = new List<Action>
            {
                ()=>DatamanagerBend.DeductionValues.TBSExportDialog.SelectAll()
            };
            ExportAndImportSpecifiedDeductionValues( actionList );
        }

        private void DoMigrateTestCoiningDeductionValuesTest()
        {
            ImportTestDeductionValues();

            List<Action> actionList = new List<Action>
            {
                ()=>DatamanagerBend.DeductionValues.TBSExportDialog.SelectByName( S_CUSTOM_MATERIAL_NAME ),
                ()=>DatamanagerBend.DeductionValues.TBSExportDialog.SelectCoining()
            };
            ExportAndImportSpecifiedDeductionValues( actionList );
        }

        private void ImportTestDeductionValues()
        {
            var materials = HomeZone.Materials;
            materials.ResultColumn.SearchText.Value = S_CUSTOM_MATERIAL_NAME;
            materials.ResultColumn.DoSearch();
            int count = materials.ResultColumn.Count;
            materials.ResultColumn.ClearSearch();
            if( count == 0 )
            {
                materials.ResultColumn.SelectItem( "1.0038" );
                materials.Toolbar.Duplicate();
                materials.Detail.Id.Value = S_CUSTOM_MATERIAL_NAME;
                materials.Toolbar.Save();

                var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
                var bendSettings = settingsDialog.BendSettings;
                bendSettings.Goto();
                bendSettings.OpenDataManagerBend();

                string testDataPath = Path.Combine( Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location ), S_TESTDATA_SUB_PATH );
                Dictionary<string, string> baselineDictionary = Directory.GetFiles( testDataPath, S_ARVX_FILE_ENDING_FILTER ).ToDictionary( item => Path.GetFileName( item ), item => item );
                DatamanagerBend.MainWindowExists.WaitFor( TestSettings.DatamanagerBendStartTimeout );
                DatamanagerBend.Tools.Import( baselineDictionary.First().Value );
                DatamanagerBend.Close();

                settingsDialog.Save();
            }
        }

        private void ExportAndImportSpecifiedDeductionValues( List<Action> deductionSelectionCommandList )
        {
            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();
            bendSettings.OpenDataManagerBend();

            DatamanagerBend.MainWindowExists.WaitFor( TestSettings.DatamanagerBendStartTimeout );
            DatamanagerBend.DeductionValues.Goto();
            DatamanagerBend.DeductionValues.ExportTBSCSV();
            foreach( var cmd in deductionSelectionCommandList )
            {
                cmd.Invoke();
            }
            DatamanagerBend.DeductionValues.TBSExportDialog.Export();
            DatamanagerBend.Close();

            List<string> generatedCSVFileList = GetGeneratedCSVFiles();
            CompareCSVFilesAgainstBaseline( generatedCSVFileList );
            bendSettings.OpenBendDeductionConfiguration();

            ImportExportedCSVFiles( generatedCSVFileList );

            settingsDialog.Save();
        }

        private List<string> GetGeneratedCSVFiles()
        {
            string desktopPath = Environment.GetFolderPath( Environment.SpecialFolder.Desktop );
            List<string> generatedCSVFileList = Directory.GetFiles( desktopPath, S_CSV_FILE_ENDING_FILTER ).ToList();
            return generatedCSVFileList;
        }

        private void CompareCSVFilesAgainstBaseline( List<string> generatedCSVFileList )
        {
            Assert.AreNotEqual( 0, generatedCSVFileList.Count, S_NO_CSV_FILES_EXPORTED );

            string testDataPath = Path.Combine( Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location ), S_TESTDATA_SUB_PATH );
            Dictionary<string, string> baselineDictionary = Directory.GetFiles( testDataPath, S_CSV_FILE_ENDING_FILTER ).ToDictionary( item => Path.GetFileName( item ), item => item );

            foreach( var item in generatedCSVFileList )
            {
                string originalFilePath = baselineDictionary[Path.GetFileName( item )];
                List<string> originalFile = File.ReadAllLines( originalFilePath ).ToList();
                int cutIndex = originalFile[S_LINE_NUMBER_CONTAINING_DATE].IndexOf( S_REMOVE_CONTENT_AFTER_CHARACHTER );
                originalFile[ S_LINE_NUMBER_CONTAINING_DATE ] = originalFile[ S_LINE_NUMBER_CONTAINING_DATE ].Substring( S_LINE_NUMBER_CONTAINING_DATE, cutIndex );

                List<string> testfile = File.ReadAllLines( item ).ToList();
                cutIndex = testfile[ S_LINE_NUMBER_CONTAINING_DATE ].IndexOf( S_REMOVE_CONTENT_AFTER_CHARACHTER );
                testfile[ S_LINE_NUMBER_CONTAINING_DATE ] = testfile[ S_LINE_NUMBER_CONTAINING_DATE ].Substring( S_LINE_NUMBER_CONTAINING_DATE, cutIndex );

                Assert.IsTrue( testfile.SequenceEqual( originalFile ), "Following csv file differs from baseline: " + Path.GetFileName( item ) );
            }
        }

        private void ImportExportedCSVFiles( List<string> exportedCSVList )
        {
            Flux.DeductionValueDialogExists.WaitFor( TestSettings.FluxStartTimeout );
            Flux.DeductionValueDialog.Reset();
            int entries = 0;
            foreach( var file in exportedCSVList )
            {
                Flux.DeductionValueDialog.Import( file );
                Assert.IsTrue( Flux.DeductionValueDialog.Entries() > entries, "csv Import has failed, since no entries were added to the list" );
                entries = Flux.DeductionValueDialog.Entries();
            }
            Flux.DeductionValueDialog.Close();
        }
    }
}