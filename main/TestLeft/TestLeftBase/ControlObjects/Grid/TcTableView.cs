using System;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.Grid
{
    public class TcTableView<TRow> : TcTableViewBase<TRow, TcTableRow>
    {
        public TcTableView( IControlObject tableView, Func<TcTableRow, TRow> rowWrapper ) : base( tableView, rowWrapper )
        {
        }

        protected override TcTableRow GetInternalRow( int index, IControlObject rowsParent )
        {
            return rowsParent.Find<TcTableRow>( Search.ByIndex( index ), depth: 1 );
        }
    }
}
