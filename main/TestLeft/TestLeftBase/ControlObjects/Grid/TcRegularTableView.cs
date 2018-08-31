using System;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.Grid
{
    public class TcRegularTableView<TRow> : TcTableView<TRow, TcTableRow>
    {
        public TcRegularTableView( IControlObject gridTableView, Func<TcTableRow, TRow> rowWrapper )
            : base( gridTableView, rowWrapper )
        {
        }
    }
}
