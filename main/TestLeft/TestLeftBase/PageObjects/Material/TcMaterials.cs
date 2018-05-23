using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Common;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Dialogs;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Shell;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Material
{
    /// <summary>
    /// PageObject for the materials category.
    /// </summary>
    /// <seealso cref="RepeaterObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcMainTabControl}" />
    public class TcMaterials : RepeaterObject, IChildOf<TcMainTabControl>
    {
        private TcMaterialToolbar mToolbar;
        private TcResultColumn mResultColumn;
        private TcMaterialDetail mDetail;

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
        public TcMaterialToolbar Toolbar
        {
            get
            {
                if( mToolbar == null )
                {
                    mToolbar = On<TcMaterialToolbar>();
                }

                return mToolbar;
            }
        }

        /// <summary>
        /// Gets the result column.
        /// </summary>
        /// <value>
        /// The result column.
        /// </value>
        public TcResultColumn ResultColumn
        {
            get
            {
                if( mResultColumn == null )
                {
                    mResultColumn = On<TcResultColumn>();
                }

                return mResultColumn;
            }
        }

        /// <summary>
        /// Gets the detail area.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        public TcMaterialDetail Detail
        {
            get
            {
                if( mDetail == null )
                {
                    mDetail = On<TcMaterialDetail>();
                }

                return mDetail;
            }
        }

        /// <summary>
        /// Goto the page object, i.e. perform necessary action to make the page object visible on screen, do nothing if the page is already visible on screen.
        /// </summary>
        public override void Goto()
        {
            base.Goto();
            Goto<TcDomainsMore>().GotoMaterial();
            VisibleOnScreen.WaitFor();
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
        /// Creates a new material.
        /// </summary>
        public void NewMaterial()
        {
            Toolbar.NewButton.Click();
        }

        /// <summary>
        /// Duplicates the current material.
        /// </summary>
        public void DuplicateMaterial()
        {
            Toolbar.DuplicateButton.Click();
        }

        /// <summary>
        /// Saves the current material.
        /// </summary>
        public void SaveMaterial()
        {
            Toolbar.SaveButton.Click();
        }

        /// <summary>
        /// Deletes the current material.
        /// </summary>
        public void DeleteMaterial()
        {
            Toolbar.DeleteButton.Click();

            var dialog = On<TcMessageBox>();
            if( dialog.MessageBoxExists() )
            {
                dialog.Yes();
            }
        }

        /// <summary>
        /// Selects the material via identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void SelectMaterial( string id )
        {
            ResultColumn.SelectItem( id );
        }

        /// <summary>
        /// Selects the materials containing the given search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <returns>The amount of selected materials.</returns>
        public int SelectMaterials( string searchText )
        {
            return ResultColumn.SelectItems( searchText );
        }

        /// <summary>
        /// Selects all materials.
        /// </summary>
        /// <returns>The amount of selected materials.</returns>
        public int SelectAll()
        {
            return ResultColumn.SelectAll();
        }
    }
}
