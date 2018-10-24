using System.Collections.Generic;
using SmartBear.TestLeft.TestObjects;


namespace UiObjects.Utilities
{
    internal static class TcObjectExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this IObject obj)
        {
            return new TcEnumerableProxy<T>( obj );
        }
    }
}
