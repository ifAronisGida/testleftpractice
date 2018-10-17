using Trumpf.PageObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;
using PageObjectInterfaces.CutJob;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobs : TcDomain, IChildOf<TcMainTabControl>, TiCutJobs
    {
        public TiCutJobToolbar Toolbar => On<TcCutJobToolbar>( cache: true );
        public TiCutJobBaseInfo BaseInfo => On<TcCutJobDetail>( cache: true );
        public TiCutJobContainedOrders ContainedOrders => On<TcCutJobContainedOrders>( cache: true );
        public TiCutJobSheetProgram SheetProgram => On<TcCutJobSolution>( cache: true );

        public override void Goto()
        {
            if( Toolbar.IsVisible )
            {
                return;
            }

            On<TcDomains>().CutJob.Click();
        }
    }
}
