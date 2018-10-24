using Trumpf.Coparoo.Desktop;
using UiObjectInterfaces.PartOrder;
using UiObjects.PageObjects.Shell;


namespace UiObjects.PageObjects.PartOrder
{
    public class TcPartOrders : TcDomain<TiPartOrderToolbar>, IChildOf<TcMainTabControl>, TiPartOrders
    {
        public override TiPartOrderToolbar Toolbar => On<TcPartOrderToolbar>( cache: true );
        public TiPartOrderBaseInfo BaseInfo => On<TcPartOrderBaseInfo>( cache: true );
        public TiPartOrderPartInfo PartInfo => On<TcPartOrderPartInfo>( cache: true );

        protected override void DoGoto()
        {
            On<TcDomains>().PartOrder.Click();
        }
    }
}
