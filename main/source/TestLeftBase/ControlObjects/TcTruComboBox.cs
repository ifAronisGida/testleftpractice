using System;
using PageObjectInterfaces.Controls;
using Trumpf.Coparoo.Desktop.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    internal class TcTruComboBox : TcControl, TiValueControl<string>
    {
        public TcTruComboBox( IControlObject controlObject ) : base( controlObject )
        {
        }

        public string Value
        {
            get => ControlObject.Node.GetProperty<string>( "Text" );
            set => ControlObject.Node.SetProperty( "Text", value );
        }

        public bool IsReadOnly => throw new NotSupportedException();
    }
}
