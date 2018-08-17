using System;
using DevExpress.Xpf.Grid;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.Grid
{
    public class TcTableRow : ViewControlObject<GridRow>
    {
        private Lazy<TcBandedViewContentSelector> mViewContentSelector;

        public TcTableRow()
        {
            mViewContentSelector = new Lazy<TcBandedViewContentSelector>( () => Find<TcBandedViewContentSelector>( depth: 1 ) );
        }

        public IControlObject GetCell( int columnIndex )
        {
            return mViewContentSelector.Value.Find<TcGridCellContentPresenter>( Search.ByIndex( columnIndex ), depth: 1 );
        }
    }
}
