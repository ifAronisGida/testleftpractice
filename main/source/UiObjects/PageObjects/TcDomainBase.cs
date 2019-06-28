using System;
using System.Collections.Generic;
using Trumpf.Coparoo.Desktop;
using HomeZone.UiObjectInterfaces.Common;
using HomeZone.UiObjects.ControlObjects;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects
{
    // it would be nice to mark this as a child of the main tab control,
    // but abstract classes are ignored when examining parent-child relationships
    public abstract class TcDomainBase<TToolbar, TResultColumn> : RepeaterObject, TiHasDetailOverlay, TiDomain
        where TToolbar : TiToolbar
        where TResultColumn : TiResultColumn
    {
        protected const string ResultColumnUid = "List.SearchAndResult";

        private readonly Dictionary<Type, object> mCache = new Dictionary<Type, object>();

        public abstract TToolbar Toolbar { get; }

        public bool IsVisible => Toolbar.IsVisible;

        protected TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );
        protected abstract TimeSpan DefaultOverlayAppearTimeout { get; }
        protected abstract TimeSpan DefaultOverlayDisappearTimeout { get; }
        public abstract TResultColumn ResultColumn { get; }

        TiToolbar TiDomain.Toolbar => this.Toolbar;

        TiResultColumn TiDomain.ResultColumn => this.ResultColumn;

        public sealed override void Goto()
        {
            if( Toolbar.IsVisible )
            {
                return;
            }

            DoGoto();
        }

        public void WaitForDetailOverlayAppear( TimeSpan? timeout = null )
        {
            DetailOverlay.Visible.WaitFor( timeout ?? DefaultOverlayAppearTimeout );
        }

        public void WaitForDetailOverlayDisappear( TimeSpan? timeout = null )
        {
            DetailOverlay.Visible.WaitForFalse( timeout ?? DefaultOverlayDisappearTimeout );
        }

        public bool TryWaitForDetailOverlayAppear( TimeSpan? timeout = null )
        {
            return false;
        }

        public bool TryWaitForDetailOverlayDisappear( TimeSpan? timeout = null )
        {
            return false;
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
