using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.ControlObjects.Composite;

namespace TestLeft.TestLeftBase.PageObjects.Material
{
    /// <summary>
    /// PageObject for the materials category.
    /// </summary>
    /// <seealso cref="RepeaterObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcMainTabControl}" />
    public class TcMaterials : RepeaterObject, IChildOf<TcMainTabControl>
    {
        private readonly Lazy<TcMaterialToolbar> mToolbar;
        private readonly Lazy<TcResultColumn> mResultColumn;
        private readonly Lazy<TcMaterialDetail> mDetail;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcMaterials"/> class.
        /// </summary>
        public TcMaterials()
        {
            mToolbar = new Lazy<TcMaterialToolbar>( On<TcMaterialToolbar> );
            mResultColumn = new Lazy<TcResultColumn>( () => Find<TcResultColumn>(Search.ByUid( TcResultColumn.Uid ) ) );
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
        public TcMaterialToolbar Toolbar => mToolbar.Value;

        /// <summary>
        /// Gets the result column.
        /// </summary>
        /// <value>
        /// The result column.
        /// </value>
        public TcResultColumn ResultColumn => mResultColumn.Value;

        /// <summary>
        /// Gets the detail area.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        public TcMaterialDetail Detail => mDetail.Value;

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
