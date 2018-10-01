namespace PageObjectInterfaces.Settings
{
    public interface TiBendSettings
    {
        /// <summary>
        /// Opens the Flux tools configuration dialog.
        /// </summary>
        void OpenToolsConfiguration();

        /// <summary>
        /// Opens the Flux tool lists configuration dialog.
        /// </summary>
        void OpenToolListsConfiguration();

        /// <summary>
        /// Opens the Flux vebd deduction configuration dialog.
        /// </summary>
        void OpenBendDeductionConfiguration();

        /// <summary>
        /// Opens the Flux app settings configuration dialog.
        /// </summary>
        void OpenAppSettingsConfiguration();

        /// <summary>
        /// Opens the data manager bend.
        /// </summary>
        void OpenDataManagerBend();

        /// <summary>
        /// Waits until visible.
        /// </summary>
        /// <returns>true if visible</returns>
        bool WaitUntilVisible();
    }
}
