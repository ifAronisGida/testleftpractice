using System;
using Trumpf.Coparoo.Desktop;
using HomeZone.UiObjectInterfaces.PartOrder;
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.PageObjects.Shell;
using Trumpf.Coparoo.Desktop.Waiting;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.PartOrder
{
    public class TcPartOrders : TcDomain<TiPartOrderToolbar>, IChildOf<TcMainTabControl>, TiPartOrders
    {
        /// <summary>
        /// Gets the detail overlay.
        /// </summary>
        /// <value>
        /// The detail overlay.
        /// </value>
        private TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );

        public override TiPartOrderToolbar Toolbar => On<TcPartOrderToolbar>( cache: true );
        public TiPartOrderBaseInfo BaseInfo => On<TcPartOrderBaseInfo>( cache: true );
        public TiPartOrderPartInfo PartInfo => On<TcPartOrderPartInfo>( cache: true );

        /// <summary>
        /// Waits for detail overlay appear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitForDetailOverlayAppear( TimeSpan timeout )
        {
            return TryWait.For( () => DetailOverlay.VisibleOnScreen, timeout );
        }

        /// <summary>
        /// Waits for detail overlay disappear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitForDetailOverlayDisappear( TimeSpan timeout )
        {
            return TryWait.For( () => !DetailOverlay.VisibleOnScreen, timeout );
        }

        /// <summary>
        /// Deletes the given part order. The part order should not be used in nestings.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if deleted</returns>
        public bool DeletePartOrder( string id )
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

        protected override void DoGoto()
        {
            On<TcDomains>().PartOrder.Click();
        }
    }
}
