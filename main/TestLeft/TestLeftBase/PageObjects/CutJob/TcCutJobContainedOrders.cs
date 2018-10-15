using System;
using PageObjectInterfaces.Controls;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using PageObjectInterfaces.CutJob;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobContainedOrders : TcPageObjectBase, IChildOf<TcDetailContent>, TiCutJobContainedOrders
    {
        private readonly Lazy<TcRegularTableView<TcCutJobOrderRow>> mTableView;

        public TcCutJobContainedOrders()
        {
            mTableView = new Lazy<TcRegularTableView<TcCutJobOrderRow>>( () => PartOrdersGrid.GetTableView( underlyingRow => new TcCutJobOrderRow( underlyingRow ) ) );
        }

        public int PartOrdersCount => PartOrdersGrid.RowCount;

        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail.ContainedOrders" );

        private TiButton AddOrderButton => Find<TiButton>( "CutJob.Detail.ContainedOrders.Select" );
        private TiButton RemoveButton => Find<TiButton>( "CutJob.Detail.ContainedOrders.Remove" );
        private TcGridControl PartOrdersGrid => Find<TcGridControl>( Search.ByUid( "CutJob.Detail.ContainedOrders.PartOrders" ) );

        public void UnSelectAllPartOrders()
        {
            PartOrdersGrid.UnselectAll();
        }

        public void SelectPartOrder( int index )
        {
            PartOrdersGrid.SelectItem( index );
        }

        public void AddPartOrder(string orderId)
        {
            AddOrderButton.Click();
            On<TcEntitySelectionDialog>().SelectClose( orderId );
        }

        public void RemovePartOrder()
        {
            if( RemoveButton.Enabled )
            {
                RemoveButton.Click();

                var dialog = On<TcMessageBox>();
                if( dialog.MessageBoxExists() )
                {
                    dialog.Yes();
                }
            }
        }

        public TiCutJobOrderRow GetRow( int index )
        {
            return mTableView.Value.GetRow( index );
        }
    }
}
