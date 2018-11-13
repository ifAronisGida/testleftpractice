using HomeZone.UiObjectInterfaces.Common;


namespace HomeZone.UiObjectInterfaces.Settings
{
    public interface TiSettingsDialog : TiVisibility
    {
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
