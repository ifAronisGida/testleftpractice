using System;
using System.Collections.Generic;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Common;
using UiObjects.ControlObjects.Composite;


namespace UiObjects.PageObjects
{
    // it would be nice to mark this as a child of the main tab control,
    // but abstract classes are ignored when examining parent-child relationships
    public abstract class TcDomain<TToolbar> : RepeaterObject, TiDomain where TToolbar : TiVisibility
    {
        private const string ResultColumnUid = "List.SearchAndResult";

        private readonly Lazy<TcResultColumn> mResultColumn;
        private readonly Dictionary<Type, object> mCache = new Dictionary<Type, object>();

        protected TcDomain()
        {
            mResultColumn = new Lazy<TcResultColumn>( () => Find<TcResultColumn>( Search.ByUid( ResultColumnUid ) ) );
        }

        public TiResultColumn ResultColumn => mResultColumn.Value;

        public abstract TToolbar Toolbar { get; }

        public bool IsVisible => Toolbar.IsVisible;

        public sealed override void Goto()
        {
            if( Toolbar.IsVisible )
            {
                return;
            }

            DoGoto();
        }

        protected T On<T>( bool cache ) where T : IPageObject
        {
            if( !cache )
            {
                return On<T>();
            }

            if( mCache.TryGetValue( typeof( T ), out var obj ) )
            {
                return ( T )obj;
            }
            else
            {
                var pageObject = On<T>();
                mCache.Add( typeof( T ), pageObject );

                return pageObject;
            }
        }

        protected abstract void DoGoto();
    }
}
