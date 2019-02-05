using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Dialogs;

namespace HomeZone.UiObjects.PageObjects.Dialogs
{
    /// <summary>
    /// PageObject for the Help app.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    public class TcAboutDialog : PageObject, IChildOf<TcHomeZoneApp>, TiAboutDialog
    {
        protected override Search SearchPattern => Search.ByUid( "AboutDialog" );

        internal IButton CopyToClipboardButton => Node.Find<IButton>( Search.ByUid( "CopyToClipboardButton" ), 2 );
        internal IButton OkButton => Node.Find<IButton>( Search.ByUid( "OkButton" ), 3 );

        /// <summary>
        /// Closes the about dialog.
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

        /// <summary>
        /// PageObject is visible or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisible => VisibleOnScreen.Value;
    }
}
