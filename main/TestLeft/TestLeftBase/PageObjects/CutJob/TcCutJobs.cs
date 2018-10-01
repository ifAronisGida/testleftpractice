using System;
using Trumpf.PageObjects;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.ControlObjects.Composite;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobs : RepeaterObject, IChildOf<TcMainTabControl>
    {
        private readonly Lazy<TcCutJobToolbar> mToolbar;
        private readonly Lazy<TcResultColumn> mResultColumn;

        private readonly Lazy<TcCutJobDetail> mBaseInfo;
        private readonly Lazy<TcCutJobContainedOrders> mContainedOrders;
        private readonly Lazy<TcCutJobSolution> mSheetProgram;

        private TcCutJobSolution mCutJobSolution;

        public TcCutJobs()
        {
            mToolbar = new Lazy<TcCutJobToolbar>( On<TcCutJobToolbar> );
            mResultColumn = new Lazy<TcResultColumn>( () => Find<TcResultColumn>( Search.ByUid( TcResultColumn.Uid ) ) );
            mBaseInfo = new Lazy<TcCutJobDetail>( On<TcCutJobDetail> );
            mContainedOrders = new Lazy<TcCutJobContainedOrders>( On<TcCutJobContainedOrders> );
            mSheetProgram = new Lazy<TcCutJobSolution>( On<TcCutJobSolution> );
        }

        public TcCutJobToolbar Toolbar => mToolbar.Value;

        public TcResultColumn ResultColumn => mResultColumn.Value;

        public TcCutJobDetail BaseInfo => mBaseInfo.Value;

        public TcCutJobContainedOrders ContainedOrders => mContainedOrders.Value;

        public TcCutJobSolution SheetProgram => mSheetProgram.Value;

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

        public bool SelectCutJob( string id )
        {
            return ResultColumn.SelectItem( id );
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
