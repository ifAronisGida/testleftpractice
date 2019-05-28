namespace HomeZone.UiObjectInterfaces.Dialogs
{
    public interface TiMessageBox 
    {
        /// <summary>
        /// Returns true if a message box exists.
        /// </summary>
        /// <returns>True if a message box exists, otherwise false.</returns>
        bool MessageBoxExists();

        /// <summary>
        /// Clicks the yes button.
        /// </summary>
        void Yes();

        void Ok();
    }
}
