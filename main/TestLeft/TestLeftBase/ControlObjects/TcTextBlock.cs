using System;
using PageObjectInterfaces.Controls;
using Trumpf.Coparoo.Desktop.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
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
