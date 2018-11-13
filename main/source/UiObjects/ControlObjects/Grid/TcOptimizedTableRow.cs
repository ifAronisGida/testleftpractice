using System;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjects.Utilities;

namespace HomeZone.UiObjects.ControlObjects.Grid
{
    /// <summary>
    /// Represents a row in a grid table view running in optimized mode.
    /// This class assumes that the cell contents are always textual.
    /// </summary>
    public class TcOptimizedTableRow : ViewControlObject<RowControl>
    {
        private Lazy<IControlObject> mCellsParent;

        public TcOptimizedTableRow()
        {
            mCellsParent = new Lazy<IControlObject>( () => this.FindGeneric( Search.By<CellsControl>(), depth: 1 ) );
        }

        /// <summary>
        /// Returns the content of a cell at the given index.
        /// </summary>
        /// <param name="columnIndex">The zero-based index of the column in the row.</param>
        /// <returns></returns>
        public string GetContent( int columnIndex )
        {
            var content = mCellsParent.Value
                .FindGeneric( Search.By<LightweightCellEditor>().AndByIndex( columnIndex ), depth: 1 )
                .FindGeneric( Search.By<InplaceBaseEdit>(), depth: 1 );

            return content.Node.GetProperty<string>( "DisplayText" );
        }
    }
}
