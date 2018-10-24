using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;
using UiObjectInterfaces.Dialogs;
using UiObjectInterfaces.PartOrder;
using UiObjects.PageObjects.Dialogs;


namespace UiObjects.PageObjects.PartOrder
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
