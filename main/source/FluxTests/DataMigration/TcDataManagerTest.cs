using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiCommonFunctions.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
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
        private const string S_MATERIAL_NAME_TO_DUPLICATE = "1.0038";

        private const int S_LINE_NUMBER_CONTAINING_DATE = 0;
        
        [TestMethod, UniqueName( "CB70F6D8-44BA-4A45-A6D4-55F16347E2DA" )]
        [Tag( "DataMigration" )]
        [Description( "Open and Close Datamanager." )]
        public void OpenAndCloseDataManagerBendTest()
        {
            ExecuteUITest( DoOpenAndCloseDataManagerBendTest, TcTestHelper.GetTestMethodDescription() );
        }
        
        [TestMethod, UniqueName( "A4206A59-605D-4F78-9F55-F8B6A51D459B" )]
        [Tag( "DataMigration" )]
        [Description( "Export all die deduction values and tests if there is a deduction-values file for each material." )]
        public void ExportAllDieDeductionValueTest()
        {
            ExecuteUITest( DoExportAllDieDeductionValueTest, TcTestHelper.GetTestMethodDescription() );
        }

        [TestMethod, UniqueName( "98328DC6-B1F3-437F-963E-D2672D3AEF99" )]
        [Tag( "DataMigration" )]
        [Description( "Export 'die' deduction values from two specific material, import them in Flux and check the import was successful." )]
        public void MigrateDieDeductionValueFromTwoMaterialsTest()
        {
            ExecuteUITest( DoMigrateTestDieDeductionValuesTest, TcTestHelper.GetTestMethodDescription() );
        }

        [TestMethod, UniqueName( "7CC54046-D16A-4A0A-983A-18E217D0FBA8" )]
        [Tag( "DataMigration" )]
        [Description( "Export 'coining' deduction values from a specific material, import them in Flux and check the import was successful." )]
        public void MigrateTestCoiningDeductionValuesFromOneMaterialTest()
        {
            ExecuteUITest( DoMigrateTestCoiningDeductionValuesTest, TcTestHelper.GetTestMethodDescription() );
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

        private void DoExportAllDieDeductionValueTest()
        {
            List<Action> actionList = new List<Action>
            {
                ()=>DatamanagerBend.DeductionValues.TBSExportDialog.SelectAll(),
                ()=>DatamanagerBend.DeductionValues.TBSExportDialog.SelectDie()
            };

            DateTime timeBeforeExport = DateTime.Now;
            var availableMaterialCount = ExportSpecifiedDeductionValuesAndGetAvailableMaterialCount( actionList );
            var exportedFiles = MoveExportedFilesFromDesktopToActualTestOutputFolderAndReturnTheTargetFolder(timeBeforeExport);

            Assert.AreEqual( availableMaterialCount, exportedFiles.Count, $"A1: The exported files count is unexpected." );
        }

        private void DoMigrateTestCoiningDeductionValuesTest()
        {
            List<Action> actionList = new List<Action>
            {
                ()=>DatamanagerBend.DeductionValues.TBSExportDialog.SelectByMaterialName( S_CUSTOM_MATERIAL_NAME ),
                ()=>DatamanagerBend.DeductionValues.TBSExportDialog.SelectCoining()
            };

            MigrateCoiningDeductionValues( actionList );
        }

        private void DoMigrateTestDieDeductionValuesTest()
        {
            List<Action> actionList = new List<Action>
            {
                ()=>DatamanagerBend.DeductionValues.TBSExportDialog.SelectByMaterialName( S_CUSTOM_MATERIAL_NAME ),
                ()=>DatamanagerBend.DeductionValues.TBSExportDialog.SelectByMaterialName( S_MATERIAL_NAME_TO_DUPLICATE ),
                ()=>DatamanagerBend.DeductionValues.TBSExportDialog.SelectDie()
            };

            MigrateCoiningDeductionValues( actionList );
        }

        private void MigrateCoiningDeductionValues( List<Action> actionList )
        {
            ImportTestDeductionValues();

            var timeBeforeExport = DateTime.Now;
            ExportSpecifiedDeductionValuesAndGetAvailableMaterialCount( actionList );

            var generatedCSVFiles = MoveExportedFilesFromDesktopToActualTestOutputFolderAndReturnTheTargetFolder( timeBeforeExport );

            CompareCSVFilesAgainstBaseline( generatedCSVFiles );

            ImportSpecifiedDeductionValues( generatedCSVFiles );
        }

        /// <summary>
        /// Import test deduction values from TestData
        /// </summary>
        private void ImportTestDeductionValues()
        {
            var materials = HomeZone.Materials;
            materials.ResultColumn.SearchText.Value = S_CUSTOM_MATERIAL_NAME;
            materials.ResultColumn.DoSearch();
            int count = materials.ResultColumn.Count;
            materials.ResultColumn.ClearSearch();
            if( count == 0 )
            {
                materials.ResultColumn.SelectItem( S_MATERIAL_NAME_TO_DUPLICATE );
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
        
        private int ExportSpecifiedDeductionValuesAndGetAvailableMaterialCount( List<Action> deductionSelectionCommandList )
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

            IListBox listBox = Driver.Find<IProcess>( new ProcessPattern()
            {
                ProcessName = "DataManager"
            } ).Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "Trumpf.TruTops.DataMigrationTool.Views.Bend_Factor_Explorer.TcBendFactorTbsExportDialog"
            }, 2 ).Find<IListBox>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.ListBox"
            }, 2 );
            var selectedItemsCount = listBox.wSelected.Count();

            DatamanagerBend.DeductionValues.TBSExportDialog.Export();
            DatamanagerBend.Close();

            settingsDialog.Save();

            return selectedItemsCount;
        }

        private void ImportSpecifiedDeductionValues( List<string> csvFileList )
        {
            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();
            bendSettings.OpenDataManagerBend();
            bendSettings.OpenBendDeductionConfiguration();

            ImportExportedCSVFilesAndAssertNewDeductionValuesAdded( csvFileList );

            settingsDialog.Save();
        }

        private List<string> MoveExportedFilesFromDesktopToActualTestOutputFolderAndReturnTheTargetFolder( DateTime timeBeforeExport )
        {
            string desktopFolder = Environment.GetFolderPath( Environment.SpecialFolder.Desktop );
            List<string> generatedCSVFileList = GetCSVFiles( desktopFolder );

            var targetFolder = Path.Combine( TestContext.TestDeploymentDir, TestContext.TestName );

            foreach(string sourceFile in generatedCSVFileList)
            {
                if( !Directory.Exists( targetFolder ) )
                {
                    Directory.CreateDirectory( targetFolder );
                }

                var destFile = Path.Combine( targetFolder, Path.GetFileName( sourceFile ) );

                if( File.GetLastWriteTime( sourceFile ) > timeBeforeExport)
                {
                    File.Copy( sourceFile, destFile );
                    File.Delete( sourceFile );
                }
            }

            return GetCSVFiles(targetFolder);
        }

        private List<string> GetCSVFiles(string filesFolder)
        {
            return Directory.GetFiles( filesFolder, S_CSV_FILE_ENDING_FILTER ).ToList();
        }

        /// <summary>
        /// Compare generated csv files against the baseline
        /// </summary>
        /// <param name="generatedCSVFileList">list of generated csv file paths</param>
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

        /// <summary>
        /// Import exported csv files
        /// </summary>
        /// <param name="exportedCSVList">file path list of exported csv files</param>
        private void ImportExportedCSVFilesAndAssertNewDeductionValuesAdded( List<string> exportedCSVList )
        {
            Flux.DeductionValueDialogExists.WaitFor( TestSettings.FluxStartTimeout );
            Flux.DeductionValueDialog.Reset();
            int entries = 0;
            foreach( var file in exportedCSVList )
            {
                Flux.DeductionValueDialog.Import( file );

                bool importResult = TcTestHelper.WaitUntilConditionFulfilledOrTimeout( 
                    delegate()
                    {
                        return Flux.DeductionValueDialog.Entries() > entries;
                    });
                Assert.IsTrue( importResult, "csv Import has failed, since no entries were added to the list" );

                entries = Flux.DeductionValueDialog.Entries();
            }
            Flux.DeductionValueDialog.Close();
        }
    }
}