using SmartBear.TestLeft.TestObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.ControlObjects.Composite;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Dialogs
{
    public class TcEntitySelectionDialog : PageObject, IChildOf<TcHomeZoneApp>
    {
        protected override Search SearchPattern => Search.By(new WPFPattern()
        {
            ClrFullClassName = "Trumpf.TruTops.Control.Infrastructure.ModuleBase.Views.TcEntitySelectionDialogView"
        } );

        private TcButton CancelButton => Find<TcButton>( Search.ByControlName( "CancelButton" ) );
        private TcButton OkButton => Find<TcButton>( Search.ByControlName( "OkButton" ) );
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
