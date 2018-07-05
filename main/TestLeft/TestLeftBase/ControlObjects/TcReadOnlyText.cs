using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    public class TcReadOnlyText : ControlObject
    {
        protected override Search SearchPattern => Search.Any;

        public string Text => Node.GetProperty<string>("Text");
    }
}
