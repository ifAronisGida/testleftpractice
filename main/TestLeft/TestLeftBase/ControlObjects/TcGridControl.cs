using DevExpress.Xpf.Grid;
using SmartBear.TestLeft.TestObjects;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The ControlObject for grid controls.
    /// </summary>
    /// <seealso cref="GridControl" />
    public class TcGridControl : ViewControlObject<GridControl>
    {
        protected override Search SearchPattern => Search.Any;

        public int RowCount => Node.Cast<IGridView>().wRowCount;

        public TcTableView<TRow> GetTableView<TRow>(TiTableRowFactory<TRow> rowFactory)
        {
            var tableView = Find<TcTableView<TRow>>(depth: 1);

            tableView.RowFactory = rowFactory;

            return tableView;
        }

        public void UnselectAll()
        {
            Node.CallMethod( "UnselectAll" );
        }

        public void SelectItem( int index )
        {
            if (RowCount > index)
            {
                Node.CallMethod( "SelectItem", index );
            }
        }
    }
}
