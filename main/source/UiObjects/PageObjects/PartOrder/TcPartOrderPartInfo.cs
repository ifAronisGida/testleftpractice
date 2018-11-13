using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Dialogs;
using HomeZone.UiObjectInterfaces.PartOrder;
using HomeZone.UiObjects.PageObjects.Dialogs;

namespace HomeZone.UiObjects.PageObjects.PartOrder
{
    public class TcPartOrderPartInfo : TcPageObjectBase, IChildOf<TcPartOrders>, TiPartOrderPartInfo
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrder.Detail.OrderedPart.Info" );

        private TiButton SelectPartButton => Find<TiButton>( "PartOrder.Detail.OrderedPart.Select" );

        public void SelectPart( string partId )
        {
            SelectPartButton.Click();
            On<TiEntitySelectionDialog, TcEntitySelectionDialog>().SelectClose( partId );
        }
    }
}
