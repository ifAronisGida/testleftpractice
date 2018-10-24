using PageObjectInterfaces.Controls;
using Trumpf.Coparoo.Desktop.Waiting;
using Trumpf.Coparoo.Desktop.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    internal class TcControl : TiControl
    {
        public TcControl( IControlObject controlObject )
        {
            this.ControlObject = controlObject;
        }

        public virtual Wool Enabled => ControlObject.Enabled;

        public virtual Wool Visible => ControlObject.Visible;

        protected IControlObject ControlObject { get; }
    }
}
