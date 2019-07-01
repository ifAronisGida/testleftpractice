using HomeZone.UiObjectInterfaces.Controls;
using System;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.ControlObjects
{
    internal class TcUnmappedControl : TcControl, TiButton
    {
        public TcUnmappedControl(IControlObject controlObject) : base(controlObject)
        {
        }

        public string Label => throw new NotImplementedException();

        public void Click()
        {
            ControlObject.Click();
        }
    }
}
