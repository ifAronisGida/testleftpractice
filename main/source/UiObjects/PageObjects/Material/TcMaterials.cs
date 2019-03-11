using System;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.Waiting;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Material;
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.PageObjects.Shell;

namespace HomeZone.UiObjects.PageObjects.Material
{
    /// <summary>
    /// PageObject for the materials category.
    /// </summary>
    /// <seealso cref="IChildOf{T}" />
    public class TcMaterials : TcDomain<TiMaterialToolbar>, IChildOf<TcMainTabControl>, TiMaterials
    {
        /// <summary>
        /// Gets the detail overlay.
        /// </summary>
        /// <value>
        /// The detail overlay.
        /// </value>
        public TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );

        /// <summary>
        /// Gets the toolbar.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        public override TiMaterialToolbar Toolbar => On<TcMaterialToolbar>( cache: true );

        /// <summary>
        /// Gets the detail area.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        public TiMaterialDetail Detail => On<TcMaterialDetail>( cache: true );

        /// <summary>
        /// Waits for detail overlay appear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitForDetailOverlayAppear( TimeSpan? timeout = null )
        {
            return DetailOverlay.Visible.TryWaitFor( timeout ?? TcPageObjectSettings.Instance.MaterialOverlayAppearTimeout );
        }

        /// <summary>
        /// Waits for detail overlay disappear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitForDetailOverlayDisappear( TimeSpan? timeout = null )
        {
            return DetailOverlay.Visible.TryWaitForFalse( timeout ?? TcPageObjectSettings.Instance.MaterialOverlayDisappearTimeout );
        }

        /// <summary>
        /// Deletes the given material.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if successful</returns>
        public bool DeleteMaterial( string id )
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
            Goto<TcDomainsMore>().GotoMaterial();
        }
    }
}
