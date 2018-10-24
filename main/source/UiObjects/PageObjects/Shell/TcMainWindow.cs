using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;


namespace UiObjects.PageObjects.Shell
{
    /// <summary>
    /// The main window PageObject. The root of nearly all HomeZone PageObjects.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    public class TcMainWindow : PageObject, IChildOf<TcHomeZoneApp>
    {
        protected override Search SearchPattern => Search.ByControlName("WindowRoot");
    }
}
