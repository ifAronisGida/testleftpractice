using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    public class TcReadOnlyText : ControlObject, TiSimpleValue<string>
    {
        protected override Search SearchPattern => Search.Any;

        public string Text => Node.GetProperty<string>( "Text" );

        string TiSimpleValue<string>.Value
        {
            get => this.Text;
            set => throw new System.NotSupportedException();
        }
    }
}
