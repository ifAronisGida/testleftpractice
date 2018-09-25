using PageObjectInterfaces.Controls;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Material
{
    /// <summary>
    /// The material toolbar.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcToolbars}" />
    public class TcMaterialToolbar : PageObjectBase, IChildOf<TcToolbars>
    {
        protected override Search SearchPattern => Search.ByUid( "Material.Toolbar" );

        /// <summary>
        /// Gets the new button.
        /// </summary>
        /// <value>
        /// The new button.
        /// </value>
        public TiButton NewButton => Find<TiButton>( "Material.Toolbar.New" );

        /// <summary>
        /// Gets the duplicate button.
        /// </summary>
        /// <value>
        /// The duplicate button.
        /// </value>
        public TiButton DuplicateButton => Find<TiButton>( "Material.Toolbar.Duplicate" );

        /// <summary>
        /// Gets the save button.
        /// </summary>
        /// <value>
        /// The save button.
        /// </value>
        public TiButton SaveButton => Find<TiButton>( "Material.Toolbar.Save" );

        /// <summary>
        /// Gets the revert button.
        /// </summary>
        /// <value>
        /// The revert button.
        /// </value>
        public TiButton RevertButton => Find<TiButton>( "Material.Toolbar.Revert" );

        /// <summary>
        /// Gets the delete button.
        /// </summary>
        /// <value>
        /// The delete button.
        /// </value>
        public TiButton DeleteButton => Find<TiButton>( "Material.Toolbar.Delete" );

        /// <summary>
        /// Gets the lock material button.
        /// </summary>
        /// <value>
        /// The lock material button.
        /// </value>
        public TiButton LockMaterialButton => Find<TiButton>( "Material.Toolbar.LockMaterial" );

        /// <summary>
        /// Gets the unlock material button.
        /// </summary>
        /// <value>
        /// The unlock material button.
        /// </value>
        public TiButton UnlockMaterialButton => Find<TiButton>( "Material.Toolbar.UnlockMaterial" );
    }
}
