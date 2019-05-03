namespace HomeZone.UiObjectInterfaces.Common
{
    public interface TiToolbar : TiVisibility
    {
        bool CanSave { get; }
        bool CanDelete { get; }
        bool CanRevert { get; }

        void Save();

        /// <summary>
        /// Deletes the item.
        /// </summary>
        void Delete();

        /// <summary>
        /// Reverts the item.
        /// </summary>
        void Revert();
    }
}
