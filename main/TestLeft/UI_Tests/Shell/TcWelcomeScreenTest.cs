using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjectInterfaces.Shell;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.UI_Tests.Base;
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
                var menu = HomeZoneApp.Goto<TiMainMenu, TcMainMenu>();

                menu.ShowWelcomeScreen();

                var welcomeScreen = HomeZoneApp.On<TiWelcomeScreen, TcWelcomeScreen>();

                Assert.IsTrue( welcomeScreen.WaitUntilVisible() );

                var toggle = welcomeScreen.ShowWelcomeScreen;

                // invert toggle
                welcomeScreen.ShowWelcomeScreen = !toggle;

                HomeZoneApp.On<TcMainTabControl>().CloseCurrentTab();

                menu.Goto();
                menu.ShowWelcomeScreen();
                Assert.IsTrue( welcomeScreen.WaitUntilVisible() );
                Assert.AreNotEqual( welcomeScreen.ShowWelcomeScreen, toggle );

                // restore toggle
                welcomeScreen.ShowWelcomeScreen = toggle;

                HomeZoneApp.On<TcMainTabControl>().CloseCurrentTab();
            } );
        }
    }
}
