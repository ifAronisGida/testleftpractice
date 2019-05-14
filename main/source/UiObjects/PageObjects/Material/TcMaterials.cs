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

        protected override TimeSpan DefaultOverlayAppearTimeout => TcPageObjectSettings.Instance.MaterialOverlayAppearTimeout;
        protected override TimeSpan DefaultOverlayDisappearTimeout => TcPageObjectSettings.Instance.MaterialOverlayDisappearTimeout;

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
            ( ( TcMainTabControl )Parent ).WaitForTabOverlayDisappear();
            ResultColumn.ClearSearch();
            return true;
        }

        protected override void DoGoto()
        {
            Goto<TcDomainsMore>().GotoMaterial();
        }
    }
}
