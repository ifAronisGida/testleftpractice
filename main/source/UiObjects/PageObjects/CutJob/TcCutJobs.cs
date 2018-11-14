using Trumpf.Coparoo.Desktop;
using HomeZone.UiObjectInterfaces.CutJob;
using HomeZone.UiObjects.PageObjects.Shell;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.CutJob
{
    public class TcCutJobs : TcDomain<TiCutJobToolbar, TiCutJobItem>, IChildOf<TcMainTabControl>, TiCutJobs
    {
        public override TiCutJobToolbar Toolbar => On<TcCutJobToolbar>( cache: true );
        public TiCutJobBaseInfo BaseInfo => On<TcCutJobDetail>( cache: true );
        public TiCutJobContainedOrders ContainedOrders => On<TcCutJobContainedOrders>( cache: true );
        public TiCutJobSolution SheetProgram => On<TcCutJobSolution>( cache: true );

        protected override void DoGoto()
        {
            On<TcDomains>().CutJob.Click();
        }

        protected override TiCutJobItem MakeResultListItem( IControlObject listViewItem ) => new TcCutJob( listViewItem );
    }
}
