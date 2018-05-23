using Trumpf.PageObjects.WPF;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The ControlObject to select a domain (category).
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.WPF.ControlObject" />
    public class TcDomainSelector : ControlObject
    {
        protected override Search SearchPattern => Search.Any;
    }
}
