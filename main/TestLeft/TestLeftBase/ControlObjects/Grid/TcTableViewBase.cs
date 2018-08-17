using System;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.Grid
{
    public abstract class TcTableViewBase<TRow, TInternalRow>
    {
        private readonly Lazy<TcHierarchyPanel> mHierarchyPanel;
        private readonly Func<TInternalRow, TRow> mRowWrapper;

        protected TcTableViewBase(IControlObject tableView, Func<TInternalRow, TRow> rowWrapper)
        {
            mHierarchyPanel = new Lazy<TcHierarchyPanel>( () => tableView.Find<TcHierarchyPanel>( depth: 1 ) );
            mRowWrapper = rowWrapper;
        }

        public TRow GetRow( int index )
        {
            var row = GetInternalRow( index, mHierarchyPanel.Value );
            return mRowWrapper( row );
        }

        protected abstract TInternalRow GetInternalRow( int index, IControlObject rowsParent );
    }
}
