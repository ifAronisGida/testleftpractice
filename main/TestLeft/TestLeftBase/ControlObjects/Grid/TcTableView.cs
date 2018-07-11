using System;
using DevExpress.Xpf.Grid;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.Grid
{
    public class TcTableView<TRow> : ViewControlObject<TableView>
    {
        private Lazy<TcHierarchyPanel> mHierarchyPanel;

        public TcTableView()
        {
            mHierarchyPanel = new Lazy<TcHierarchyPanel>(() => Find<TcHierarchyPanel>(depth: 1));
        }

        public Func<TcTableRow, TRow> RowFactory { get; set; }

        public TRow GetRow(int index)
        {
            var row = mHierarchyPanel.Value.Find<TcTableRow>(Search.ByIndex(index), depth: 1);
            return RowFactory(row);
        }
    }
}
