using System;
using PageObjectInterfaces;
using SmartBear.TestLeft;

namespace TestLeft.TestLeftBase
{
    public abstract class TcApp : TiApp
    {
        /// <summary>
        ///  Gets or sets the (static) TestExecute driver.
        /// </summary>
        /// <value>
        /// The driver.
        /// </value>
        public IDriver Driver { get; set; }

        /// <summary>
        /// Gets a value indicating whether the main window is visible.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="retryWaitTime">The retry wait time.</param>
        /// <returns></returns>
        /// <value>
        ///   <c>true</c> if main window is visible; otherwise, <c>false</c>.
        /// </value>
        public abstract bool IsMainWindowVisible( TimeSpan timeout, TimeSpan retryWaitTime );

        /// <summary>
        /// Closes the application.
        /// </summary>
        public abstract void CloseApp();
    }
}
