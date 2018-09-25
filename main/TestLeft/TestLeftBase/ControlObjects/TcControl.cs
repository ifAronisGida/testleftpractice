using PageObjectInterfaces.Controls;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;

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
