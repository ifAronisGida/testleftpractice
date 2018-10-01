using PageObjectInterfaces.Controls;


namespace PageObjectInterfaces.Material
{
    public interface TiMaterialToolbar
    {
        /// <summary>
        /// Gets the new button.
        /// </summary>
        /// <value>
        /// The new button.
        /// </value>
        TiButton NewButton { get; }

        /// <summary>
        /// Gets the duplicate button.
        /// </summary>
        /// <value>
        /// The duplicate button.
        /// </value>
        TiButton DuplicateButton { get; }

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

        /// <summary>
        /// Gets the lock material button.
        /// </summary>
        /// <value>
        /// The lock material button.
        /// </value>
        TiButton LockMaterialButton { get; }

        /// <summary>
        /// Gets the unlock material button.
        /// </summary>
        /// <value>
        /// The unlock material button.
        /// </value>
        TiButton UnlockMaterialButton { get; }
    }
}
