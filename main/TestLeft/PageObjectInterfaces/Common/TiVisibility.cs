namespace PageObjectInterfaces.Common
{
    public interface TiVisibility
    {
        /// <summary>
        /// Waits until visible.
        /// </summary>
        /// <returns>true if visible</returns>
        bool WaitUntilVisible();
    }
}
