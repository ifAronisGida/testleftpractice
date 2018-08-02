using System;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Shell
{
    /// <summary>
    /// The main menu.
    /// </summary>
    public class TcMainMenu : PageObject, IChildOf<TcHomeZoneApp>
    {
        protected override Search SearchPattern => Search.ByControlName( "System.Windows.Controls.Menu" );

        private readonly Lazy<TcMainMenuPopupMenu> mPopup;

        public TcMainMenu()
        {
            mPopup = new Lazy<TcMainMenuPopupMenu>( On<TcMainMenuPopupMenu> );
        }

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
        public TcMainMenuPopupMenu Popup => mPopup.Value;

        /// <summary>
        /// Refreshes the master data.
        /// </summary>
        /// <returns>this</returns>
        public PageObject RefreshMasterData()
        {
            Popup.Refresh.Click();

            return this;
        }

        /// <summary>
        /// Opens the settings dialog.
        /// </summary>
        /// <returns>this</returns>
        public PageObject OpenSettingsDialog()
        {
            Popup.Settings.Click();

            return this;
        }

        /// <summary>
        /// Shows the help.
        /// </summary>
        /// <returns>this</returns>
        public PageObject OpenHelp()
        {
            Popup.Help.Click();

            return this;
        }

        /// <summary>
        /// Shows the welcome screen.
        /// </summary>
        /// <returns>this</returns>
        public PageObject ShowWelcomeScreen()
        {
            Popup.WelcomeScreen.Click();

            return this;
        }

        /// <summary>
        /// Opens the about dialog.
        /// </summary>
        /// <returns>this</returns>
        public PageObject OpenAboutDialog()
        {
            Popup.About.Click();

            return this;
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <returns>this</returns>
        public PageObject CloseApplication()
        {
            Popup.Exit.Click();

            return this;
        }
    }
}
