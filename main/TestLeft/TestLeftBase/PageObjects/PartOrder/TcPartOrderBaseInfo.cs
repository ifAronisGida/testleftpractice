using System;
using PageObjectInterfaces.Controls;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrderBaseInfo : TcPageObjectBase, IChildOf<TcPartOrders>
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrder.Detail.Base" );

        private readonly Lazy<MoreProps> mMoreProps;

        public TcPartOrderBaseInfo()
        {
            this.mMoreProps = new Lazy<MoreProps>( () => new MoreProps( this ) );
        }

        public TiValueControl<string> ID => Find<TiValueControl<string>>( "PartOrder.Detail.Base.Name" );
        public TiValueControl<string> Customer => Find<TiValueControl<string>>( "EditCustomerProperty.EditValue" );
        public TiValueControl<DateTime?> FinishDate => Find<TiValueControl<DateTime?>>( "PartOrder.Detail.Base.FinishDate" );
        public TiValueControl<int> Quantity => Find<TiValueControl<int>>( "PartOrder.Detail.Base.TargetQuantity" );

        public MoreProps More => mMoreProps.Value;

        public bool IsMoreExpanded
        {
            get => Node.GetProperty<bool>( "IsMoreExpanded" );
            set => Node.SetProperty( "IsMoreExpanded", value );
        }

        public class MoreProps
        {
            private readonly TcPageObjectBase page;

            internal MoreProps( TcPageObjectBase page )
            {
                this.page = page;
            }

            public TiValueControl<string> RawMaterial => page.Find<TiValueControl<string>>( "PartOrder.Detail.Base.More.RawMaterial" );
            public TiValueControl<bool> IsFiller => page.Find<TiValueControl<bool>>( "PartOrder.Detail.Base.More.FillerPartOrder" );
            public TiValueControl<string> CustomerOrderNumber => page.Find<TiValueControl<string>>( "PartOrder.Detail.Base.CustomerPartOrderNumber" );
            public TiValueControl<string> OrderCategory => page.Find<TiValueControl<string>>( "PartOrder.Detail.Base.Category" );
            public TiValueControl<string> ExternalAssembly => page.Find<TiValueControl<string>>( "PartOrder.Detail.Base.AssemblyOrderName" );
            public TiValueControl<bool> IsArchivable => page.Find<TiValueControl<bool>>( "PartOrder.Detail.Base.Archivable" );
        }
    }
}
