using System;
using DevExpress.Xpf.Grid;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.Coparoo.Desktop.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The ControlObject for grid controls. The contents of the grid can be accessed via the GetTableView and GetOptimizedTableView methods,
    /// assuming that the grid uses a table view to display data.
    /// </summary>
    /// <seealso cref="GridControl" />
    public class TcGridControl : ViewControlObject<GridControl>
    {
        protected override Search SearchPattern => Search.Any;

        public int RowCount => Node.GetProperty<int>( "ItemsSource.Count" );
        public int SelectedCount => Node.GetProperty<int>( "SelectedItems.Count" );

        /// <summary>
        /// Returns a table view representing the contents of the grid whose internal table view is not running in optimized mode.
        /// </summary>
        /// <typeparam name="TRow">The type of rows returned by the table view.</typeparam>
        /// <param name="rowWrapper">A function that converts an "untyped" row to strongly-typed row.</param>
        /// <returns>A table view representing the contents of the grid.</returns>
        public TcRegularTableView<TRow> GetTableView<TRow>( Func<TcTableRow, TRow> rowWrapper )
        {
            var tableView = this.FindGeneric( Search.By<TableView>(), depth: 1 );
            return new TcRegularTableView<TRow>( tableView, rowWrapper );
        }

        /// <summary>
        /// Returns a table view representing the contents of the grid whose internal table view is running in optimized mode.
        /// </summary>
        /// <typeparam name="TRow">The type of rows returned by the table view.</typeparam>
        /// <param name="rowWrapper">A function that converts an "untyped" row to strongly-typed row.</param>
        /// <returns>A table view representing the contents of the grid.</returns>
        public TcOptimizedTableView<TRow> GetOptimizedTableView<TRow>( Func<TcOptimizedTableRow, TRow> rowWrapper )
        {
            var tableView = this.FindGeneric( Search.By<TableView>(), depth: 1 );
            return new TcOptimizedTableView<TRow>( tableView, rowWrapper );
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
