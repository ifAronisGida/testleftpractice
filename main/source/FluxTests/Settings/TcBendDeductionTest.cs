using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiObjects.PageObjects.Flux;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.FluxTests.Settings
{
    [TestClass]
    public sealed class TcBendDeductionTest : TcBaseTestClass
    {
        /// <summary>
        /// Tests the bend deduction configuration.
        /// </summary>
        [TestMethod, UniqueName( "B215A1D3-2BC6-41BB-9BB8-FC67B0D7877D" )]
        [Tag( "BendSettings" )]
        public void BendDeductionConfigurationTest()
        {
            ExecuteUITest( DoBendDeductionConfigurationTest, "Bend Deduction Configuration" );
        }

        /// <summary>
        /// Implementation of the deduction configuration test
        /// </summary>
        private void DoBendDeductionConfigurationTest()
        {
            var settingsDialog = HomeZone.GotoMainMenu().OpenSettingsDialog();
            var bendSettings = settingsDialog.BendSettings;
            bendSettings.Goto();

            Assert.IsTrue( bendSettings.IsVisible );

            bendSettings.OpenBendDeductionConfiguration();


            TcLandingPages flux = new TcLandingPages( Driver );
            bool visible = flux.BendFactorsDialogVisible( TestSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            flux.CloseBendFactorDialog();

            settingsDialog.Cancel();
        }
    }
}