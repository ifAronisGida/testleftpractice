using Trumpf.PageObjects;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrders : RepeaterObject, IChildOf<TcMainTabControl>
    {
        public bool CanSave => On<TcPartOrderToolbar>().SaveButton.Enabled;
        public bool CanDelete => On<TcPartOrderToolbar>().DeleteButton.Enabled;

        public override void Goto()
        {
            base.Goto();
            Goto<TcDomains>().PartOrder.Click();
            VisibleOnScreen.WaitFor();
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
