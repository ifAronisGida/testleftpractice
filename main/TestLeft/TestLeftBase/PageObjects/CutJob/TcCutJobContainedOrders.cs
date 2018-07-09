using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using System;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobContainedOrders : PageObject, IChildOf<TcDetailContent>, TiTableRowFactory<TcCutJobOrderRow>
    {
        private readonly Lazy<TcTableView<TcCutJobOrderRow>> mTableView;

        public TcCutJobContainedOrders()
        {
            mTableView = new Lazy<TcTableView<TcCutJobOrderRow>>(() => PartOrdersGrid.GetTableView(this));
        }

        public int PartOrdersCount => PartOrdersGrid.RowCount;

        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail.ContainedOrders" );

        internal TcTruIconButton SelectButton => Find<TcTruIconButton>(Search.ByUid("CutJob.Detail.ContainedOrders.Select"));

        internal TcTruIconButton RemoveButton => Find<TcTruIconButton>(Search.ByUid("CutJob.Detail.ContainedOrders.Remove"));

        private TcGridControl PartOrdersGrid => Find<TcGridControl>(Search.ByUid("CutJob.Detail.ContainedOrders.PartOrders"));

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

        public TcCutJobOrderRow GetRow(int index)
        {
            return mTableView.Value.GetRow(index);
        }

        TcCutJobOrderRow TiTableRowFactory<TcCutJobOrderRow>.WrapRow(TcTableRow underlyingRow)
        {
            return new TcCutJobOrderRow(underlyingRow);
        }
    }
}
