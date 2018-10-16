using System;
using System.Collections.Generic;
using PageObjectInterfaces.Common;
using TestLeft.TestLeftBase.ControlObjects.Composite;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects
{
    // it would be nice to mark this as a child of the main tab control,
    // but abstract classes are ignored when examining parent-child relationships
    public abstract class TcDomain : RepeaterObject, TiDomain
    {
        private readonly Lazy<TcResultColumn> mResultColumn;
        private readonly Dictionary<Type, object> mCache = new Dictionary<Type, object>();

        protected TcDomain()
        {
            mResultColumn = new Lazy<TcResultColumn>( () => Find<TcResultColumn>( Search.ByUid( TcResultColumn.Uid ) ) );
        }

        public TiResultColumn ResultColumn => mResultColumn.Value;

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
    }
}
