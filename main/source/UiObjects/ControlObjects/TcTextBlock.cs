using System;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;


namespace HomeZone.UiObjects.ControlObjects
{
    internal class TcTextBlock : TcControl, TiValueControl<string>
    {
        private readonly IControlObject mControlObject;

        public TcTextBlock( IControlObject controlObject ) : base( controlObject )
        {
            mControlObject = controlObject;
        }

        public string Value
        {
            get => mControlObject.Node.GetProperty<string>( "Text" );
            set => throw new NotSupportedException();
        }

        public bool IsReadOnly => true;
    }
}
