using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Settings;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Settings
{
    /// <summary>
    /// This test class contains settings specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcSettingsTest : TcBaseTestClass
    {
        /// <summary>
        /// Opens and closes the settings dialog.
        /// </summary>
        [TestMethod, UniqueName( "03808156-CFD7-4A39-8C58-8047C4B03125" )]
        public void OpenAndCloseSettingsTest()
        {
            Act( () =>
            {
                var settings = HomeZoneApp.Goto<TcSettings>();

                Assert.IsTrue( settings.VisibleOnScreen.TryWaitFor() );

                settings.Cancel();
            } );
        }

        /// <summary>
        /// Opens and closes the DataManager Bend.
        /// </summary>
        [TestMethod, UniqueName( "CB70F6D8-44BA-4A45-A6D4-55F16347E2DA" )]
        public void OpenAndCloseDataManagerBendTest()
        {
            Act( () =>
            {
                var bendSsettings = HomeZoneApp.Goto<TcBendSettings>();

                Assert.IsTrue( bendSsettings.VisibleOnScreen.TryWaitFor() );

                bendSsettings.OpenDataManagerBend();

                HomeZoneApp.On<TcSettings>().Cancel();
            } );
        }
    }
}
