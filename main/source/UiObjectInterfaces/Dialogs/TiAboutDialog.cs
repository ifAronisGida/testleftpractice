using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.Dialogs
{
    public interface TiAboutDialog : TiVisibility
    {
        /// <summary>
        /// Closes the about dialog.
        /// </summary>
        void CopyToClipboard();

        /// <summary>
        /// Closes the about dialog.
        /// </summary>
        void Close();
    }
}
