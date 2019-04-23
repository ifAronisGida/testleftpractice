using HomeZone.UiObjectInterfaces.Controls;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop.Waiting;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.ControlObjects
{
    internal class TcControl : TiControl
    {
        public TcControl( IControlObject controlObject )
        {
            ControlObject = controlObject;
        }

        public virtual Wool Enabled => ControlObject.Enabled;

        public virtual Wool Visible => ControlObject.Visible;

        public virtual Wool VisibleOnScreen => ControlObject.VisibleOnScreen;


        public virtual bool IsFocused => ControlObject.Node.GetProperty<bool>( "IsKeyboardFocusWithin" );

        public IVisualObject VisualObject => ( ( Trumpf.Coparoo.Desktop.Core.UIObjectNode )ControlObject.Node ).Root;

        protected IControlObject ControlObject { get; }
    }
}
