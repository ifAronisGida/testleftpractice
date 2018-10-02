using System;
using Trumpf.PageObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;
using PageObjectInterfaces.PartOrder;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrders : RepeaterObject, IChildOf<TcMainTabControl>, TiPartOrders
    {
        private readonly Lazy<TcPartOrderToolbar> mToolbar;
        private readonly Lazy<TcPartOrderBaseInfo> mBaseInfo;
        private readonly Lazy<TcPartOrderPartInfo> mPartInfo;

        public TcPartOrders()
        {
            mToolbar = new Lazy<TcPartOrderToolbar>( On<TcPartOrderToolbar> );
            mBaseInfo = new Lazy<TcPartOrderBaseInfo>( On<TcPartOrderBaseInfo> );
            mPartInfo = new Lazy<TcPartOrderPartInfo>( On<TcPartOrderPartInfo> );
        }

        public TiPartOrderToolbar Toolbar => mToolbar.Value;
        public TiPartOrderBaseInfo BaseInfo => mBaseInfo.Value;
        public TiPartOrderPartInfo PartInfo => mPartInfo.Value;

        public override void Goto()
        {
            On<TcDomains>().PartOrder.Click();
            Visible.WaitFor();
        }
    }
}
