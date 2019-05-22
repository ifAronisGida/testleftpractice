using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Dialogs;
using HomeZone.UiObjects.Utilities;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.Dialogs
{
    public class TcErrorBox : TcPageObjectBase, IChildOf<TcHomeZoneApp>, TiErrorBox
    {
        protected override Search SearchPattern =>
            SearchEx.ByClass( "Trumpf.TruTops.Common.Infrastructure.TruCustomControls.TcErrorBox" )
            .AndByIndex( 0 );

        private TiButton OkButton => FindByControlName<TiButton>( "btnOK" );

        public void Ok()
        {
            OkButton.Click();
        }
    }
}
