using System;
using DevExpress.Xpf.Grid;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using TestLeft.TestLeftBase.ControlObjects.OptimizedGrid;
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

        public int RowCount => Node.GetProperty<int>( "ItemsSource.Count" );
        public int SelectedCount => Node.GetProperty<int>( "SelectedItems.Count" );

        public TcTableView<TRow> GetTableView<TRow>( Func<TcTableRow, TRow> rowFactory )
        {
            var tableView = Find<TcTableView<TRow>>( depth: 1 );

            tableView.RowFactory = rowFactory;

            return tableView;
        }

        public TcOptimizedTableView<TRow> GetOptimizedTableView<TRow>( Func<TcOptimizedTableRow, TRow> rowFactory )
        {
            var tableView = Find<TcOptimizedTableView<TRow>>( depth: 1 );

            tableView.RowFactory = rowFactory;

            return tableView;
        }

        public void UnselectAll()
        {
            Node.CallMethod( "UnselectAll" );
        }

        public void SelectItem( int index )
        {
            if( RowCount > index )
            {
                Node.CallMethod( "SelectItem", index );
            }
        }
    }
}
