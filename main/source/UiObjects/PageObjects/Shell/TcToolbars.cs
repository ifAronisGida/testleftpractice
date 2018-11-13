using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;


namespace HomeZone.UiObjects.PageObjects.Shell
{
    /// <summary>
    /// The parent of all category toolbars.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="IChildOf{T}" />
    public class TcToolbars : PageObject, IChildOf<TcMainTabControl>
    {
        protected override Search SearchPattern => Search.ByUid( "Toolbars" );
    }
}
