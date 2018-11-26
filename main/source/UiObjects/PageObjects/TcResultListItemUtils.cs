using System.Collections.Generic;
using System.Linq;
using HomeZone.UiObjects.Utilities;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects
{
    internal static class TcResultListItemUtils
    {
        public static IReadOnlyDictionary<string, string> GetStates(IControlObject obj)
        {
            return obj.Node.GetDataContextProperty<IObject>( "DisplayStates.Items" ).AsEnumerable<IObject>()
                .ToDictionary( x => x.GetProperty<string>( "Component" ), x => x.GetProperty<string>( "State" ) );
        }
    }
}
