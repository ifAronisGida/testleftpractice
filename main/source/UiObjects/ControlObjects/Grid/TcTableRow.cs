using System;
using DevExpress.Xpf.Grid;
using Trumpf.Coparoo.Desktop.WPF;


namespace HomeZone.UiObjects.ControlObjects.Grid
{
    /// <summary>
    /// Represents a row in a grid table view.
    /// </summary>
    public class TcTableRow : ViewControlObject<GridRow>
    {
        private Lazy<TcBandedViewContentSelector> mViewContentSelector;

        public TcTableRow()
        {
            mViewContentSelector = new Lazy<TcBandedViewContentSelector>( () => Find<TcBandedViewContentSelector>( depth: 1 ) );
        }

        /// <summary>
        /// Returns the cell as an IControlObject at the given column index.
        /// </summary>
        /// <param name="columnIndex">The zero-based index of the column.</param>
        /// <returns></returns>
        public IControlObject GetCell( int columnIndex )
        {
            return mViewContentSelector.Value.Find<TcGridCellContentPresenter>( Search.ByIndex( columnIndex ), depth: 1 );
        }
    }
}
