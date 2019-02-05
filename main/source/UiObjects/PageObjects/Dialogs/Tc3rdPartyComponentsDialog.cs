using HomeZone.UiObjectInterfaces.Dialogs;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.Dialogs
{
    public class Tc3rdPartyComponentsDialog : PageObject, IChildOf<TcHomeZoneApp>, Ti3rdPartyComponentsDialog
    {
        protected override Search SearchPattern => Search.ByUid( "Tc3rdPartyComponents" );

        /// <summary>
        /// PageObject is visible or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisible => VisibleOnScreen.Value;
    }
}
