using DevExpress.Xpf.Grid;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The ControlObject for grid controls.
    /// </summary>
    /// <seealso cref="GridControl" />
    public class TcGridControl : ViewControlObject<GridControl>
    {
        protected override Search SearchPattern => Search.Any;

        public string Text
        {
            get
            {
                return Node.Cast<IWPFTextEdit>().GetText();
            }
            set
            {
                Node.Cast<IWPFTextEdit>().SetText( value );
            }
        }

        public int RowCount
        {
            get
            {
                return Node.GetProperty<int>( "VisibleRowCount" );
            }
            
        }

        public void UnselectAll()
        {
            Node.CallMethod( "UnselectAll" );
        }

        public void SelectItem( int index)
        {
            if (RowCount > index)
            {
                Node.CallMethod( "SelectItem", index );
            }
        }
        
    }
}
