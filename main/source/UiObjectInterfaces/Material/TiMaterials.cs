using System;
using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.Material
{
    public interface TiMaterials : TiDomain
    {
        /// <summary>
        /// Gets the toolbar.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        TiMaterialToolbar Toolbar { get; }

        /// <summary>
        /// Gets the detail area.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        TiMaterialDetail Detail { get; }

        /// <summary>
        /// Deletes the given material.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if successful</returns>
        bool DeleteMaterial( string id );
    }
}
