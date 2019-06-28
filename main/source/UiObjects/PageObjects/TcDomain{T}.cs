using System;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Common;
using HomeZone.UiObjects.ControlObjects.Composite;
using HomeZone.UiObjects.Utilities;

namespace HomeZone.UiObjects.PageObjects
{
    public abstract class TcDomain<TToolbar> : TcDomainBase<TToolbar, TiResultColumn>, TiDomain<TToolbar>
        where TToolbar : TiToolbar
    {
        private readonly Lazy<TcResultColumn> mResultColumn;

        protected TcDomain()
        {
            mResultColumn = new Lazy<TcResultColumn>( InitResultColumn );
        }

        public override TiResultColumn ResultColumn => mResultColumn.Value;

        private TcResultColumn InitResultColumn()
        {
            var resultColumnRoot = this.FindGeneric( Search.ByUid( ResultColumnUid ) );

            return new TcResultColumn( resultColumnRoot );
        }
    }
}
