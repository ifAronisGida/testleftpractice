using System;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    public class TcDateEdit : ControlObject, TiSimpleValue<DateTime?>
    {
        protected override Search SearchPattern => Search.Any;

        public DateTime? Value
        {
            get
            {
                if( string.IsNullOrEmpty( Node.GetProperty<string>("Text") ) )
                {
                    return null;
                }

                return Node.GetProperty<DateTime>( "DateTime" );
            }

            set
            {
                Node.SetProperty( "DateTime", value );
            }
        }
    }
}
