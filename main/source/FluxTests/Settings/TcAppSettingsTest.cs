using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Flux.AppSettingsDialogExists.WaitFor( TestSettings.FluxStartTimeout );
            Flux.AppSettings.Close();

            settingsDialog.Cancel();
        }
    }
}