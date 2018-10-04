namespace PageObjectInterfaces.Settings
{
    public interface TiSettingsDialog
    {
        /// <summary>
        /// Waits until visible.
        /// </summary>
        /// <returns>true if visible</returns>
        bool WaitUntilVisible();

        /// <summary>
        /// Gets the bend settings PageObject.
        /// </summary>
        /// <value>
        /// The bend settings PageObject.
        /// </value>
        TiBendSettings BendSettings { get; }

        /// <summary>
        /// Saves the setings.
        /// </summary>
        void Save();

        /// <summary>
        /// Cancels the settings dialog.
        /// </summary>
        void Cancel();
    }
}
