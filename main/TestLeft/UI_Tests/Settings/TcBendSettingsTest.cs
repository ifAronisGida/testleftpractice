using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Settings;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Settings
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
        public void ToolsConfigurationTest()
        {
            Act( () =>
            {
                var bendSettings = HomeZoneApp.Goto<TcBendSettings>();

                Assert.IsTrue( bendSettings.VisibleOnScreen.TryWaitFor() );

                bendSettings.OpenToolsConfiguration();


                //TODO implement test
                //.
                //.


                HomeZoneApp.On<TcSettingsDialog>().Cancel();
            } );
        }

        /// <summary>
        /// Tests the tool lists configuration.
        /// </summary>
        [TestMethod, UniqueName( "204D1ED2-6B77-43E8-A638-9B1020488A1D" )]
        public void ToolListsConfigurationTest()
        {
            Act( () =>
            {
                var bendSettings = HomeZoneApp.Goto<TcBendSettings>();

                Assert.IsTrue( bendSettings.VisibleOnScreen.TryWaitFor() );

                bendSettings.OpenToolListsConfiguration();


                //TODO implement test
                //.
                //.


                HomeZoneApp.On<TcSettingsDialog>().Cancel();
            } );
        }

        /// <summary>
        /// Tests the bend deduction configuration.
        /// </summary>
        [TestMethod, UniqueName( "B215A1D3-2BC6-41BB-9BB8-FC67B0D7877D" )]
        public void BendDeductionConfigurationTest()
        {
            Act( () =>
            {
                var bendSettings = HomeZoneApp.Goto<TcBendSettings>();

                Assert.IsTrue( bendSettings.VisibleOnScreen.TryWaitFor() );

                bendSettings.OpenBendDeductionConfiguration();


                //TODO implement test
                //.
                //.


                HomeZoneApp.On<TcSettingsDialog>().Cancel();
            } );
        }

        /// <summary>
        /// Tests the app settings configuration.
        /// </summary>
        [TestMethod, UniqueName( "717D16C7-0275-415B-BD41-9B6F4241D4D4" )]
        public void AppSettingsConfigurationTest()
        {
            Act( () =>
            {
                var bendSettings = HomeZoneApp.Goto<TcBendSettings>();

                Assert.IsTrue( bendSettings.VisibleOnScreen.TryWaitFor() );

                bendSettings.OpenAppSettingsConfiguration();


                //TODO implement test
                //.
                //.


                HomeZoneApp.On<TcSettingsDialog>().Cancel();
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
                var bendSettings = HomeZoneApp.Goto<TcBendSettings>();

                Assert.IsTrue( bendSettings.VisibleOnScreen.TryWaitFor() );

                bendSettings.OpenDataManagerBend();

                HomeZoneApp.On<TcSettingsDialog>().Cancel();
            } );
        }
    }
}