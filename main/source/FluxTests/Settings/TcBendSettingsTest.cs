using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiObjects.PageObjects.Flux;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.FluxTests.Settings
{
    /// <summary>
    /// This test class contains bend settings specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcBendSettingsTest : TcBaseTestClass
    {
        /// <summary>
        /// Tests the tools configuration.
        /// </summary>
        [TestMethod, UniqueName( "19165C0A-89BA-4A90-85D8-68747CA90F88" )]
        [Tag( "BendSettings" )]
        public void ToolsConfigurationTest()
        {
            Act( () =>
            {
                var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
                var bendSettings = settingsDialog.BendSettings;
                bendSettings.Goto();

                Assert.IsTrue( bendSettings.IsVisible );

                bendSettings.OpenToolsConfiguration();

                TcLandingPages flux = new TcLandingPages( Driver );
                bool visible = flux.ToolsDialogVisible( TestSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                if( visible )
                {
                    flux.CloseToolsDialog();
                }

                settingsDialog.Cancel();
            } );
        }

        /// <summary>
        /// Tests the bend deduction configuration.
        /// </summary>
        [TestMethod, UniqueName( "B215A1D3-2BC6-41BB-9BB8-FC67B0D7877D" )]
        [Tag( "BendSettings" )]
        public void BendDeductionConfigurationTest()
        {
            Act( () =>
            {
                var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
                var bendSettings = settingsDialog.BendSettings;
                bendSettings.Goto();

                Assert.IsTrue( bendSettings.IsVisible );

                bendSettings.OpenBendDeductionConfiguration();


                TcLandingPages flux = new TcLandingPages( Driver );
                bool visible = flux.BendFactorsDialogVisible( TestSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                if( visible )
                {
                    flux.CloseBendFactorDialog();
                }


                settingsDialog.Cancel();
            } );
        }

        /// <summary>
        /// Tests the app settings configuration.
        /// </summary>
        [TestMethod, UniqueName( "717D16C7-0275-415B-BD41-9B6F4241D4D4" )]
        [Tag( "BendSettings" )]
        public void AppSettingsConfigurationTest()
        {
            Act( () =>
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
            } );
        }

        /// <summary>
        /// Opens and closes the DataManager Bend.
        /// </summary>
        [TestMethod, UniqueName( "CB70F6D8-44BA-4A45-A6D4-55F16347E2DA" )]
        [Tag( "BendSettings" )]
        public void OpenAndCloseDataManagerBendTest()
        {
            Act( () =>
            {
                var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
                var bendSettings = settingsDialog.BendSettings;
                bendSettings.Goto();

                Assert.IsTrue( bendSettings.IsVisible );

                bendSettings.OpenDataManagerBend();

                settingsDialog.Cancel();
            } );
        }
    }
}