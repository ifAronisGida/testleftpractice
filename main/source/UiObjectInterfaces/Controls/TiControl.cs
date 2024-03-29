using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop.Waiting;

namespace HomeZone.UiObjectInterfaces.Controls
{
    public interface TiControl
    {
        Wool Exists { get; }
        Wool Enabled { get; }

        Wool Visible { get; }

        Wool VisibleOnScreen { get; }

        bool IsFocused { get; }

        IVisualObject VisualObject { get; }
    }
}
