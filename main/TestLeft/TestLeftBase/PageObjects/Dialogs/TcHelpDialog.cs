using PageObjectInterfaces.Dialogs;
using Trumpf.PageObjects;
using Trumpf.PageObjects.UIA;

namespace TestLeft.TestLeftBase.PageObjects.Dialogs
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
        /// Waits until PageObject is visible.
        /// </summary>
        /// <returns>true if visible</returns>
        public bool WaitUntilVisible()
        {
            return VisibleOnScreen.TryWaitFor();
        }
    }
}
