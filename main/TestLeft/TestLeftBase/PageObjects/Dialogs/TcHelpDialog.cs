using Trumpf.PageObjects;
using Trumpf.PageObjects.UIA;

namespace TestLeft.TestLeftBase.PageObjects.Dialogs
{
    /// <summary>
    /// PageObject for the Help app.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    public class TcHelpDialog : PageObject, IChildOf<TcHomeZoneApp>
    {
        protected override Search SearchPattern => Search.ByObjectIdentifier( "TruTops_Boost" );

        /// <summary>
        /// Closes the help window.
        /// </summary>
        public void Close()
        {
            Node.CallMethod( "Close" );
        }

    }
}
