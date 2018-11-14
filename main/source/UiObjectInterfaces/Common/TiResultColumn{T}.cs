namespace HomeZone.UiObjectInterfaces.Common
{
    public interface TiResultColumn<T> : TiResultColumn where T : class
    {
        /// <summary>
        /// Returns the item at the given index, or null if the list is empty or the index is out of bounds.
        /// </summary>
        /// <param name="index">Zero-based index of the item in the list.</param>
        /// <returns></returns>
        T GetItem(int index);
    }
}
