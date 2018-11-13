using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.Material
{
    public interface TiMaterialToolbar : TiVisibility
    {
        bool CanSave { get; }
        bool CanDelete { get; }
        bool CanRevert { get; }

        /// <summary>
        /// Creates a new material.
        /// </summary>
        void New();

        /// <summary>
        /// Duplicates the current material.
        /// </summary>
        void Duplicate();

        /// <summary>
        /// Saves the current material.
        /// </summary>
        void Save();

        /// <summary>
        /// Deletes the current material.
        /// </summary>
        /// <returns>true if successful</returns>
        void Delete();
    }
}
