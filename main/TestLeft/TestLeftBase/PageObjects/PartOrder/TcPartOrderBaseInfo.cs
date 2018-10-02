using System;
using PageObjectInterfaces.Controls;
using PageObjectInterfaces.PartOrder;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrderBaseInfo : TcPageObjectBase, IChildOf<TcPartOrders>, TiPartOrderBaseInfo
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrder.Detail.Base" );

        public TiValueControl<string> ID => Find<TiValueControl<string>>( "PartOrder.Detail.Base.Name" );
        public TiValueControl<string> Customer => Find<TiValueControl<string>>( "EditCustomerProperty.EditValue" );
        public TiValueControl<DateTime?> FinishDate => Find<TiValueControl<DateTime?>>( "PartOrder.Detail.Base.FinishDate" );
        public TiValueControl<int> Quantity => Find<TiValueControl<int>>( "PartOrder.Detail.Base.TargetQuantity" );

        public TiValueControl<string> CustomerOrderNumber
        {
            get
            {
                IsMoreExpanded = true;
                return Find<TiValueControl<string>>( "PartOrder.Detail.Base.CustomerPartOrderNumber" );
            }
        }

        public TiValueControl<string> ExternalAssembly
        {
            get
            {
                IsMoreExpanded = true;
                return Find<TiValueControl<string>>( "PartOrder.Detail.Base.AssemblyOrderName" );
            }
        }

        public TiValueControl<bool> IsArchivable
        {
            get
            {
                IsMoreExpanded = true;
                return Find<TiValueControl<bool>>( "PartOrder.Detail.Base.Archivable" );
            }
        }

        public TiValueControl<bool> IsFiller
        {
            get
            {
                IsMoreExpanded = true;
                return Find<TiValueControl<bool>>( "PartOrder.Detail.Base.More.FillerPartOrder" );
            }
        }

        public TiValueControl<string> OrderCategory
        {
            get
            {
                IsMoreExpanded = true;
                return Find<TiValueControl<string>>( "PartOrder.Detail.Base.Category" );
            }
        }

        public TiValueControl<string> RawMaterial
        {
            get
            {
                IsMoreExpanded = true;
                return Find<TiValueControl<string>>( "PartOrder.Detail.Base.More.RawMaterial" );
            }
        }

        private bool IsMoreExpanded
        {
            get => Node.GetProperty<bool>( "IsMoreExpanded" );
            set => Node.SetProperty( "IsMoreExpanded", value );
        }
    }
}
