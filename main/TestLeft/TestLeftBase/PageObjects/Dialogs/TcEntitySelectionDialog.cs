using PageObjectInterfaces.Controls;
using PageObjectInterfaces.Dialogs;
using SmartBear.TestLeft.TestObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects.Composite;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Dialogs
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
