using System;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;


namespace UiObjects.ControlObjects
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
