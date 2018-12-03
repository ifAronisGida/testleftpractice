using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.ControlObjects
{
    internal class TcTooltipAccessor : ControlObject
    {
        protected override Search SearchPattern => Search.Any;

        public string ToolTip => Node.GetProperty<string>( "ToolTip" );
    }
}
