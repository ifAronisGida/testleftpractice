using Trumpf.Coparoo.Desktop.Waiting;

namespace HomeZone.UiObjectInterfaces.Controls
{
    public interface TiControl
    {
        Wool Enabled { get; }

        Wool Visible { get; }

        Wool VisibleOnScreen { get; }

        bool IsFocused { get; }


    }
}
