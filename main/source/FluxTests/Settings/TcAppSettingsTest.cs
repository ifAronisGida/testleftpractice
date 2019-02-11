using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiObjects.PageObjects.Flux;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.FluxTests.Settings
{
    [TestClass]
    public sealed class TcAppSettingsTest : TcBaseTestClass
    {
        /// <summary>
        /// Tests the app settings configuration.
        /// </summary>
        [TestMethod, UniqueName( "717D16C7-0275-415B-BD41-9B6F4241D4D4" )]
        [Tag( "BendSettings" )]
        public void AppSettingsConfigurationTest()
        {
            ExecuteUITest( DoAppSettingsConfigurationTest, "App Settings Configuration Test" );
        }

        /// <summary>
        /// Implementation of the app settings configuration test
        /// </summary>
        private void DoAppSettingsConfigurationTest()
        {
            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();

            Assert.IsTrue( bendSettings.IsVisible );

            bendSettings.OpenAppSettingsConfiguration();


            TcLandingPages flux = new TcLandingPages( Driver );
            bool visible = flux.SettingsDialogVisible( TestSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            if( visible )
            {
                flux.CloseSettingsDialog();
            }

            settingsDialog.Cancel();
        }
    }
}