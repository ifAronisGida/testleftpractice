using System;
using System.Linq;
using Trumpf.Coparoo.Desktop;
using HomeZone.UiObjectInterfaces.PartOrder;
using HomeZone.UiObjects.PageObjects.Shell;
using System.Collections.Generic;

namespace HomeZone.UiObjects.PageObjects.PartOrder
{
    public class TcPartOrders : TcDomain<TiPartOrderToolbar>, IChildOf<TcMainTabControl>, TiPartOrders
    {
        public override TiPartOrderToolbar Toolbar => On<TcPartOrderToolbar>( cache: true );
        public TiPartOrderBaseInfo BaseInfo => On<TcPartOrderBaseInfo>( cache: true );
        public TiPartOrderPartInfo PartInfo => On<TcPartOrderPartInfo>( cache: true );

        /// <summary>
        /// Waits for detail overlay appear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitForDetailOverlayAppear( TimeSpan? timeout = null )
        {
            return DetailOverlay.Visible.TryWaitFor( timeout ?? TcPageObjectSettings.Instance.PartOverlayAppearTimeout );
        }

        /// <summary>
        /// Waits for detail overlay disappear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitForDetailOverlayDisappear( TimeSpan? timeout = null )
        {
            return DetailOverlay.Visible.TryWaitForFalse( timeout ?? TcPageObjectSettings.Instance.PartOverlayDisappearTimeout );
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

        public void Import(params string[] files)
        {
            Import( files.AsEnumerable() );
        }

        public void Import( IEnumerable<string> files )
        {
            foreach (var file in files)
            {
                Toolbar.Import( file );
                On<TcMainTabControl>().WaitForTabOverlayDisappear();
            }
        }

        protected override void DoGoto()
        {
            On<TcDomains>().PartOrder.Click();
        }
    }
}
