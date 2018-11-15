using System;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.Utilities
{
    internal static class TcUIObjectExtensions
    {
        public static IControlObject FindGeneric( this IUIObject uiObject, Search pattern, Predicate<IControl> predicate = null, int? depth = null )
        {
            return uiObject.Find<TcGenericControlObject>( pattern, predicate, depth );
        }

        public static TResult FindMapped<TResult>( this IUIObject uiObject, Search pattern, int? depth = null )
            where TResult : class
        {
            return TcControlMapper.Map<TResult>( uiObject.FindGeneric( pattern, null, depth ) );
        }

        public static TResult FindMapped<TResult>( this IUIObject uiObject, string uid, Predicate<IControl> predicate = null, int? depth = null )
            where TResult : class
        {
            return TcControlMapper.Map<TResult>( uiObject.FindGeneric( Search.ByUid( uid ), predicate, depth ) );
        }
    }
}
