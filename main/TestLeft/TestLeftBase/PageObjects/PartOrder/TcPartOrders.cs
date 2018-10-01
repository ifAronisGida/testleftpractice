using System;
using Trumpf.PageObjects;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrders : RepeaterObject, IChildOf<TcMainTabControl>
    {
        private readonly Lazy<TcPartOrderBaseInfo> mBaseInfo;
        private readonly Lazy<TcPartOrderPartInfo> mPartInfo;

        public TcPartOrders()
        {
            mBaseInfo = new Lazy<TcPartOrderBaseInfo>( On<TcPartOrderBaseInfo> );
            mPartInfo = new Lazy<TcPartOrderPartInfo>( On<TcPartOrderPartInfo> );
        }

        public TcPartOrderBaseInfo BaseInfo => mBaseInfo.Value;
        public TcPartOrderPartInfo PartInfo => mPartInfo.Value;

        public bool CanSave => On<TcPartOrderToolbar>().SaveButton.Enabled;
        public bool CanDelete => On<TcPartOrderToolbar>().DeleteButton.Enabled;

        public override void Goto()
        {
            On<TcDomains>().PartOrder.Click();
            Visible.WaitFor();
        }

        public void NewPartOrder()
        {
            On<TcPartOrderToolbar>().NewPartOrderButton.Click();
        }

        public void DeletePartOrder()
        {
            On<TcPartOrderToolbar>().DeleteButton.Click();

            var dialog = On<TcMessageBox>();
            if( dialog.MessageBoxExists() )
            {
                dialog.Yes();
            }
        }
    }
}
