namespace PageObjectInterfaces.Shell
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
        /// <returns>this</returns>
        TiMainMenu OpenSettingsDialog();

        /// <summary>
        /// Shows the help.
        /// </summary>
        /// <returns>this</returns>
        TiMainMenu OpenHelp();

        /// <summary>
        /// Shows the welcome screen.
        /// </summary>
        /// <returns>this</returns>
        TiMainMenu ShowWelcomeScreen();

        /// <summary>
        /// Opens the about dialog.
        /// </summary>
        /// <returns>this</returns>
        TiMainMenu OpenAboutDialog();

        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <returns>this</returns>
        TiMainMenu CloseApplication();
    }
}
