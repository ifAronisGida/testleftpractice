using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.PartOrder;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.PartOrder
{
    public class TcPartOrderBulkPartBend : TcPageObjectBase, IChildOf<TcPartOrders>, TiPartOrderBulkPartBend
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrderBulk.Detail.Bend" );
        public TiValueControl<string> BendingProgram => Find<TiValueControl<string>>( "PartOrderBulk.Detail.Bend.BendingProgram.Selection" );
    }
}
