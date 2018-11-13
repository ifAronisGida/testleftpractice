using System;
using Trumpf.Coparoo.Desktop.WPF;


namespace HomeZone.UiObjects.ControlObjects.Grid
{
    /// <summary>
    /// Wraps a DevExpress.Xpf.Grid.TableView object and creates "strongly-typed" rows.
    /// </summary>
    /// <typeparam name="TRow">The type of returned custom row object.</typeparam>
    /// <typeparam name="TInternalRow">The type of control object representing the UI rows in the table view.</typeparam>
    public class TcTableView<TRow, TInternalRow> where TInternalRow : IControlObject
    {
        private readonly Lazy<TcHierarchyPanel> mHierarchyPanel;
        private readonly Func<TInternalRow, TRow> mRowWrapper;

        /// <summary>
        /// Initializes an instance of the TcTableView class.
        /// </summary>
        /// <param name="gridTableView">The control object for the DevExpress TableView object.</param>
        /// <param name="rowWrapper">A function that converts an "untyped" row to strongly-typed row.</param>
        public TcTableView( IControlObject gridTableView, Func<TInternalRow, TRow> rowWrapper )
        {
            mHierarchyPanel = new Lazy<TcHierarchyPanel>( () => gridTableView.Find<TcHierarchyPanel>( depth: 1 ) );
            mRowWrapper = rowWrapper;
        }

        /// <summary>
        /// Returns the row at the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the row.</param>
        /// <returns>The row at the given index.</returns>
        public TRow GetRow( int index )
        {
            var row = GetInternalRow( index );
            return mRowWrapper( row );
        }

        private TInternalRow GetInternalRow( int index )
        {
            return mHierarchyPanel.Value.Find<TInternalRow>( Search.ByIndex( index ), depth: 1 );
        }
    }
}
