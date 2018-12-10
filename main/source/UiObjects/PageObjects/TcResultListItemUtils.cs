using System.Collections.Generic;
using System.Linq;
using HomeZone.UiObjects.Utilities;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects
{
    internal static class TcResultListItemUtils
    {
        /// <summary>
        /// Returns the states from a result list item that has one row of state stacks.
        /// </summary>
        /// <param name="obj">Object from which to get the states (root).</param>
        /// <returns>a dictionary of states</returns>
        public static IReadOnlyDictionary<string, string> GetSingleStackStates(IControlObject obj)
        {
            return obj.Node.GetDataContextProperty<IObject>( "DisplayStates.Items" ).AsEnumerable<IObject>()
                .ToDictionary( x => x.GetProperty<string>( "Component" ), x => x.GetProperty<string>( "State" ) );
        }

        public static IReadOnlyDictionary<string, string> GetDoubleStackStates( IControlObject obj )
        {
            var firstStack = obj.Node.GetDataContextProperty<IObject>( "DisplayStates.Items" ).AsEnumerable<IObject>();
            var secondStack = obj.Node.GetDataContextProperty<IObject>( "DisplayStates.SecondStackItems" ).AsEnumerable<IObject>();

            return firstStack.Concat( secondStack )
                .ToDictionary( x => x.GetProperty<string>( "Component" ), x => x.GetProperty<string>( "State" ) );
        }
    }
}
