using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Base;
using UiCommonFunctions.Utilities;

namespace FluxTests.Settings
{
    /// <summary>
    /// This test class contains settings specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcSettingsDialogTest : TcBaseTestClass
    {
        /// <summary>
        /// Opens and closes the settings dialog.
        /// </summary>
        [TestMethod, UniqueName( "03808156-CFD7-4A39-8C58-8047C4B03125" )]
        [Tag( "SettingsDialog" )]
        public void OpenAndCloseSettingsTest()
        {
            Act( () =>
            {
                var settings = HomeZone.GotoMainMenu().OpenSettingsDialog();

                Assert.IsTrue( settings.IsVisible );

                settings.Cancel();
            } );
        }
    }
}
