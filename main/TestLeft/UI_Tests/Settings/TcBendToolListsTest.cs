using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjectInterfaces.Part;
using PageObjectInterfaces.Settings;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Flux;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.PageObjects.Settings;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
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
                var bendSettings = HomeZoneApp.Goto<TiSettingsDialog, TcSettingsDialog>().BendSettings;
                bendSettings.Goto();

                Assert.IsTrue( bendSettings.WaitUntilVisible() );

                bendSettings.OpenToolListsConfiguration();

                string toollistName = "superTools";
                TcLandingPages flux = new TcLandingPages( Driver );
                bool visible = flux.ToolsListsDialogVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                if( visible )
                {
                    flux.CreateNewToolList( toollistName );
                    Thread.Sleep( TcLandingPages.SYNC_TIMEOUT );
                }

                HomeZoneApp.On<TcSettingsDialog>().Cancel();

                // import part and use toollist
                var parts = HomeZoneApp.Goto<TiParts, TcParts>();
                parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                bool found = CheckToolListDropdown( toollistName, out var toolList );
                if( found )
                {
                    toolList.Click();
                }
                Assert.IsTrue( found );

                parts.DeletePart();
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
                 var bendSettings = HomeZoneApp.Goto<TiSettingsDialog, TcSettingsDialog>().BendSettings;
                 bendSettings.Goto();
                 Assert.IsTrue( bendSettings.WaitUntilVisible() );
                 bendSettings.OpenToolListsConfiguration();

                 string toollistName = "rubbishTools";
                 TcLandingPages flux = new TcLandingPages( Driver );
                 bool visible = flux.ToolsListsDialogVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                 if( visible )
                 {
                     flux.CreateNewToolList( toollistName );
                 }
                 HomeZoneApp.On<TcSettingsDialog>().Save();

                 // Delete the  toollist
                 bendSettings = HomeZoneApp.Goto<TiSettingsDialog, TcSettingsDialog>().BendSettings;
                 bendSettings.Goto();
                 Assert.IsTrue( bendSettings.WaitUntilVisible() );
                 bendSettings.OpenToolListsConfiguration();
                 Thread.Sleep( TcSettings.FluxStartTimeout );

                 flux = new TcLandingPages( Driver );
                 visible = flux.ToolsListsDialogVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                 if( visible )
                 {
                     flux.DeleteToollist( toollistName );
                 }

                 HomeZoneApp.On<TcSettingsDialog>().Save();

                 // import part and use toollist
                 var parts = HomeZoneApp.Goto<TiParts, TcParts>();
                 parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                 parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                 parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                 Assert.IsFalse( CheckToolListDropdown( toollistName, out var control ) );

                 parts.DeletePart();
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
                 var bendSettings = HomeZoneApp.Goto<TiSettingsDialog, TcSettingsDialog>().BendSettings;
                 bendSettings.Goto();
                 Assert.IsTrue( bendSettings.WaitUntilVisible() );
                 bendSettings.OpenToolListsConfiguration();

                 string toollistName = "oldName";
                 TcLandingPages flux = new TcLandingPages( Driver );
                 bool visible = flux.ToolsListsDialogVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                 if( visible )
                 {
                     flux.CreateNewToolList( toollistName );
                 }
                 HomeZoneApp.On<TcSettingsDialog>().Save();

                 // rename toollist
                 string newName = "newName";
                 bendSettings = HomeZoneApp.Goto<TiSettingsDialog, TcSettingsDialog>().BendSettings;
                 bendSettings.Goto();
                 Assert.IsTrue( bendSettings.WaitUntilVisible() );
                 bendSettings.OpenToolListsConfiguration();
                 Thread.Sleep( TcSettings.FluxStartTimeout );

                 flux = new TcLandingPages( Driver );
                 visible = flux.ToolsListsDialogVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                 if( visible )
                 {
                     flux.RenameToollist( toollistName, newName );
                     Thread.Sleep( TcLandingPages.SYNC_TIMEOUT );
                 }

                 HomeZoneApp.On<TcSettingsDialog>().Save();

                 // import part and use toollist
                 var parts = HomeZoneApp.Goto<TiParts, TcParts>();
                 parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                 parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                 parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                 Assert.IsTrue( CheckToolListDropdown( newName, out var control ) );

                 parts.DeletePart();
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
            var menu = HomeZoneApp.Goto<TcMainMenu>();
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