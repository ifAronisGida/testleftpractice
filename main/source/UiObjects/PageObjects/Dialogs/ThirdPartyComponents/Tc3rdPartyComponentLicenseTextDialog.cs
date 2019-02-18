using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Dialogs.ThirdPartyComponents;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.Dialogs.ThirdPartyComponents
{
    public class Tc3rdPartyComponentLicenseTextDialog : TcPageObjectBase, IChildOf<TcHomeZoneApp>, Ti3rdPartyComponentLicenseTextDialog
    {
        protected override Search SearchPattern => Search.ByUid( "Tc3rdPartyComponentLicenseText" );

        private TiButton OkButton => Find<TiButton>( "OkButton" );

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        public void Close()
        {
            OkButton.Click();
        }
    }
}
