using System;


namespace UiObjectInterfaces.Cut
{
    public interface TiTTSelectionDialog
    {
        /// <summary>
        /// Gets a value indicating whether the dialog is visible.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="retryWaitTime">The retry wait time.</param>
        /// <returns>
        ///   <c>true</c> if main window is visible; otherwise, <c>false</c>.
        /// </returns>
        bool IsDialogVisible( TimeSpan timeout, TimeSpan retryWaitTime );

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        void Close();
    }
}
