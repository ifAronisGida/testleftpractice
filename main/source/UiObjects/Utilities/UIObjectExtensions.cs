using System;
using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.Utilities
{
    internal static class UIObjectExtensions
    {
        public static IControlObject FindGeneric( this IUIObject uiObject, Search pattern, Predicate<IControl> predicate = null, int? depth = null )
        {
            return uiObject.Find<GenericControlObject>( pattern, predicate, depth );
        }

        private class GenericControlObject : ControlObject
        {
            protected override Search SearchPattern => Search.Any;
        }
    }
}
