using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using HomeZone.UiTests.Base;
using HomeZone.UiTests.Utilities;

namespace HomeZone.UiTests.Shell
{
    /// <summary>
    /// This test class contains main menu specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcMainMenuTest : TcBaseTestClass
    {
        /// <summary>
        /// Tests the refresh menu item.
        /// </summary>
        [TestMethod, UniqueName( "29738EAF-376F-45C2-9B98-29E95C04B142" )]
        [Tag( "MainMenu" )]
        public void RefreshMasterDataTest()
        {
            Act( () =>
            {
                var menu = HomeZone.GotoMainMenu();

                menu.RefreshMasterData();
            } );
        }

        /// <summary>
        /// Tests the settings menu item.
        /// </summary>
        [TestMethod, UniqueName( "31113C97-7127-4082-AC82-F301CA91F36E" )]
        [Tag( "MainMenu" )]
        public void OpenAndCloseSettingsTest()
        {
            Act( () =>
            {
                var settings = HomeZone.GotoMainMenu().OpenSettingsDialog();
                var visible = settings.IsVisible;

                Assert.IsTrue( visible );

                settings.Cancel();
            } );
        }

        /// <summary>
        /// Tests the help menu item.
        /// </summary>
        [TestMethod, UniqueName( "82FBBFE7-39DC-4773-8A60-2D0A2ADDA348" )]
        [Tag( "MainMenu" )]
        public void ShowHelpTest()
        {
            Act( () =>
            {
                var help = HomeZone.GotoMainMenu().OpenHelp();

                Assert.IsTrue( help.IsVisible );

                help.Close();
            } );
        }

        /// <summary>
        /// Tests the welcome screen menu item.
        /// </summary>
        [TestMethod, UniqueName( "80F7B52C-6320-40AA-8F5E-908CFB512B05" )]
        [Tag( "MainMenu" )]
        public void ShowWelcomeScreenTest()
        {
            Act( () =>
            {
                var welcomeScreen = HomeZone.GotoMainMenu().ShowWelcomeScreen();

                Assert.IsTrue( welcomeScreen.IsVisible );
            } );
        }

        /// <summary>
        /// Tests the about menu item.
        /// </summary>
        [TestMethod, UniqueName( "5BAE20E5-6DC2-4B48-A78B-D29483F772FD" )]
        [Tag( "MainMenu" )]
        public void ShowAboutTest()
        {
            Act( () =>
            {
                var about = HomeZone.GotoMainMenu().OpenAboutDialog();

                Assert.IsTrue( about.IsVisible );

                about.CopyToClipboard();
                about.Close();
            } );
        }

        /// <summary>
        /// Tests the exit menu item.
        /// </summary>
        [TestMethod, UniqueName( "9E82E847-ABAE-4431-BDAA-51B6027E8918" )]
        [Tag( "MainMenu" )]
        public void ExitTest()
        {
            Act( () =>
            {
                Assert.Inconclusive();      // the test closes the HomeZone

                var menu = HomeZone.GotoMainMenu();

                menu.CloseApplication();
            } );
        }
    }
}
