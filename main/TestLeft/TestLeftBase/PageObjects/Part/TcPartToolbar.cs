using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// The part toolbar.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcToolbars}" />
    public class TcPartToolbar : PageObject, IChildOf<TcToolbars>
    {
        protected override Search SearchPattern => Search.ByUid( "Part.Toolbar" );

        /// <summary>
        /// Gets the new part button.
        /// </summary>
        /// <value>
        /// The new part button.
        /// </value>
        public TcTruIconButton NewPartButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.New" ) );

        /// <summary>
        /// Gets the duplicate button.
        /// </summary>
        /// <value>
        /// The duplicate button.
        /// </value>
        public TcTruIconButton DuplicateButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.Duplicate" ) );

        /// <summary>
        /// Gets the import button.
        /// </summary>
        /// <value>
        /// The import button.
        /// </value>
        public TcTruIconButton ImportButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.Import" ) );

        /// <summary>
        /// Gets the export button.
        /// </summary>
        /// <value>
        /// The export button.
        /// </value>
        public TcTruIconButton ExportButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.Export" ) );

        /// <summary>
        /// Gets the boost button.
        /// </summary>
        /// <value>
        /// The boost button.
        /// </value>
        public TcTruIconButton BoostButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.CalculateAll" ) );

        /// <summary>
        /// Gets the create part order button.
        /// </summary>
        /// <value>
        /// The create part order button.
        /// </value>
        public TcTruIconButton CreatePartOrderButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.CreatePartOrder" ) );

        /// <summary>
        /// Gets the create cut job button.
        /// </summary>
        /// <value>
        /// The create cut job button.
        /// </value>
        public TcTruIconButton CreateCutJobButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.CreateCutJob" ) );

        /// <summary>
        /// Gets the save button.
        /// </summary>
        /// <value>
        /// The save button.
        /// </value>
        public TcTruIconButton SaveButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.Save" ) );

        /// <summary>
        /// Gets the revert button.
        /// </summary>
        /// <value>
        /// The revert button.
        /// </value>
        public TcTruIconButton RevertButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.Revert" ) );

        /// <summary>
        /// Gets the delete button.
        /// </summary>
        /// <value>
        /// The delete button.
        /// </value>
        public TcTruIconButton DeleteButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.Delete" ) );

        /// <summary>
        /// Gets the move to archive button.
        /// </summary>
        /// <value>
        /// The move to archive button.
        /// </value>
        public TcTruIconButton MoveToArchiveButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.MoveToArchive" ) );

        /// <summary>
        /// Gets the remove from archive button.
        /// </summary>
        /// <value>
        /// The remove from archive button.
        /// </value>
        public TcTruIconButton RemoveFromArchiveButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.RemoveFromArchive" ) );

        /// <summary>
        /// Gets the lock part button.
        /// </summary>
        /// <value>
        /// The lock part button.
        /// </value>
        public TcTruIconButton LockPartButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.LockPart" ) );

        /// <summary>
        /// Gets the unlock part button.
        /// </summary>
        /// <value>
        /// The unlock part button.
        /// </value>
        public TcTruIconButton UnlockPartButton => Find<TcTruIconButton>( Search.ByUid( "Part.Toolbar.UnlockPart" ) );
    }
}
