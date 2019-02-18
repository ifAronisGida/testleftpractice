using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.Dialogs.ThirdPartyComponents
{
    public interface Ti3rdPartyComponentsDialog : TiVisibility
    {
        int HomeZoneLicenseCount { get; }

        //Ti3rdPartyComponentRow GetHomeZoneLicenseRow( int row );

        Ti3rdPartyComponentLicenseTextDialog ShowLicenseText();

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        void Close();
    }
}
