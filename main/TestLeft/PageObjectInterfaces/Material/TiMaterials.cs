using System;
using PageObjectInterfaces.Common;
using Trumpf.PageObjects.Waiting;


namespace PageObjectInterfaces.Material
{
    public interface TiMaterials
    {
        /// <summary>
        /// Gets the toolbar.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        TiMaterialToolbar Toolbar { get; }

        /// <summary>
        /// Gets the result column.
        /// </summary>
        /// <value>
        /// The result column.
        /// </value>
        TiResultColumn ResultColumn { get; }

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
        /// Creates a new material.
        /// </summary>
        void NewMaterial();

        /// <summary>
        /// Duplicates the current material.
        /// </summary>
        void DuplicateMaterial();

        /// <summary>
        /// Saves the current material.
        /// </summary>
        void SaveMaterial();

        /// <summary>
        /// Deletes the current material.
        /// </summary>
        /// <returns>true if successful</returns>
        bool DeleteMaterial();

        /// <summary>
        /// Deletes the given material.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if successful</returns>
        bool DeleteMaterial( string id );

        /// <summary>
        /// Selects the material via identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if found</returns>
        bool SelectMaterial( string id );

        /// <summary>
        /// Selects the materials containing the given search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <returns>The amount of selected materials.</returns>
        int SelectMaterials( string searchText );

        /// <summary>
        /// Selects all materials.
        /// </summary>
        /// <returns>The amount of selected materials.</returns>
        int SelectAll();
    }
}
