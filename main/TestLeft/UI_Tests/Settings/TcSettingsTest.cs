using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
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
        /// Opens the settings dialog.
        /// </summary>
        [TestMethod, UniqueName( "03808156-CFD7-4A39-8C58-8047C4B03125" )]
        public void OpenSettingsTest()
        {
            Act( () =>
            {
                IDriver driver = new LocalDriver();

                IControl menuItem = driver.Find<IProcess>( new ProcessPattern()
                {
                    ProcessName = "Trumpf.TruTops.Control.Shell"
                } ).Find<IControl>( new WPFPattern()
                {
                    ClrFullClassName = "Trumpf.TruTops.Control.Shell.Views.TcShellView"
                }, 2 ).Find<IWPFMenu>( new WPFPattern()
                {
                    ClrFullClassName = "System.Windows.Controls.Menu"
                }, 13 ).Find<IControl>( new WPFPattern()
                {
                    Uid = "ShellView.Menu"
                } );

                menuItem.Click();

                IWPFMenu menu = driver.Find<IProcess>( new ProcessPattern()
                {
                    ProcessName = "Trumpf.TruTops.Control.Shell"
                } ).Find<IControl>( new WPFPattern()
                {
                    ClrFullClassName = "Trumpf.TruTops.Control.Shell.Views.TcShellView"
                }, 2 ).Find<IWPFMenu>( new WPFPattern()
                {
                    ClrFullClassName = "System.Windows.Controls.Menu"
                }, 13 );

                menu.Click();

                var mainWindow = HomeZoneApp.On<TcMainWindow>();
                mainWindow.VisibleOnScreen.WaitFor();
                ((IControl)mainWindow.MainMenu).CallMethod("Click");
                //mainMenu.Node
            });
        }
    }
}
