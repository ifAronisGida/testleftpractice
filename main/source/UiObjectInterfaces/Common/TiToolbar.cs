namespace HomeZone.UiObjectInterfaces.Common
{
    public interface TiToolbar : TiVisibility
    {
        bool CanSave { get; }
        bool CanDelete { get; }
        bool CanRevert { get; }

        void Save();

        /// <summary>
        /// Save button should be enabled.
        /// </summary>
        void SaveShouldBeEnabled();

        /// <summary>
        /// Save button should be disabled.
        /// </summary>
        void SaveShouldBeDisabled();

        /// <summary>
        /// Deletes the item.
        /// </summary>
        void Delete();

        /// <summary>
        /// Delete button should be enabled.
        /// </summary>
        void DeleteShouldBeEnabled();

        /// <summary>
        /// Delete button should be disabled.
        /// </summary>
        void DeleteShouldBeDisabled();

        /// <summary>
        /// Reverts the item.
        /// </summary>
        void Revert();

        /// <summary>
        /// Revert button should be enabled.
        /// </summary>
        void RevertShouldBeEnabled();

        /// <summary>
        /// Revert button should be disabled.
        /// </summary>
        void RevertShouldBeDisabled();
    }
}
