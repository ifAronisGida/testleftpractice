using System;
using System.Collections.Generic;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Common;
using HomeZone.UiObjects.ControlObjects.Composite;
using HomeZone.UiObjects.Utilities;

namespace HomeZone.UiObjects.PageObjects
{
    public abstract class TcDomain<TToolbar> : TcDomainBase<TToolbar>, TiDomain
        where TToolbar : TiVisibility
    {
        private readonly Lazy<TcResultColumn> mResultColumn;
        private readonly Dictionary<Type, object> mCache = new Dictionary<Type, object>();

        protected TcDomain()
        {
            mResultColumn = new Lazy<TcResultColumn>( InitResultColumn );
        }

        public TiResultColumn ResultColumn => mResultColumn.Value;

        private TcResultColumn InitResultColumn()
        {
            var resultColumnRoot = this.FindGeneric( Search.ByUid( ResultColumnUid ) );

            return new TcResultColumn( resultColumnRoot );
        }
    }
}
