using System;
using PageObjectInterfaces.Common;
using TestLeft.TestLeftBase.ControlObjects.Composite;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects
{
    // it would be nice to mark this as a child of the main tab control,
    // but abstract classes are ignored when examining parent-child relationships
    public abstract class TcDomain : TcRepeaterObjectBase, TiDomain
    {
        private readonly Lazy<TcResultColumn> mResultColumn;

        protected TcDomain()
        {
            mResultColumn = new Lazy<TcResultColumn>( () => Find<TcResultColumn>( Search.ByUid( TcResultColumn.Uid ) ) );
        }

        public TiResultColumn ResultColumn => mResultColumn.Value;
    }
}
