using HomeZone.FluxTests.Flux;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using System;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.FluxTests.Settings
{
    /// <summary>
    /// This test class contains bend settings specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClassFlux" />
    [TestClass]
    public sealed class TcBendToolManagementTest : TcBaseTestClassFlux
    {
        private static string S_BOOST_BEND_SETTINGS_NOT_VISIBLE = "Boost Bend Settings Dialog is not visible";
        private static string S_MISSING_FLUX_TOOL_LIST_IN_BOOST = "Flux tool list is not available in HomeZone UI";

        /// <summary>
        /// Tests the tool lists configuration.
        /// </summary>
        [TestMethod, UniqueName( "204D1ED2-6B77-43E8-A638-9B1020488A1D" )]
        [Tag( "ToolListSettings" )]
        public void ToolListsConfigurationTest()
        {
            ExecuteUITest( DoToolListsConfigurationTest, "Tool List Configuration Test" );
        }

        /// <summary>
        /// Create toollist and delete it.
        /// </summary>
        [TestMethod, UniqueName( "200D1ED2-6B77-43E8-A638-9B1020488A1D" )]
        [Tag( "ToolListSettings" )]
        public void DeleteToolListsTest()
        {
            ExecuteUITest( DoDeleteToolListsTest, "Delete Tool List" );
        }

        /// <summary>
        /// Create toollist rename and choose it in Design
        /// </summary>
        [TestMethod, UniqueName( "201D1ED2-6B77-43E8-A638-9B1020488A1D" )]
        [Tag( "ToolListSettings" )]
        public void RenameToolList()
        {
            ExecuteUITest( DoRenameToolList, "Rename Tool List" );
        }

        /// <summary>
        /// Tests the tools configuration.
        /// </summary>
        [TestMethod, UniqueName( "19165C0A-89BA-4A90-85D8-68747CA90F88" )]
        [Tag( "BendSettings" )]
        public void ToolsConfigurationTest()
        {
            ExecuteUITest( DoToolsConfigurationTest, "Tools Configuration" );
        }

        /// <summary>
        /// Implementation of the tool list configuration test
        /// </summary>
        private void DoToolListsConfigurationTest()
        {
            // Create a toollist
            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();

            Assert.IsTrue( bendSettings.IsVisible, S_BOOST_BEND_SETTINGS_NOT_VISIBLE );

            bendSettings.OpenToolsConfiguration();

            string toollistName = "superTools";
            Flux.ToolManamgementDialogExists.WaitFor( TestSettings.FluxStartTimeout );
            Flux.ToolManagement.NewToolList( toollistName );
            Flux.ToolManagement.Close();
            Flux.SaveChanges();
            Flux.WaitForSynchronization( TestSettings.FluxSyncTimeout );

            settingsDialog.Cancel();

            // import part and use toollist
            var parts = HomeZone.GotoParts();
            mPartHelper.ImportPart( TestSettings, parts, @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            Assert.IsTrue( CheckToolListDropdown( toollistName, out var toolList ), S_MISSING_FLUX_TOOL_LIST_IN_BOOST );

            parts.Toolbar.Delete();
        }

        /// <summary>
        /// Implementation of the delete tool list test
        /// </summary>
        private void DoDeleteToolListsTest()
        {
            // Create a toollist
            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();
            Assert.IsTrue( bendSettings.IsVisible, S_BOOST_BEND_SETTINGS_NOT_VISIBLE );
            bendSettings.OpenToolsConfiguration();

            string toollistName = "rubbishTools";

            Flux.ToolManamgementDialogExists.WaitFor( TestSettings.FluxStartTimeout );
            Flux.ToolManagement.NewToolList( toollistName );
            Flux.ToolManagement.Close();
            Flux.SaveChanges();
            Flux.WaitForSynchronization( TestSettings.FluxSyncTimeout );
            settingsDialog.Save();

            // Delete the  toollist
            bendSettings = HomeZone.GotoMainMenu().OpenSettingsDialog().BendSettings;
            bendSettings.Goto();
            Assert.IsTrue( bendSettings.IsVisible, S_BOOST_BEND_SETTINGS_NOT_VISIBLE );
            bendSettings.OpenToolsConfiguration();

            Flux.ToolManamgementDialogExists.WaitFor( TestSettings.FluxStartTimeout );
            Flux.ToolManagement.DeleteToolList( toollistName );
            Flux.ToolManagement.Close();
            Flux.WaitForSynchronization( TestSettings.FluxSyncTimeout );
            settingsDialog.Save();

            // import part and use toollist
            var parts = HomeZone.GotoParts();
            mPartHelper.ImportPart( TestSettings, parts, @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );

            Assert.IsFalse( CheckToolListDropdown( toollistName, out var control ), S_MISSING_FLUX_TOOL_LIST_IN_BOOST );
        }

        /// <summary>
        /// Implementation of the rename tool list test
        /// </summary>
        private void DoRenameToolList()
        {
            // Create a toollist
            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();
            Assert.IsTrue( bendSettings.IsVisible, S_BOOST_BEND_SETTINGS_NOT_VISIBLE );
            bendSettings.OpenToolsConfiguration();

            string toollistName = "oldName";
            Flux.ToolManamgementDialogExists.WaitFor( TestSettings.FluxStartTimeout );
            Flux.ToolManagement.NewToolList( toollistName );
            Flux.ToolManagement.Close();
            Flux.SaveChanges();
            Flux.WaitForSynchronization( TestSettings.FluxSyncTimeout );
            settingsDialog.Save();

            // rename toollist
            string newName = "newName";
            bendSettings = HomeZone.GotoMainMenu().OpenSettingsDialog().BendSettings;
            bendSettings.Goto();
            Assert.IsTrue( bendSettings.IsVisible, S_BOOST_BEND_SETTINGS_NOT_VISIBLE );
            bendSettings.OpenToolsConfiguration();
            Flux.ToolManamgementDialogExists.WaitFor( TimeSpan.FromSeconds( 60 ) );
            Flux.ToolManagement.RenameToolList( toollistName, newName );
            Flux.ToolManagement.Close();
            Flux.SaveChanges();
            Flux.WaitForSynchronization( TestSettings.FluxSyncTimeout );
            settingsDialog.Save();

            // import part and use toollist
            var parts = HomeZone.GotoParts();
            mPartHelper.ImportPart( TestSettings, parts, @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );

            Assert.IsTrue( CheckToolListDropdown( newName, out var control ), "Newly created tool list is not available in HomeZone UI" );
        }

        /// <summary>
        /// Implementation of the tool list configuration test
        /// </summary>
        private void DoToolsConfigurationTest()
        {
            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();

            Assert.IsTrue( bendSettings.IsVisible, S_BOOST_BEND_SETTINGS_NOT_VISIBLE );

            bendSettings.OpenToolsConfiguration();

            Flux.ToolManamgementDialogExists.WaitFor( TestSettings.FluxStartTimeout );
            //TODO: implement tests (like editing tools)
            Flux.ToolManagement.Close();

            settingsDialog.Cancel();
        }


        /// <summary>
        /// Check for Toollist in Design dropdown
        /// </summary>
        /// <param name="toolListName"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private bool CheckToolListDropdown( string toolListName, out IControl control )
        {
            control = null;
            var menu = HomeZone.GotoMainMenu();
            menu.RefreshMasterData();
            bool found = false;

            IControl toggleStateButton = Driver.Find<IProcess>( new ProcessPattern()
            {
                ProcessName = "Trumpf.TruTops.Control.Shell"
            } ).Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "Trumpf.TruTops.Control.Shell.Views.TcShellView"
            }, 2 ).Find<IControl>( new WPFPattern()
            {
                WPFControlName = "MainTabControl"
            }, 12 ).Find<IControl>( new WPFPattern()
            {
                WPFControlName = "LayoutWorkArea"
            }, 18 ).Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "DevExpress.Xpf.LayoutControl.LayoutItem",
                WPFControlOrdinalNo = 3
            }, 2 ).Find<IControl>( new WPFPattern()
            {
                WPFControlName = "PART_Item"
            }, 4 );
            toggleStateButton.Click();

            IProcess homeZone = Driver.Find<IProcess>( new ProcessPattern()
            {
                ProcessName = "Trumpf.TruTops.Control.Shell"
            } );
            homeZone.TryFind<IControl>( new WPFPattern { ClrFullClassName = "System.Windows.Controls.Primitives.PopupRoot" }, 2, out var dropDown );
            found = dropDown.TryFind<IControl>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.TextBlock",
                WPFControlText = toolListName
            }, 12, out control );

            // DropDown has to be closed. Otherwise the first following Click Event will close the window instead of executing 
            // the desired click event.

            Driver.Desktop.Keys( "[Enter]" ); //Close Dropdown. 

            return found;
        }

    }
}