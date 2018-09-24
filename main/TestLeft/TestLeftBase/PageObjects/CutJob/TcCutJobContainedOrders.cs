using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.Utilities;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobContainedOrders : PageObject, IChildOf<TcDetailContent>
    {
        private readonly Lazy<TcRegularTableView<TcCutJobOrderRow>> mTableView;

        public TcCutJobContainedOrders()
        {
            mTableView = new Lazy<TcRegularTableView<TcCutJobOrderRow>>( () => PartOrdersGrid.GetTableView( underlyingRow => new TcCutJobOrderRow( underlyingRow ) ) );
        }

        public int PartOrdersCount => PartOrdersGrid.RowCount;

        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail.ContainedOrders" );

        private TiButton SelectButton => this.FindGeneric<TiButton>( "CutJob.Detail.ContainedOrders.Select" );
        private TiButton RemoveButton => this.FindGeneric<TiButton>( "CutJob.Detail.ContainedOrders.Remove" );
        private TcGridControl PartOrdersGrid => Find<TcGridControl>( Search.ByUid( "CutJob.Detail.ContainedOrders.PartOrders" ) );

        public void UnSelectAllPartOrders()
        {
            PartOrdersGrid.UnselectAll();
        }

        public void SelectPartOrder( int index )
        {
            PartOrdersGrid.SelectItem( index );
        }

        public void AddPartOrder()
        {
            SelectButton.Click();
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

        public TcCutJobOrderRow GetRow( int index )
        {
            return mTableView.Value.GetRow( index );
        }
    }
}
