using System;
using Trumpf.PageObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;
using PageObjectInterfaces.CutJob;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobs : TcDomain, IChildOf<TcMainTabControl>, TiCutJobs
    {
        private readonly Lazy<TcCutJobToolbar> mToolbar;

        private readonly Lazy<TcCutJobDetail> mBaseInfo;
        private readonly Lazy<TcCutJobContainedOrders> mContainedOrders;
        private readonly Lazy<TcCutJobSolution> mSheetProgram;

        public TcCutJobs()
        {
            mToolbar = new Lazy<TcCutJobToolbar>( On<TcCutJobToolbar> );
            mBaseInfo = new Lazy<TcCutJobDetail>( On<TcCutJobDetail> );
            mContainedOrders = new Lazy<TcCutJobContainedOrders>( On<TcCutJobContainedOrders> );
            mSheetProgram = new Lazy<TcCutJobSolution>( On<TcCutJobSolution> );
        }

        public TiCutJobToolbar Toolbar => mToolbar.Value;

        public TiCutJobBaseInfo BaseInfo => mBaseInfo.Value;

        public TiCutJobContainedOrders ContainedOrders => mContainedOrders.Value;

        public TiCutJobSheetProgram SheetProgram => mSheetProgram.Value;

        public override void Goto()
        {
            if( Toolbar.IsVisible )
            {
                return;
            }

            base.Goto();
            Goto<TcDomains>().CutJob.Click();
        }
    }
}
