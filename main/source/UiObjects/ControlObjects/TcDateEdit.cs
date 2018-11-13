using System;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;


namespace HomeZone.UiObjects.ControlObjects
{
    internal class TcDateEdit : TcControl, TiValueControl<DateTime?>
    {
        private readonly IControlObject mControlObject;

        public TcDateEdit( IControlObject controlObject ) : base( controlObject )
        {
            this.mControlObject = controlObject;
        }

        public DateTime? Value
        {
            get
            {
                if( string.IsNullOrEmpty( mControlObject.Node.GetProperty<string>( "Text" ) ) )
                {
                    return null;
                }

                return mControlObject.Node.GetProperty<DateTime>( "DateTime" );
            }

            set
            {
                mControlObject.Node.SetProperty( "DateTime", value );
            }
        }

        public bool IsReadOnly => mControlObject.Node.GetProperty<bool>( "IsReadOnly" );
    }
}
