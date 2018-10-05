using System;
using PageObjectInterfaces.Shell;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Shell
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
        public TiMainMenu OpenSettingsDialog()
        {
            Popup.Settings.Click();

            return this;
        }

        /// <summary>
        /// Shows the help.
        /// </summary>
        /// <returns>this</returns>
        public TiMainMenu OpenHelp()
        {
            Popup.Help.Click();

            return this;
        }

        /// <summary>
        /// Shows the welcome screen.
        /// </summary>
        /// <returns>this</returns>
        public TiMainMenu ShowWelcomeScreen()
        {
            Popup.WelcomeScreen.Click();

            return this;
        }

        /// <summary>
        /// Opens the about dialog.
        /// </summary>
        /// <returns>this</returns>
        public TiMainMenu OpenAboutDialog()
        {
            Popup.About.Click();

            return this;
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
