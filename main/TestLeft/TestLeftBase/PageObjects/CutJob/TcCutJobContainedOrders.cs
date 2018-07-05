using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.ControlObjects.Grid;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobContainedOrders : PageObject, IChildOf<TcDetailContent>, TiTableRowFactory<TcCutJobOrderRow>
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail.ContainedOrders" );

        public TcTableView<TcCutJobOrderRow> TableView => PartOrdersGrid.GetTableView(this);

        internal TcTruIconButton SelectButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.ContainedOrders.Select" ) );

        internal TcTruIconButton RemoveButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.ContainedOrders.Remove" ) );

        internal TcGridControl PartOrdersGrid => Find<TcGridControl>( Search.ByUid( "CutJob.Detail.ContainedOrders.PartOrders" ) );

        public int PartOrdersCount
        {
            get
            {
                return PartOrdersGrid.RowCount;
            }
        }

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

        TcCutJobOrderRow TiTableRowFactory<TcCutJobOrderRow>.WrapRow(TcTableRow underlyingRow)
        {
            return new TcCutJobOrderRow(underlyingRow);
        }
    }
}
