using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.PartOrder;
using HomeZone.UiObjects.PageObjects.Dialogs;
using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjects.PageObjects.Part;

namespace HomeZone.UiObjects.PageObjects.PartOrder
{
    public class TcPartOrderPartInfo : TcPageObjectBase, IChildOf<TcPartOrders>, TiPartOrderPartInfo
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrder.Detail.OrderedPart.Info" );

        private TiButton SelectPartButton => Find<TiButton>( "PartOrder.Detail.OrderedPart.Select" );

        public TiPartSingleDetailDesign Design => On<TcPartSingleDetailDesign>();

        public void SelectPart( string partId )
        {
            SelectPartButton.Click();
            On<TcEntitySelectionDialog>().SelectClose( partId );
        }
    }
}
