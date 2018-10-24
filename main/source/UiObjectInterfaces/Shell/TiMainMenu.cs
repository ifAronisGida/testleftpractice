using UiObjectInterfaces.Dialogs;
using UiObjectInterfaces.Settings;


namespace UiObjectInterfaces.Shell
{
    public interface TiMainMenu
    {
        /// <summary>
        /// Goto the page object, i.e. perform necessary action to make the page object visible on screen, do nothing if the page is already visible on screen.
        /// </summary>
        void Goto();

        /// <summary>
        /// Refreshes the master data.
        /// </summary>
        /// <returns>this</returns>
        TiMainMenu RefreshMasterData();

        /// <summary>
        /// Opens the settings dialog.
        /// </summary>
        /// <returns>The settings dialog</returns>
        TiSettingsDialog OpenSettingsDialog();

        /// <summary>
        /// Shows the help.
        /// </summary>
        /// <returns>The help dialog</returns>
        TiHelpDialog OpenHelp();

        /// <summary>
        /// Shows the welcome screen.
        /// </summary>
        /// <returns>The welcome screen</returns>
        TiWelcomeScreen ShowWelcomeScreen();

        /// <summary>
        /// Opens the about dialog.
        /// </summary>
        /// <returns>The about dialog</returns>
        TiAboutDialog OpenAboutDialog();

        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <returns>this</returns>
        TiMainMenu CloseApplication();
    }
}
