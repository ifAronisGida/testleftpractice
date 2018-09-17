using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.Utilities
{
    public class TcGenericControlObject : ControlObject
    {
        protected override Search SearchPattern => Search.Any;
    }
}
