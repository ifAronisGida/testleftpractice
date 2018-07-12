using System;
using Trumpf.PageObjects;
using TestLeft.TestLeftBase.PageObjects.Common;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobs : RepeaterObject, IChildOf<TcMainTabControl>
    {
        private readonly Lazy<TcCutJobToolbar> mToolbar;
        private readonly Lazy<TcResultColumn> mResultColumn;

        private readonly Lazy<TcCutJobDetail> mSingleDetail;
        private readonly Lazy<TcCutJobContainedOrders> mContainedOrders;

        private TcCutJobSolution mCutJobSolution;

        public TcCutJobs()
        {
            mToolbar = new Lazy<TcCutJobToolbar>( () => On<TcCutJobToolbar>() );
            mResultColumn = new Lazy<TcResultColumn>( () => On<TcResultColumn>() );
            mSingleDetail = new Lazy<TcCutJobDetail>( () => On<TcCutJobDetail>() );
            mContainedOrders = new Lazy<TcCutJobContainedOrders>( () => On<TcCutJobContainedOrders>() );
        }

        public TcCutJobToolbar Toolbar => mToolbar.Value;

        public TcResultColumn ResultColumn => mResultColumn.Value;

        public TcCutJobDetail SingleDetail => mSingleDetail.Value;

        public TcCutJobContainedOrders ContainedOrders => mContainedOrders.Value;

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

        public void SaveCutJob()
        {
            Toolbar.SaveButton.Click();
        }

        public void RevertCutJob()
        {
            Toolbar.RevertButton.Click();
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
    }
}
