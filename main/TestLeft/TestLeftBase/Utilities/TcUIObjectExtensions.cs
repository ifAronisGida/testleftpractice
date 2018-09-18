using System;
using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.Utilities
{
    internal static class TcUIObjectExtensions
    {
        public static IControlObject FindGeneric( this IUIObject uiObject, Search pattern, Predicate<IControl> predicate = null, int? depth = null )
        {
            return uiObject.Find<TcGenericControlObject>( pattern, predicate, depth );
        }

        public static T FindGeneric<T>( this IUIObject uiObject, string uid, Predicate<IControl> predicate = null, int? depth = null ) where T : class
        {
            return TcControlMapper.Map<T>( uiObject.FindGeneric( Search.ByUid( uid ), predicate, depth ) );
        }
    }
}
