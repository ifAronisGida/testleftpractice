using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.UIA;
using UiObjectInterfaces.Dialogs;


namespace UiObjects.PageObjects.Dialogs
{
    /// <summary>
    /// PageObject for the Help app.
    /// </summary>
    /// We can not use TcPageObjectBase as base class, because it uses Trumpf.PageObjects.WPF
    /// and we need Trumpf.PageObjects.UIA for this dialog.
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    public class TcHelpDialog : PageObject, IChildOf<TcHomeZoneApp>, TiHelpDialog
    {
        protected override Search SearchPattern => Search.ByObjectIdentifier( "TruTops_Boost" );

        /// <summary>
        /// Closes the help window.
        /// </summary>
        public void Close()
        {
            Node.CallMethod( "Close" );
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
