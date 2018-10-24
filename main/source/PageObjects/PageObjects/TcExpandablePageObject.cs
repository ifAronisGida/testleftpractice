using System;
using Castle.DynamicProxy;
using TestLeft.TestLeftBase.Utilities;

namespace TestLeft.TestLeftBase.PageObjects
{
    public abstract class TcExpandablePageObject : TcPageObjectBase
    {
        private static readonly Lazy<ProxyGenerator> ProxyGenerator = new Lazy<ProxyGenerator>( () => new ProxyGenerator() );

        private readonly Lazy<TcExpandOnAccessInterceptor> mInterceptor;

        protected TcExpandablePageObject()
        {
            mInterceptor = new Lazy<TcExpandOnAccessInterceptor>( () => new TcExpandOnAccessInterceptor( this ) );
        }

        public virtual bool IsMoreExpanded
        {
            get => Node.GetProperty<bool>( "IsMoreExpanded" );
            set => Node.SetProperty( "IsMoreExpanded", value );
        }

        public TInterface Find<TInterface>( string uid, bool expandOnAccess ) where TInterface : class
        {
            var obj = Find<TInterface>( uid );

            return expandOnAccess ?
                ProxyGenerator.Value.CreateInterfaceProxyWithTarget( obj, mInterceptor.Value ) :
                obj;
        }
    }
}
