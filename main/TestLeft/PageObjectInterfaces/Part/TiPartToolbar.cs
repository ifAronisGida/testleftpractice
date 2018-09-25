using PageObjectInterfaces.Controls;

namespace PageObjectInterfaces.Part
{
    public interface TiPartToolbar
    {
        /// <summary>
        /// Gets the new part button.
        /// </summary>
        /// <value>
        /// The new part button.
        /// </value>
        TiButton NewPartButton { get; }

        /// <summary>
        /// Gets the duplicate button.
        /// </summary>
        /// <value>
        /// The duplicate button.
        /// </value>
        TiButton DuplicateButton { get; }

        /// <summary>
        /// Gets the import button.
        /// </summary>
        /// <value>
        /// The import button.
        /// </value>
        TiButton ImportButton { get; }

        /// <summary>
        /// Gets the export button.
        /// </summary>
        /// <value>
        /// The export button.
        /// </value>
        TiButton ExportButton { get; }

        /// <summary>
        /// Gets the boost button.
        /// </summary>
        /// <value>
        /// The boost button.
        /// </value>
        TiButton BoostButton { get; }

        /// <summary>
        /// Gets the create part order button.
        /// </summary>
        /// <value>
        /// The create part order button.
        /// </value>
        TiButton CreatePartOrderButton { get; }

        /// <summary>
        /// Gets the create cut job button.
        /// </summary>
        /// <value>
        /// The create cut job button.
        /// </value>
        TiButton CreateCutJobButton { get; }

        /// <summary>
        /// Gets the save button.
        /// </summary>
        /// <value>
        /// The save button.
        /// </value>
        TiButton SaveButton { get; }

        /// <summary>
        /// Gets the revert button.
        /// </summary>
        /// <value>
        /// The revert button.
        /// </value>
        TiButton RevertButton { get; }

        /// <summary>
        /// Gets the delete button.
        /// </summary>
        /// <value>
        /// The delete button.
        /// </value>
        TiButton DeleteButton { get; }
    }
}
