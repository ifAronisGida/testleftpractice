using HomeZone.UiObjectInterfaces.Controls;
using Trumpf.Coparoo.Desktop.Waiting;
using Trumpf.Coparoo.Desktop.WPF;


namespace HomeZone.UiObjects.ControlObjects
{
    internal class TcControl : TiControl
    {
        public TcControl( IControlObject controlObject )
        {
            this.ControlObject = controlObject;
        }

        public virtual Wool Enabled => ControlObject.Enabled;

        public virtual Wool Visible => ControlObject.Visible;

        public virtual Wool VisibleOnScreen => ControlObject.VisibleOnScreen;


        public virtual bool IsFocused => ControlObject.Node.GetProperty<bool>( "IsKeyboardFocusWithin" );

        protected IControlObject ControlObject { get; }
    }
}
