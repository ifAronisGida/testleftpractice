using Trumpf.Coparoo.Desktop;
using UiObjectInterfaces.CutJob;
using UiObjects.PageObjects.Shell;


namespace UiObjects.PageObjects.CutJob
{
    public class TcCutJobs : TcDomain<TiCutJobToolbar>, IChildOf<TcMainTabControl>, TiCutJobs
    {
        public override TiCutJobToolbar Toolbar => On<TcCutJobToolbar>( cache: true );
        public TiCutJobBaseInfo BaseInfo => On<TcCutJobDetail>( cache: true );
        public TiCutJobContainedOrders ContainedOrders => On<TcCutJobContainedOrders>( cache: true );
        public TiCutJobSheetProgram SheetProgram => On<TcCutJobSolution>( cache: true );

        protected override void DoGoto()
        {
            On<TcDomains>().CutJob.Click();
        }
    }
}
