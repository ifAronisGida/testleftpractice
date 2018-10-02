using PageObjectInterfaces.Controls;
using PageObjectInterfaces.PartOrder;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrderPartInfo : TcPageObjectBase, TiPartOrderPartInfo
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrder.Detail.OrderedPart.Info" );

        private TiButton SelectPartButton => Find<TiButton>( "PartOrder.Detail.OrderedPart.Select" );

        public void SelectPart( string partId )
        {
            SelectPartButton.Click();
            On<TcEntitySelectionDialog>().SelectClose( partId );
        }
    }
}
