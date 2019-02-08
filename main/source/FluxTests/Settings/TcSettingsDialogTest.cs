using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.FluxTests.Settings
{
    /// <summary>
    /// This test class contains settings specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public sealed class TcSettingsDialogTest : TcBaseTestClass
    {
        /// <summary>
        /// Opens and closes the settings dialog.
        /// </summary>
        [TestMethod, UniqueName( "03808156-CFD7-4A39-8C58-8047C4B03125" )]
        [Tag( "SettingsDialog" )]
        public void OpenAndCloseSettingsTest()
        {
            ExecuteUITest(DoOpenAndCloseSettingsTest, "Open And Close Settings" );
        }

        /// <summary>
        /// Implementation of the open and close settings test
        /// </summary>
        private void DoOpenAndCloseSettingsTest()
        {
            var settings = HomeZone.GotoMainMenu().OpenSettingsDialog();

            Assert.IsTrue( settings.IsVisible );

            settings.Cancel();
        }
    }
}
