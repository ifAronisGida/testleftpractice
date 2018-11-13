using System;
using Trumpf.Coparoo.Desktop.WPF;


namespace HomeZone.UiObjects.ControlObjects.Grid
{
    public class TcRegularTableView<TRow> : TcTableView<TRow, TcTableRow>
    {
        public TcRegularTableView( IControlObject gridTableView, Func<TcTableRow, TRow> rowWrapper )
            : base( gridTableView, rowWrapper )
        {
        }
    }
}
