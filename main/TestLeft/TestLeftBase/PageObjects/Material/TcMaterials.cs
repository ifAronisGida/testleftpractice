using System;
using PageObjectInterfaces.Material;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Material
{
    /// <summary>
    /// PageObject for the materials category.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcMainTabControl}" />
    public class TcMaterials : TcDomain, IChildOf<TcMainTabControl>, TiMaterials
    {
        private readonly Lazy<TcMaterialToolbar> mToolbar;
        private readonly Lazy<TcMaterialDetail> mDetail;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcMaterials"/> class.
        /// </summary>
        public TcMaterials()
        {
            mToolbar = new Lazy<TcMaterialToolbar>( On<TcMaterialToolbar> );
            mDetail = new Lazy<TcMaterialDetail>( On<TcMaterialDetail> );
        }

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
        public TiMaterialToolbar Toolbar => mToolbar.Value;

        /// <summary>
        /// Gets the detail area.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        public TiMaterialDetail Detail => mDetail.Value;

        /// <summary>
        /// Goto the page object, i.e. perform necessary action to make the page object visible on screen, do nothing if the page is already visible on screen.
        /// </summary>
        public override void Goto()
        {
            if( Toolbar.IsVisible )
            {
                return;
            }

            base.Goto();
            Goto<TcDomainsMore>().GotoMaterial();
        }

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
        /// Deletes the given material.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if successful</returns>
        public bool DeleteMaterial( string id )
        {
            if( !ResultColumn.SelectItem( id ) )
            {
                return false;
            }

            Toolbar.Delete();
            return true;
        }
    }
}
