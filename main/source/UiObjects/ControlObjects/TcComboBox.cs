using HomeZone.UiObjectInterfaces.Controls;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.ControlObjects
{
    internal class TcComboBox : TcControl, TiValueControl<int>, TiButton
    {
        public TcComboBox( IControlObject controlObject ) : base( controlObject )
        {
        }

        int TiValueControl<int>.Value
        {
            get => throw new System.NotImplementedException();
            set => ControlObject.Node.Cast<IComboBox>().ClickItem( value );
        }

        bool TiValueControl<int>.IsReadOnly => ControlObject.Node.GetProperty<bool>( "IsReadOnly" );

        string TiButton.Label => throw new System.NotImplementedException();

        void TiButton.Click()
        {
            ControlObject.Click();
        }
    }
}
