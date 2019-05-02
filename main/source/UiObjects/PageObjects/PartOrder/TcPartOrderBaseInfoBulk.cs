using System;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.PartOrder;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.PartOrder
{
    public class TcPartOrderBaseInfoBulk : TcExpandablePageObject, IChildOf<TcPartOrders>, TiPartOrderBaseInfoBulk
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrderBulk.Detail.Base" );

        public TiValueControl<string> ID => Find<TiValueControl<string>>( "PartOrderBulk.Detail.Base.IdTemplate.Text" );
        public TiValueControl<DateTime?> FinishDate => Find<TiValueControl<DateTime?>>( "PartOrderBulk.Detail.Base.FinishDate.SetValueTo.Date" );
        public TiValueControl<int> QuantityValue => Find<TiValueControl<int>>( "PartOrderBulk.Detail.Base.ChangeQuantity.SetValueTo.SpinEdit" );
        public TiValueControl<int> QuantityFactor => Find<TiValueControl<int>>( "PartOrderBulk.Detail.Base.ChangeQuantity.SetCustom.SpinEdit" );
        public TiValueControl<string> Customer => Find<TiValueControl<string>>( "EditCustomerProperty.EditValue" );
    }
}
