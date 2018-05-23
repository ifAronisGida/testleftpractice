using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Shell
{
    /// <summary>
    /// The parent of all category toolbars.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcMainTabControl}" />
    public class TcToolbars : PageObject, IChildOf<TcMainTabControl>
    {
        protected override Search SearchPattern => Search.ByUid( "Toolbars" );
    }
}
