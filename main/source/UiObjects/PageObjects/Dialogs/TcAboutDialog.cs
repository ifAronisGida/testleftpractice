using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Dialogs;
using HomeZone.UiObjectInterfaces.Dialogs.ThirdPartyComponents;
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.PageObjects.Dialogs.ThirdPartyComponents;


namespace HomeZone.UiObjects.PageObjects.Dialogs
{
    /// <summary>
    /// PageObject for the Help app.
    /// </summary>
    /// <seealso cref="TcPageObjectBase" />
    /// <seealso cref="IChildOf{T}" />
    public class TcAboutDialog : TcPageObjectBase, IChildOf<TcHomeZoneApp>, TiAboutDialog
    {
        protected override Search SearchPattern => Search.ByUid( "AboutDialog" );

        internal TcButton ShowVersionInfoButton => Find<TcButton>( "ShowVersionInfoButton", depth: 6 );
        internal TcButton ShowThirdPartyButton => Find<TcButton>( "ShowThirdPartyButton", depth: 6 );
        internal TcButton CopyToClipboardButton => Find<TcButton>( "CopyToClipboardButton", depth: 2 );
        internal TcButton OkButton => Find<TcButton>( "OkButton", depth: 3 );

        public void ShowVersionInfo()
        {
            ShowVersionInfoButton.Click();
        }

        public Ti3rdPartyComponentsDialog ShowThirdPartyComponents()
        {
            ShowThirdPartyButton.Click();
            return On<Tc3rdPartyComponentsDialog>();
        }

        /// <summary>
        /// Copy info to clipboard.
        /// </summary>
        public void CopyToClipboard()
        {
            CopyToClipboardButton.Click();
        }

        /// <summary>
        /// Closes the about dialog.
        /// </summary>
        public void Close()
        {
            OkButton.Click();
        }
    }
}
