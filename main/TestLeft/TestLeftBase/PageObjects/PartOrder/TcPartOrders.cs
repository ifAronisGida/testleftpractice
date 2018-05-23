using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using Trumpf.PageObjects.Waiting;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrders : RepeaterObject, IChildOf<TcMainTabControl>
    {
        private TcPartOrderToolbar mToolbar;
        //private TcPartOrderSingleDetail mSingleDetail;
        //private TcPartOrderSingleDetailDesign mSingleDetailPart;
        //private TcPartOrderSingleDetailBendSolutions mSingleDetailCutJob;

        public TcPartOrderToolbar Toolbar
        {
            get
            {
                if( mToolbar == null )
                {
                    mToolbar = On<TcPartOrderToolbar>();
                }

                return mToolbar;
            }
        }

        public override void Goto()
        {
            base.Goto();
            Goto<TcDomains>().PartOrder.Click();
            VisibleOnScreen.WaitFor();
        }

        public void NewPartOrder()
        {
            Toolbar.NewPartOrderButton.Click();
        }

        public void DeletePartOrder()
        {
            Toolbar.DeleteButton.Click();

            var dialog = On<TcMessageBox>();
            if( dialog.MessageBoxExists() )
            {
                dialog.Yes();
            }
        }
    }
}
