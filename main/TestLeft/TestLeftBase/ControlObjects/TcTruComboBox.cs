using System;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects.WPF;

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
