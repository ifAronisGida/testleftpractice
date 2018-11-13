using Castle.DynamicProxy;
using HomeZone.UiObjects.PageObjects;

namespace HomeZone.UiObjects.Utilities
{
    internal class TcExpandOnAccessInterceptor : IInterceptor
    {
        private readonly TcExpandablePageObject mPage;

        public TcExpandOnAccessInterceptor( TcExpandablePageObject page )
        {
            mPage = page;
        }

        public void Intercept( IInvocation invocation )
        {
            mPage.IsMoreExpanded = true;
            invocation.Proceed();
        }
    }
}
