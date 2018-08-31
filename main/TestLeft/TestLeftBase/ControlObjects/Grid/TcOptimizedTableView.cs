using System;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.Grid
{
    public class TcOptimizedTableView<TRow> : TcTableView<TRow, TcOptimizedTableRow>
    {
        public TcOptimizedTableView( IControlObject gridTableView, Func<TcOptimizedTableRow, TRow> rowWrapper )
            : base( gridTableView, rowWrapper )
        {
        }
    }
}
