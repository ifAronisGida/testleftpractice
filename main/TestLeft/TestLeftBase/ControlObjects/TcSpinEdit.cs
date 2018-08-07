using DevExpress.Xpf.Editors;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    public class TcSpinEdit : ViewControlObject<SpinEdit>
    {
        public int Value
        {
            get => Node.GetProperty<int>( "Value" );
            set => Node.SetProperty( "Value", value );
        }
    }
}
