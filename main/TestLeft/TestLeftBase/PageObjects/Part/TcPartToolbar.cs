using PageObjectInterfaces.Controls;
using PageObjectInterfaces.Part;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// The part toolbar.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcToolbars}" />
    public class TcPartToolbar : PageObjectBase, IChildOf<TcToolbars>, TiPartToolbar
    {
        protected override Search SearchPattern => Search.ByUid( "Part.Toolbar" );

        /// <summary>
        /// Gets the new part button.
        /// </summary>
        /// <value>
        /// The new part button.
        /// </value>
        public TiButton NewPartButton => Find<TiButton>( "Part.Toolbar.New" );

        /// <summary>
        /// Gets the duplicate button.
        /// </summary>
        /// <value>
        /// The duplicate button.
        /// </value>
        public TiButton DuplicateButton => Find<TiButton>( "Part.Toolbar.Duplicate" );

        /// <summary>
        /// Gets the import button.
        /// </summary>
        /// <value>
        /// The import button.
        /// </value>
        public TiButton ImportButton => Find<TiButton>( "Part.Toolbar.Import" );

        /// <summary>
        /// Gets the export button.
        /// </summary>
        /// <value>
        /// The export button.
        /// </value>
        public TiButton ExportButton => Find<TiButton>( "Part.Toolbar.Export" );

        /// <summary>
        /// Gets the boost button.
        /// </summary>
        /// <value>
        /// The boost button.
        /// </value>
        public TiButton BoostButton => Find<TiButton>( "Part.Toolbar.CalculateAll" );

        /// <summary>
        /// Gets the create part order button.
        /// </summary>
        /// <value>
        /// The create part order button.
        /// </value>
        public TiButton CreatePartOrderButton => Find<TiButton>( "Part.Toolbar.CreatePartOrder" );

        /// <summary>
        /// Gets the create cut job button.
        /// </summary>
        /// <value>
        /// The create cut job button.
        /// </value>
        public TiButton CreateCutJobButton => Find<TiButton>( "Part.Toolbar.CreateCutJob" );

        /// <summary>
        /// Gets the save button.
        /// </summary>
        /// <value>
        /// The save button.
        /// </value>
        public TiButton SaveButton => Find<TiButton>( "Part.Toolbar.Save" );

        /// <summary>
        /// Gets the revert button.
        /// </summary>
        /// <value>
        /// The revert button.
        /// </value>
        public TiButton RevertButton => Find<TiButton>( "Part.Toolbar.Revert" );

        /// <summary>
        /// Gets the delete button.
        /// </summary>
        /// <value>
        /// The delete button.
        /// </value>
        public TiButton DeleteButton => Find<TiButton>( "Part.Toolbar.Delete" );

        /// <summary>
        /// Gets the move to archive button.
        /// </summary>
        /// <value>
        /// The move to archive button.
        /// </value>
        public TiButton MoveToArchiveButton => Find<TiButton>( "Part.Toolbar.MoveToArchive" );

        /// <summary>
        /// Gets the remove from archive button.
        /// </summary>
        /// <value>
        /// The remove from archive button.
        /// </value>
        public TiButton RemoveFromArchiveButton => Find<TiButton>( "Part.Toolbar.RemoveFromArchive" );

        /// <summary>
        /// Gets the lock part button.
        /// </summary>
        /// <value>
        /// The lock part button.
        /// </value>
        public TiButton LockPartButton => Find<TiButton>( "Part.Toolbar.LockPart" );

        /// <summary>
        /// Gets the unlock part button.
        /// </summary>
        /// <value>
        /// The unlock part button.
        /// </value>
        public TiButton UnlockPartButton => Find<TiButton>( "Part.Toolbar.UnlockPart" );
    }
}
