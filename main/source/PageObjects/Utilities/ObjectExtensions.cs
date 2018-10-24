using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBear.TestLeft.TestObjects;

namespace TestLeft.TestLeftBase.Utilities
{
    internal static class ObjectExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this IObject obj)
        {
            return new EnumerableProxy<T>( obj );
        }
    }
}
