using HomeZone.UiObjectInterfaces.Common;
using HomeZone.UiObjectInterfaces.Dialogs.ThirdPartyComponents;


namespace HomeZone.UiObjectInterfaces.Dialogs
{
    public interface TiAboutDialog : TiVisibility
    {
        void ShowVersionInfo();
        Ti3rdPartyComponentsDialog ShowThirdPartyComponents();

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
