using System;
using PageObjectInterfaces.Controls;
using PageObjectInterfaces.PartOrder;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrderBaseInfo : TcExpandablePageObject, IChildOf<TcPartOrders>, TiPartOrderBaseInfo
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrder.Detail.Base" );

        public TiValueControl<string> ID => Find<TiValueControl<string>>( "PartOrder.Detail.Base.Name" );
        public TiValueControl<string> Customer => Find<TiValueControl<string>>( "EditCustomerProperty.EditValue" );
        public TiValueControl<DateTime?> FinishDate => Find<TiValueControl<DateTime?>>( "PartOrder.Detail.Base.FinishDate" );
        public TiValueControl<int> Quantity => Find<TiValueControl<int>>( "PartOrder.Detail.Base.TargetQuantity" );

        public TiValueControl<string> RawMaterial => Find<TiValueControl<string>>( "PartOrder.Detail.Base.More.RawMaterial", expandOnAccess: true );
        public TiValueControl<bool> IsFiller => Find<TiValueControl<bool>>( "PartOrder.Detail.Base.More.FillerPartOrder", expandOnAccess: true );
        public TiValueControl<string> CustomerOrderNumber => Find<TiValueControl<string>>( "PartOrder.Detail.Base.CustomerPartOrderNumber", expandOnAccess: true );
        public TiValueControl<string> OrderCategory => Find<TiValueControl<string>>( "PartOrder.Detail.Base.Category", expandOnAccess: true );
        public TiValueControl<string> ExternalAssembly => Find<TiValueControl<string>>( "PartOrder.Detail.Base.AssemblyOrderName", expandOnAccess: true );
        public TiValueControl<bool> IsArchivable => Find<TiValueControl<bool>>( "PartOrder.Detail.Base.Archivable", expandOnAccess: true );
    }
}
