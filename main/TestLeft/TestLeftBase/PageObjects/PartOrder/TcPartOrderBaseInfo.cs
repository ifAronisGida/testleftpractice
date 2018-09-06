using System;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrderBaseInfo : PageObject, IChildOf<TcPartOrders>
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrder.Detail.Base" );

        private readonly Lazy<MoreProps> mMoreProps;

        public TcPartOrderBaseInfo()
        {
            this.mMoreProps = new Lazy<MoreProps>( () => new MoreProps( this ) );
        }

        public TiSimpleValue<string> ID => Find<TcTextEdit>( Search.ByUid( "PartOrder.Detail.Base.Name" ) );
        public TiSimpleValue<string> Customer => Find<TcLookUpEdit>( Search.ByUid( "EditCustomerProperty.EditValue" ) );
        public TiSimpleValue<DateTime?> FinishDate => Find<TcDateEdit>( Search.ByUid( "PartOrder.Detail.Base.FinishDate" ) );
        public TiSimpleValue<int> Quantity => Find<TcSpinEdit>( Search.ByUid( "PartOrder.Detail.Base.TargetQuantity" ) );

        public MoreProps More => mMoreProps.Value;

        public bool IsMoreExpanded
        {
            get => Node.GetProperty<bool>( "IsMoreExpanded" );
            set => Node.SetProperty( "IsMoreExpanded", value );
        }

        public class MoreProps
        {
            private readonly PageObject page;

            public MoreProps( PageObject page )
            {
                this.page = page;
            }

            public TiSimpleValue<string> RawMaterial => page.Find<TcReadOnlyText>( Search.ByUid( "PartOrder.Detail.Base.More.RawMaterial" ) );
            public TiSimpleValue<bool> IsFiller => page.Find<TcCheckBox>( Search.ByUid( "PartOrder.Detail.Base.More.FillerPartOrder" ) );
            public TiSimpleValue<string> CustomerOrderNumber => page.Find<TcTextEdit>( Search.ByUid( "PartOrder.Detail.Base.CustomerPartOrderNumber" ) );
            public TiSimpleValue<string> OrderCategory => page.Find<TcTextEdit>( Search.ByUid( "PartOrder.Detail.Base.Category" ) );
            public TiSimpleValue<string> ExternalAssembly => page.Find<TcTextEdit>( Search.ByUid( "PartOrder.Detail.Base.AssemblyOrderName" ) );
            public TiSimpleValue<bool> IsArchivable => page.Find<TcCheckBox>( Search.ByUid( "PartOrder.Detail.Base.Archivable" ) );
        }
    }
}
