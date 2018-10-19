using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.UI_Tests.Base;
using TestLeft.UI_Tests.Utilities;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Shell
{
    /// <summary>
    /// This test class contains welcome screen specific tests.
    /// </summary>
    /// <seealso cref="TestLeft.UI_Tests.Base.TcBaseTestClass" />
    [TestClass]
    public class TcWelcomeScreenTest : TcBaseTestClass
    {
        /// <summary>
        /// Tests the welcome screen toggle CheckBox.
        /// </summary>
        [TestMethod, UniqueName( "ADDE5BD8-9ECE-44E6-A0F5-08033D498254" )]
        public void ToggleShowWelcomeScreenTest()
        {
            Act( () =>
            {
                var menu = HomeZone.GotoMainMenu();

                var welcomeScreen = menu.ShowWelcomeScreen();

                Assert.IsTrue( welcomeScreen.IsVisible );

                var toggle = welcomeScreen.ShowWelcomeScreen;

                // invert toggle
                welcomeScreen.ShowWelcomeScreen = !toggle;

                HomeZone.MainTabControl.CloseCurrentTab();

                menu.Goto();
                menu.ShowWelcomeScreen();
                Assert.IsTrue( welcomeScreen.IsVisible );
                Assert.AreNotEqual( welcomeScreen.ShowWelcomeScreen, toggle );

                // restore toggle
                welcomeScreen.ShowWelcomeScreen = toggle;

                HomeZone.MainTabControl.CloseCurrentTab();
            } );
        }
    }
}
