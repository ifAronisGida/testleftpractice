using System;
using PageObjectInterfaces.Common;

namespace PageObjectInterfaces.Material
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
        /// Goto the page object, i.e. perform necessary action to make the page object visible on screen, do nothing if the page is already visible on screen.
        /// </summary>
        void Goto();

        /// <summary>
        /// Waits for detail overlay appear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        bool WaitForDetailOverlayAppear( TimeSpan timeout );

        /// <summary>
        /// Waits for detail overlay disappear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        bool WaitForDetailOverlayDisappear( TimeSpan timeout );

        /// <summary>
        /// Deletes the given material.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if successful</returns>
        bool DeleteMaterial( string id );
    }
}
