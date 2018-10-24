using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;


namespace UiObjects.PageObjects.Shell
{
    public class TcMainMenuPopupMenu : PageObject, IChildOf<TcHomeZoneApp>
    {
        protected override Search SearchPattern => Search.Any;

        private IWPFPopupMenuOwner mMenu => Parent.Node.Find<IWPFPopupMenuOwner>( new WPFPattern()
        {
            ClrFullClassName = "System.Windows.Controls.Primitives.PopupRoot"
        }, 2 );

        /// <summary>
        /// Gets the refresh menu item.
        /// </summary>
        /// <value>
        /// The refresh menu item.
        /// </value>
        public IControl Refresh => mMenu.Find<IControl>( new WPFPattern() { Uid = "ShellView.Menu.Refresh" }, 3 );

        /// <summary>
        /// Gets the settings menu item.
        /// </summary>
        /// <value>
        /// The settings menu item.
        /// </value>
        public IControl Settings => mMenu.Find<IControl>( new WPFPattern() { Uid = "ShellView.Menu.Settings" }, 3 );

        /// <summary>
        /// Gets the help menu item.
        /// </summary>
        /// <value>
        /// The help menu item.
        /// </value>
        public IControl Help => mMenu.Find<IControl>( new WPFPattern() { Uid = "ShellView.Menu.Help" }, 3 );

        /// <summary>
        /// Gets the welcome screen menu item.
        /// </summary>
        /// <value>
        /// The welcome screen menu item.
        /// </value>
        public IControl WelcomeScreen => mMenu.Find<IControl>( new WPFPattern() { Uid = "ShellView.Menu.WelcomeScreen" }, 3 );

        /// <summary>
        /// Gets the about menu item.
        /// </summary>
        /// <value>
        /// The about menu item.
        /// </value>
        public IControl About => mMenu.Find<IControl>( new WPFPattern() { Uid = "ShellView.Menu.About" }, 3 );

        /// <summary>
        /// Gets the exit menu item.
        /// </summary>
        /// <value>
        /// The exit menu item.
        /// </value>
        public IControl Exit => mMenu.Find<IControl>( new WPFPattern() { Uid = "ShellView.Menu.Close" }, 3 );
    }
}
