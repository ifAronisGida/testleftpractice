using System;

namespace PageObjectInterfaces
{
    public interface TiApp
    {
        /// <summary>
        /// Gets a value indicating whether the main window is visible.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="retryWaitTime">The retry wait time.</param>
        /// <returns></returns>
        /// <value>
        ///   <c>true</c> if main window is visible; otherwise, <c>false</c>.
        /// </value>
        bool IsMainWindowVisible( TimeSpan timeout, TimeSpan retryWaitTime );

        /// <summary>
        /// Closes the application.
        /// </summary>
        void CloseApp();
    }
}
