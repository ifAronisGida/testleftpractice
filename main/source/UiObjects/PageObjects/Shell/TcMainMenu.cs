using System;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Dialogs;
using UiObjectInterfaces.Settings;
using UiObjectInterfaces.Shell;
using UiObjects.PageObjects.Dialogs;
using UiObjects.PageObjects.Settings;


namespace UiObjects.PageObjects.Shell
{
    /// <summary>
    /// The main menu.
    /// </summary>
    public class TcMainMenu : PageObject, IChildOf<TcHomeZoneApp>, TiMainMenu
    {
        protected override Search SearchPattern => Search.ByControlName( "System.Windows.Controls.Menu" );

        private readonly Lazy<TcMainMenuPopupMenu> mPopup;

        public TcMainMenu()
        {
            mPopup = new Lazy<TcMainMenuPopupMenu>( On<TcMainMenuPopupMenu> );
        }

        /// <summary>
        /// Goto the page object, i.e. perform necessary action to make the page object visible on screen, do nothing if the page is already visible on screen.
        /// </summary>
        public override void Goto()
        {
            if( !IsVisibleOnScreen )
            {
                Parent.Node.Find<IControl>( new WPFPattern()
                {
                    ClrFullClassName = "Trumpf.TruTops.Control.Shell.Views.TcShellView"
                }, 2 ).Find<IWPFMenu>( new WPFPattern()
                {
                    ClrFullClassName = "System.Windows.Controls.Menu"
                }, 13 ).Find<IControl>( new WPFPattern()
                {
                    ClrFullClassName = "System.Windows.Controls.MenuItem",
                    WPFControlText = "xxx"
                } ).Click();
            }
        }

        /// <summary>
        /// Gets the PopupMenu.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        private TcMainMenuPopupMenu Popup => mPopup.Value;

        /// <summary>
        /// Refreshes the master data.
        /// </summary>
        /// <returns>this</returns>
        public TiMainMenu RefreshMasterData()
        {
            Popup.Refresh.Click();

            return this;
        }

        /// <summary>
        /// Opens the settings dialog.
        /// </summary>
        /// <returns>this</returns>
        public TiSettingsDialog OpenSettingsDialog()
        {
            Popup.Settings.Click();

            return On<TcSettingsDialog>();
        }

        /// <summary>
        /// Shows the help.
        /// </summary>
        /// <returns>The help dialog</returns>
        public TiHelpDialog OpenHelp()
        {
            Popup.Help.Click();

            return On<TcHelpDialog>();
        }

        /// <summary>
        /// Shows the welcome screen.
        /// </summary>
        /// <returns>The welcome screen</returns>
        public TiWelcomeScreen ShowWelcomeScreen()
        {
            Popup.WelcomeScreen.Click();

            return On<TcWelcomeScreen>();
        }

        /// <summary>
        /// Opens the about dialog.
        /// </summary>
        /// <returns>The about dialog</returns>
        public TiAboutDialog OpenAboutDialog()
        {
            Popup.About.Click();

            return On<TcAboutDialog>();
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <returns>this</returns>
        public TiMainMenu CloseApplication()
        {
            Popup.Exit.Click();

            return this;
        }
    }
}
