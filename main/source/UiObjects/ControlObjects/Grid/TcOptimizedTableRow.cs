using System;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjects.Utilities;
using System.Windows.Controls;
using SmartBear.TestLeft.TestObjects;

namespace HomeZone.UiObjects.ControlObjects.Grid
{
    /// <summary>
    /// Represents a row in a grid table view running in optimized mode.
    /// This class assumes that the cell contents are always textual.
    /// </summary>
    public class TcOptimizedTableRow : ControlObject
    {
        private Lazy<IControlObject> mCellsParent;

        public TcOptimizedTableRow()
        {
            mCellsParent = new Lazy<IControlObject>( () => this.FindGeneric( SearchEx.ByClass(DevExpress.CellsControl), depth: 1 ) );
        }

        protected override Search SearchPattern => SearchEx.ByClass( DevExpress.RowControl );

        /// <summary>
        /// Returns the content of a cell at the given index.
        /// </summary>
        /// <param name="columnIndex">The zero-based index of the column in the row.</param>
        /// <returns></returns>
        public string GetContent( int columnIndex )
        {
            var content = mCellsParent.Value
                .FindGeneric( SearchEx.ByClass( DevExpress.LightweightCellEditor ).AndByIndex( columnIndex ), depth: 1 )
                .FindGeneric( SearchEx.ByClass(
                    $"regexp:({DevExpress.InplaceBaseEdit.Replace(".", "\\.")})|" + 
                    $"({typeof(TextBlock).FullName.Replace(".", "\\.")})" ), depth: 2 );

            try
            {
                return content.Node.GetProperty<string>( "DisplayText" );
            }
            catch ( InvocationException )
            {
                return content.Node.GetProperty<string>( "Text" );
            }
        }
    }
}
