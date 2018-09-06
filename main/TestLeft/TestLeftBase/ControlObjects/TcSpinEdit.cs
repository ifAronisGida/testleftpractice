using DevExpress.Xpf.Editors;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    public class TcSpinEdit : ViewControlObject<SpinEdit>, TiSimpleValue<int>
    {
        public int Value
        {
            get => Node.GetProperty<int>( "Value" );
            set => Node.SetProperty( "Value", value );
        }
    }
}
