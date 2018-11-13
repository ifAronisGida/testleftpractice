using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.ControlObjects
{
    /// <summary>
    /// The ControlObject for overlays.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.WPF.ControlObject" />
    public class TcOverlay : ControlObject
    {
        protected override Search SearchPattern => Search.Any;
    }
}
