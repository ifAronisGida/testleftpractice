using System;
using Trumpf.Coparoo.Desktop.WPF;


namespace UiObjects.ControlObjects.Grid
{
    public class TcOptimizedTableView<TRow> : TcTableView<TRow, TcOptimizedTableRow>
    {
        public TcOptimizedTableView( IControlObject gridTableView, Func<TcOptimizedTableRow, TRow> rowWrapper )
            : base( gridTableView, rowWrapper )
        {
        }
    }
}
