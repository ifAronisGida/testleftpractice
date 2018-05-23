using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using Trumpf.PageObjects.Waiting;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Common;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Dialogs;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Shell;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobs : RepeaterObject, IChildOf<TcMainTabControl>
    {
        private TcCutJobToolbar mToolbar;
        private TcResultColumn mResultColumn;

        private TcCutJobDetail mSingleDetail;
        //private TcCutJobDetailDesign mDetailOrders;
        //private TcCutJobDetailBendSolutions mDetailJob;
        private TcCutJobContainedOrders mContainedOrders;

        private TcCutJobSolution mCutJobSolution;

        public TcCutJobToolbar Toolbar
        {
            get
            {
                if( mToolbar == null )
                {
                    mToolbar = On<TcCutJobToolbar>();
                }

                return mToolbar;
            }
        }

        public override void Goto()
        {
            base.Goto();
            Goto<TcDomains>().CutJob.Click();
            VisibleOnScreen.WaitFor();
        }

        public void NewCutJob()
        {
            Toolbar.NewCutJobButton.Click();
        }

        public void DeleteCutJob()
        {
            Toolbar.DeleteButton.Click();

            var dialog = On<TcMessageBox>();
            if( dialog.MessageBoxExists() )
            {
                dialog.Yes();
            }
        }
        public TcResultColumn ResultColumn
        {
            get
            {
                if( mResultColumn == null )
                {
                    mResultColumn = On<TcResultColumn>();
                }

                return mResultColumn;
            }
        }

        public void SelectCutJob( string id )
        {
            ResultColumn.SelectItem( id );
        }

        public int SelectCutJobsOrders( string searchText )
        {
            return ResultColumn.SelectItems( searchText );
        }

        public int SelectAll()
        {
            return ResultColumn.SelectAll();
        }

        public TcCutJobDetail SingleDetail
        {
            get
            {
                if( mSingleDetail == null )
                {
                    mSingleDetail = On<TcCutJobDetail>();
                }

                return mSingleDetail;
            }
        }

        public TcCutJobContainedOrders CutJobContainedOrders
        {
            get
            {
                if( mContainedOrders == null )
                {
                    mContainedOrders = On<TcCutJobContainedOrders>();
                }

                return mContainedOrders;
            }
        }

        public TcCutJobSolution CutJobSolution
        {
            get
            {
                if( mCutJobSolution == null )
                {
                    mCutJobSolution = On<TcCutJobSolution>();
                }

                return mCutJobSolution;
            }
        }
        

    }
}
