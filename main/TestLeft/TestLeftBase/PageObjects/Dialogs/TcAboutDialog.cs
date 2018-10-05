using PageObjectInterfaces.Dialogs;
using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Dialogs
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
    }
}
