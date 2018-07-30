using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The ControlObject to select a domain (category).
    /// </summary>
    /// <seealso cref="ControlObject" />
    public class TcDomainSelector : ControlObject
    {
        protected override Search SearchPattern => Search.Any;
    }
}
