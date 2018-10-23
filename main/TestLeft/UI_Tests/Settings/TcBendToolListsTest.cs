using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Flux;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
using TestLeft.UI_Tests.Utilities;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Settings
{
    /// <summary>
    /// This test class contains bend settings specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcBendToolListsTest : TcBaseTestClass
    {
        /// <summary>
        /// Tests the tool lists configuration.
        /// </summary>
        [TestMethod, UniqueName( "204D1ED2-6B77-43E8-A638-9B1020488A1D" )]
        public void ToolListsConfigurationTest()
        {
            Act( () =>
            {
                // Create a toollist
                var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
                var bendSettings = settingsDialog.BendSettings;
                bendSettings.Goto();

                Assert.IsTrue( bendSettings.IsVisible );

                bendSettings.OpenToolListsConfiguration();

                string toollistName = "superTools";
                TcLandingPages flux = new TcLandingPages( Driver );
                bool visible = flux.ToolsListsDialogVisible( TestSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                if( visible )
                {
                    flux.CreateNewToolList( toollistName );
                    Thread.Sleep( TcLandingPages.SYNC_TIMEOUT );
                }

                settingsDialog.Cancel();

                // import part and use toollist
                var parts = HomeZone.GotoParts();
                parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

                bool found = CheckToolListDropdown( toollistName, out var toolList );
                if( found )
                {
                    toolList.Click();
                }
                Assert.IsTrue( found );

                parts.Toolbar.Delete();
            } );
        }

        /// <summary>
        /// Create toollist and delete it.
        /// </summary>
        [TestMethod, UniqueName( "200D1ED2-6B77-43E8-A638-9B1020488A1D" )]
        public void DeleteToolListsTest()
        {
            Act( () =>
             {
                 // Create a toollist
                 var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
                 var bendSettings = settingsDialog.BendSettings;
                 bendSettings.Goto();
                 Assert.IsTrue( bendSettings.IsVisible );
                 bendSettings.OpenToolListsConfiguration();

                 string toollistName = "rubbishTools";
                 TcLandingPages flux = new TcLandingPages( Driver );
                 bool visible = flux.ToolsListsDialogVisible( TestSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                 if( visible )
                 {
                     flux.CreateNewToolList( toollistName );
                 }
                 settingsDialog.Save();

                 // Delete the  toollist
                 bendSettings = HomeZone.GotoMainMenu().OpenSettingsDialog().BendSettings;
                 bendSettings.Goto();
                 Assert.IsTrue( bendSettings.IsVisible );
                 bendSettings.OpenToolListsConfiguration();
                 Thread.Sleep( TestSettings.FluxStartTimeout );

                 flux = new TcLandingPages( Driver );
                 visible = flux.ToolsListsDialogVisible( TestSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                 if( visible )
                 {
                     flux.DeleteToollist( toollistName );
                 }

                 settingsDialog.Save();

                 // wait for sync
                 Thread.Sleep( 20000 );

                 // import part and use toollist
                 var parts = HomeZone.GotoParts();
                 parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                 parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
                 parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

                 Assert.IsFalse( CheckToolListDropdown( toollistName, out var control ) );

                 parts.Toolbar.Delete();
             } );
        }

        /// <summary>
        /// Create toollist rename and choose it in Design
        /// </summary>
        [TestMethod, UniqueName( "201D1ED2-6B77-43E8-A638-9B1020488A1D" )]
        public void RenameToolList()
        {
            Act( () =>
             {
                 // Create a toollist
                 var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
                 var bendSettings = settingsDialog.BendSettings;
                 bendSettings.Goto();
                 Assert.IsTrue( bendSettings.IsVisible );
                 bendSettings.OpenToolListsConfiguration();

                 string toollistName = "oldName";
                 TcLandingPages flux = new TcLandingPages( Driver );
                 bool visible = flux.ToolsListsDialogVisible( TestSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                 if( visible )
                 {
                     flux.CreateNewToolList( toollistName );
                 }
                 settingsDialog.Save();

                 // rename toollist
                 string newName = "newName";
                 bendSettings = HomeZone.GotoMainMenu().OpenSettingsDialog().BendSettings;
                 bendSettings.Goto();
                 Assert.IsTrue( bendSettings.IsVisible );
                 bendSettings.OpenToolListsConfiguration();
                 Thread.Sleep( TestSettings.FluxStartTimeout );

                 flux = new TcLandingPages( Driver );
                 visible = flux.ToolsListsDialogVisible( TestSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                 if( visible )
                 {
                     flux.RenameToollist( toollistName, newName );
                     Thread.Sleep( TcLandingPages.SYNC_TIMEOUT );
                 }

                 settingsDialog.Save();

                 // import part and use toollist
                 var parts = HomeZone.GotoParts();
                 parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                 parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
                 parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

                 Assert.IsTrue( CheckToolListDropdown( newName, out var control ) );

                 parts.Toolbar.Delete();
             } );
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

            return found;
        }
    }
}