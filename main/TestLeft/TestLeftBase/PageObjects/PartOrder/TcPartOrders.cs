using Trumpf.PageObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;
using PageObjectInterfaces.PartOrder;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrders : TcDomain, IChildOf<TcMainTabControl>, TiPartOrders
    {
        public TiPartOrderToolbar Toolbar => On<TcPartOrderToolbar>( cache: true );
        public TiPartOrderBaseInfo BaseInfo => On<TcPartOrderBaseInfo>( cache: true );
        public TiPartOrderPartInfo PartInfo => On<TcPartOrderPartInfo>( cache: true );

        public override void Goto()
        {
            if( Toolbar.IsVisible )
            {
                return;
            }

            On<TcDomains>().PartOrder.Click();
        }
    }
}
