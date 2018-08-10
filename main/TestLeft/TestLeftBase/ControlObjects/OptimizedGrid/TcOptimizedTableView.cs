using System;
using DevExpress.Xpf.Grid;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.OptimizedGrid
{
    // TODO: this shares almost everything with TcTableView
    public class TcOptimizedTableView<TRow> : ViewControlObject<TableView>
    {
        private Lazy<TcHierarchyPanel> mHierarchyPanel;

        public TcOptimizedTableView()
        {
            mHierarchyPanel = new Lazy<TcHierarchyPanel>( () => Find<TcHierarchyPanel>( depth: 1 ) );
        }

        public Func<TcOptimizedTableRow, TRow> RowFactory { get; set; }

        public TRow GetRow( int index )
        {
            var row = mHierarchyPanel.Value.Find<TcOptimizedTableRow>( Search.ByIndex( index ), depth: 1 );
            return RowFactory( row );
        }
    }
}
