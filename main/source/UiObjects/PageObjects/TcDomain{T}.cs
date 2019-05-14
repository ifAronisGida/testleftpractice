using System;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Common;
using HomeZone.UiObjects.ControlObjects.Composite;
using HomeZone.UiObjects.Utilities;

namespace HomeZone.UiObjects.PageObjects
{
    public abstract class TcDomain<TToolbar, TResultListItem> : TcDomainBase<TToolbar>, TiDomain<TResultListItem>
        where TToolbar : TiVisibility
        where TResultListItem : class
    {
        private readonly Lazy<TcResultColumn<TResultListItem>> mResultColumn;

        protected TcDomain()
        {
            mResultColumn = new Lazy<TcResultColumn<TResultListItem>>( InitResultColumn );
        }

        public TiResultColumn<TResultListItem> ResultColumn => mResultColumn.Value;

        protected abstract TResultListItem MakeResultListItem( IControlObject listViewItem );

        private TcResultColumn<TResultListItem> InitResultColumn()
        {
            var resultColumnRoot = this.FindGeneric( Search.ByUid( ResultColumnUid ) );

            return new TcResultColumn<TResultListItem>( resultColumnRoot, MakeResultListItem );
        }

        TiResultColumn TiDomain.ResultColumn => mResultColumn.Value;
    }
}
