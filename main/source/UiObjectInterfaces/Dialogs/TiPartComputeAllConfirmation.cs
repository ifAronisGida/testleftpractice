namespace HomeZone.UiObjectInterfaces.Dialogs
{
    public interface TiPartComputeAllConfirmation
    {
        /// <summary>
        /// Returns true if the dialog box exists.
        /// </summary>
        /// <returns>True if the dialog box exists, otherwise false.</returns>
        bool DialogBoxExists();

        /// <summary>
        /// Clicks the ComputeAll button.
        /// </summary>
        void ComputeAll();

        /// <summary>
        /// Clicks the ComputeIncomplete button.
        /// </summary>
        void ComputeIncompleteAll();

        /// <summary>
        /// Clicks the RefreshAll button.
        /// </summary>
        void RefreshAll();

        /// <summary>
        /// Clicks the Ok button.
        /// </summary>
        void Ok();
    }
}
