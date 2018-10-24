using UiObjectInterfaces.Controls;


namespace UiObjectInterfaces.Common
{
    public interface TiResultColumn
    {
        /// <summary>
        /// Gets the amount of items in the result list.
        /// </summary>
        /// <value>
        /// The amount of items in the result list.
        /// </value>
        int Count { get; }

        /// <summary>
        /// Clears the search text if it is not empty.
        /// </summary>
        void ClearSearch();

        /// <summary>
        /// Executes the search.
        /// </summary>
        void DoSearch();

        /// <summary>
        /// Gets the search text control.
        /// </summary>
        /// <value>
        /// The search text control.
        /// </value>
        TiValueControl<string> SearchText { get; }

        /// <summary>
        /// Selects the item with the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if item found, else false</returns>
        bool SelectItem( string id );

        /// <summary>
        /// Selects all items suitable for the given search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <returns>The amount of selected entries.</returns>
        int SelectItems( string searchText );

        /// <summary>
        /// Selects all items.
        /// </summary>
        /// <returns>The amount of selected entries.</returns>
        int SelectAll();

        /// <summary>
        /// Gets the amount of selected items.
        /// </summary>
        /// <value>
        /// The amount of selected items.
        /// </value>
        int SelectedItemsCount { get; }
    }
}
