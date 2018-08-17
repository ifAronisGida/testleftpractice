using System;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.Grid
{
    public class TcOptimizedTableRow : ViewControlObject<RowControl>
    {
        private Lazy<IControlObject> mCellsParent;

        public TcOptimizedTableRow()
        {
            mCellsParent = new Lazy<IControlObject>( () => this.FindGeneric( Search.By<CellsControl>(), depth: 1 ) );
        }

        public string GetContent( int columnIndex )
        {
            var content = mCellsParent.Value
                .FindGeneric( Search.By<LightweightCellEditor>().AndByIndex( columnIndex ), depth: 1 )
                .FindGeneric( Search.By<InplaceBaseEdit>(), depth: 1 );

            return content.Node.GetProperty<string>( "DisplayText" );
        }
    }
}
