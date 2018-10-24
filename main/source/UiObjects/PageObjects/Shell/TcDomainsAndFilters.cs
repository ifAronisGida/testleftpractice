using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;


namespace UiObjects.PageObjects.Shell
{
    /// <summary>
    /// The domains and filters PageObject.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="IChildOf{T}" />
    public class TcDomainsAndFilters : PageObject, IChildOf<TcMainTabControl>
    {
        protected override Search SearchPattern => Search.ByUid( "DomainsAndFilters" );
    }
}
