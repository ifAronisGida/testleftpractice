using System;
using System.Linq;
using Trumpf.Coparoo.Desktop;
using HomeZone.UiObjectInterfaces.PartOrder;
using HomeZone.UiObjects.PageObjects.Shell;
using System.Collections.Generic;
using HomeZone.UiObjects.PageObjects.Dialogs;

namespace HomeZone.UiObjects.PageObjects.PartOrder
{
    public class TcPartOrders : TcDomain<TiPartOrderToolbar>, IChildOf<TcMainTabControl>, TiPartOrders
    {
        public override TiPartOrderToolbar Toolbar => On<TcPartOrderToolbar>( cache: true );
        public TiPartOrderBaseInfo BaseInfo => On<TcPartOrderBaseInfo>( cache: true );
        public TiPartOrderPartInfo PartInfo => On<TcPartOrderPartInfo>( cache: true );
        public TiPartOrderBaseInfoBulk BaseInfoBulk => On<TcPartOrderBaseInfoBulk>( cache: true );
        public TiPartOrderPartInfoBulk PartInfoBulk => On<TcPartOrderPartInfoBulk>( cache: true );

        protected override TimeSpan DefaultOverlayAppearTimeout => TcPageObjectSettings.Instance.PartOverlayAppearTimeout;
        protected override TimeSpan DefaultOverlayDisappearTimeout => TcPageObjectSettings.Instance.PartOverlayDisappearTimeout;

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

        public void ImportDirectory(string directory)
        {
            Toolbar.Import();

            On<TcOpenFileDialog>().OpenAll( directory );
            On<TcMainTabControl>().WaitForTabOverlayDisappear();
        }

        protected override void DoGoto()
        {
            On<TcDomainsAndFilters>().GotoDomain( TeDomain.PartOrder );
        }
    }
}
