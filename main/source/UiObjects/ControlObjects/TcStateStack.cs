using System.Collections.Generic;
using System.Linq;
using HomeZone.UiObjects.Utilities;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.ControlObjects
{
    internal class TcStateStack : ControlObject
    {
        protected override Search SearchPattern => Search.ByUid( "ResultList.Item.States" );

        public IReadOnlyDictionary<string, string> GetStates()
        {
            return Node.GetProperty<IObject>( "ItemsSource" ).AsEnumerable<IObject>()
                .ToDictionary(
                    e => e.GetProperty<string>( "Component" ),
                    e => e.GetProperty<string>( "State" ) );
        }
    }
}
