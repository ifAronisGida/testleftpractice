using System;
using DevExpress.Xpf.Grid;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using TestLeft.TestLeftBase.Utilities;
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

        public TcTableView<TRow> GetTableView<TRow>( Func<TcTableRow, TRow> rowWrapper )
        {
            var tableView = this.FindGeneric( Search.By<TableView>(), depth: 1 );
            return new TcTableView<TRow>( tableView, rowWrapper );
        }

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
