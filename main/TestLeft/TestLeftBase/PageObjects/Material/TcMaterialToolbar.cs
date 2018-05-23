using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Shell;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Material
{
    /// <summary>
    /// The material toolbar.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcToolbars}" />
    public class TcMaterialToolbar : PageObject, IChildOf<TcToolbars>
    {
        protected override Search SearchPattern => Search.ByUid( "Material.Toolbar" );

        /// <summary>
        /// Gets the new button.
        /// </summary>
        /// <value>
        /// The new button.
        /// </value>
        public TcTruIconButton NewButton => Find<TcTruIconButton>( Search.ByUid( "Material.Toolbar.New" ) );

        /// <summary>
        /// Gets the duplicate button.
        /// </summary>
        /// <value>
        /// The duplicate button.
        /// </value>
        public TcTruIconButton DuplicateButton => Find<TcTruIconButton>( Search.ByUid( "Material.Toolbar.Duplicate" ) );

        /// <summary>
        /// Gets the save button.
        /// </summary>
        /// <value>
        /// The save button.
        /// </value>
        public TcTruIconButton SaveButton => Find<TcTruIconButton>( Search.ByUid( "Material.Toolbar.Save" ) );

        /// <summary>
        /// Gets the revert button.
        /// </summary>
        /// <value>
        /// The revert button.
        /// </value>
        public TcTruIconButton RevertButton => Find<TcTruIconButton>( Search.ByUid( "Material.Toolbar.Revert" ) );

        /// <summary>
        /// Gets the delete button.
        /// </summary>
        /// <value>
        /// The delete button.
        /// </value>
        public TcTruIconButton DeleteButton => Find<TcTruIconButton>( Search.ByUid( "Material.Toolbar.Delete" ) );

        /// <summary>
        /// Gets the lock material button.
        /// </summary>
        /// <value>
        /// The lock material button.
        /// </value>
        public TcTruIconButton LockMaterialButton => Find<TcTruIconButton>( Search.ByUid( "Material.Toolbar.LockMaterial" ) );

        /// <summary>
        /// Gets the unlock material button.
        /// </summary>
        /// <value>
        /// The unlock material button.
        /// </value>
        public TcTruIconButton UnlockMaterialButton => Find<TcTruIconButton>( Search.ByUid( "Material.Toolbar.UnlockMaterial" ) );
    }
}
