using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Dialogs;


namespace HomeZone.UiObjects.PageObjects.Dialogs
{
    /// <summary>
    /// TcMessageBox is used to handle message boxes.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.WPF.PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    internal class TcMessageBox : PageObject, IChildOf<TcHomeZoneApp>, TiMessageBox
    {
        protected override Search SearchPattern => Search.Any;

        private IControl mMessageBox;

        internal IControl MessageBox
        {
            get
            {
                if( mMessageBox == null )
                {
                    Parent.Node.TryFind<IControl>( new WPFPattern { Uid = "TcMessageBox" }, out mMessageBox, 2 );
                }

                return mMessageBox;
            }
        }

        internal IButton YesButton => MessageBox.Find<IButton>( new WPFPattern { Uid = "Yes" }, 3 );
        internal IButton NoButton => MessageBox.Find<IButton>( new WPFPattern { Uid = "No" }, 3 );
        internal IButton CancelButton => MessageBox.Find<IButton>( new WPFPattern { Uid = "Cancel" }, 3 );
        internal IButton OkButton => MessageBox.Find<IButton>( new WPFPattern { Uid = "Ok" }, 3 );
        internal IButton CloseButton => MessageBox.Find<IButton>( new WPFPattern { Uid = "Close" }, 3 );
        internal IButton CopyToClipboardButton => MessageBox.Find<IButton>( new WPFPattern { Uid = "CopyToClipboard" }, 3 );

        /// <summary>
        /// Returns true if a message box exists.
        /// </summary>
        /// <returns>True if a message box exists, otherwise false.</returns>
        public bool MessageBoxExists()
        {
            return MessageBox != null;
        }

        /// <summary>
        /// Clicks the yes button.
        /// </summary>
        public void Yes()
        {
            YesButton.Click();
        }

        public void Ok()
        {
            OkButton.Click();
        }
    }
}
