using System;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.Grid
{
    public class TcOptimizedTableView<TRow> : TcTableViewBase<TRow, TcOptimizedTableRow>
    {
        public TcOptimizedTableView( IControlObject tableView, Func<TcOptimizedTableRow, TRow> rowWrapper ) : base( tableView, rowWrapper )
        {
        }

        protected override TcOptimizedTableRow GetInternalRow( int index, IControlObject rowsParent )
        {
            return rowsParent.Find<TcOptimizedTableRow>( Search.ByIndex( index ), depth: 1 );
        }
    }
}
