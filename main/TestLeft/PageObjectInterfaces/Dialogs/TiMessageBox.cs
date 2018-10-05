using Trumpf.PageObjects;

namespace PageObjectInterfaces.Dialogs
{
    public interface TiMessageBox : IPageObject
    {
        /// <summary>
        /// Returns true if a message box exists.
        /// </summary>
        /// <returns>True if a message box exists, otherwise false.</returns>
        bool MessageBoxExists();

        /// <summary>
        /// Clicks the yes button.
        /// </summary>
        void Yes();
    }
}
