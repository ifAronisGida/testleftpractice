using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.Material
{
    public interface TiMaterialToolbar : TiToolbar
    {
        /// <summary>
        /// Creates a new material.
        /// </summary>
        void New();

        /// <summary>
        /// Duplicates the current material.
        /// </summary>
        void Duplicate();
    }
}
