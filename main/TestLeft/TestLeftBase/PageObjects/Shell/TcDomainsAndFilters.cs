using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Shell
{
    /// <summary>
    /// The domains and filters PageObject.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDomainsAndFilters}" />
    public class TcDomainsAndFilters : PageObject, IChildOf<TcMainTabControl>
    {
        protected override Search SearchPattern => Search.ByUid( "DomainsAndFilters" );
    }
}
