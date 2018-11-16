namespace HomeZone.UiObjectInterfaces.Common
{
    public interface TiResultColumn<T> : TiResultColumn where T : class
    {
        /// <summary>
        /// Returns the item at the given index, or null if the list is empty or the index is out of bounds.
        /// </summary>
        /// <param name="index">Zero-based index of the item in the list.</param>
        /// <returns>The item at the given index</returns>
        T GetItem( int index );

        /// <summary>
        /// Returns the selected item, or null if the list is empty or nothing is selected.
        /// </summary>
        /// <returns>The selected item</returns>
        T SelectedItem();
    }
}
