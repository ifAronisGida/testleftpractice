using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Shell
{
    /// <summary>
    /// Base PageObject for the detail pane.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcMainTabControl}" />
    public class TcDetailContent : PageObject, IChildOf<TcMainTabControl>
    {
        protected override Search SearchPattern => Search.ByUid( "DetailContent" );
    }
}
