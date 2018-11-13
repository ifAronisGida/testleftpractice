using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Dialogs;
using HomeZone.UiObjects.ControlObjects.Composite;

namespace HomeZone.UiObjects.PageObjects.Dialogs
{
    public class TcEntitySelectionDialog : TcPageObjectBase, IChildOf<TcHomeZoneApp>, TiEntitySelectionDialog
    {
        protected override Search SearchPattern => Search.By(new WPFPattern()
        {
            ClrFullClassName = "Trumpf.TruTops.Control.Infrastructure.ModuleBase.Views.TcEntitySelectionDialogView"
        } );

        private TiButton CancelButton => FindByControlName<TiButton>( "CancelButton" );
        private TiButton OkButton => FindByControlName<TiButton>( "OkButton" );
        private TcResultColumn ResultColumn => Find<TcResultColumn>( Search.ByControlName( "ResultColumn" ) );

        public void Cancel()
        {
            CancelButton.Click();
        }

        public void Ok()
        {
            OkButton.Click();
        }

        public bool SelectClose(string entityId)
        {
            if( !ResultColumn.SelectItem( entityId ) )
            {
                return false;
            }

            Ok();
            return true;
        }
    }
}
