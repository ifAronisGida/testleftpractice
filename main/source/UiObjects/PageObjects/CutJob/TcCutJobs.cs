using Trumpf.Coparoo.Desktop;
using HomeZone.UiObjectInterfaces.CutJob;
using HomeZone.UiObjects.PageObjects.Shell;
using Trumpf.Coparoo.Desktop.WPF;
using System;

namespace HomeZone.UiObjects.PageObjects.CutJob
{
    public class TcCutJobs : TcDomain<TiCutJobToolbar, TiCutJobResultListItem>, IChildOf<TcMainTabControl>, TiCutJobs
    {
        public override TiCutJobToolbar Toolbar => On<TcCutJobToolbar>( cache: true );
        public TiCutJobBaseInfo BaseInfo => On<TcCutJobBaseInfo>( cache: true );
        public TiCutJobContainedOrders ContainedOrders => On<TcCutJobContainedOrders>( cache: true );
        public TiCutJobSolution SheetProgram => On<TcCutJobSolution>( cache: true );

        /// <summary>
        /// Deletes the given cut job.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if deleted</returns>
        public bool DeleteCutJob( string id )
        {
            if( !ResultColumn.SelectItem( id ) )
            {
                ResultColumn.ClearSearch();
                return false;
            }

            Toolbar.Delete();
            ResultColumn.ClearSearch();
            return true;
        }

        public void WaitForDetailOverlayAppear( TimeSpan? timeout = null )
        {
            DetailOverlay.Visible.WaitFor( timeout ?? TcPageObjectSettings.Instance.CutJobOverlayAppearTimeout );
        }

        public void WaitForDetailOverlayDisappear( TimeSpan? timeout = null )
        {
            DetailOverlay.Visible.WaitForFalse( timeout ?? TcPageObjectSettings.Instance.CutJobOverlayDisappearTimeout );
        }

        protected override void DoGoto()
        {
            On<TcDomains>().CutJob.Click();
        }

        protected override TiCutJobResultListItem MakeResultListItem( IControlObject listViewItem ) => new TcCutJobResultListItem( listViewItem );
    }
}
