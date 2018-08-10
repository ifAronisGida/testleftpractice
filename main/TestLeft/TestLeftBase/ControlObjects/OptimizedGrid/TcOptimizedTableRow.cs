using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.OptimizedGrid
{
    public class TcOptimizedTableRow : ViewControlObject<RowControl>
    {
        private Lazy<IControlObject> mColumnsParent;

        public TcOptimizedTableRow()
        {
            mColumnsParent = new Lazy<IControlObject>( () => this.FindGeneric( Search.By<CellsControl>(), depth: 1 ) );
        }

        public string GetContent( int columnIndex )
        {
            var content = mColumnsParent.Value
                .FindGeneric( Search.By<LightweightCellEditor>().AndByIndex( columnIndex ), depth: 1 )
                .FindGeneric( Search.By<InplaceBaseEdit>(), depth: 1 );

            return content.Node.GetProperty<string>( "DisplayText" );
        }
    }
}
