using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Settings;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Settings
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
        public void OpenAndCloseSettingsTest()
        {
            Act( () =>
            {
                var settings = HomeZoneApp.Goto<TcSettingsDialog>();

                Assert.IsTrue( settings.VisibleOnScreen.TryWaitFor() );

                settings.Cancel();
            } );
        }
    }
}
