using System;
using SmartBear.TestLeft;
using HomeZone.UiObjectInterfaces;


namespace HomeZone.UiObjects
{
    public abstract class TcApp : TiApp
    {
        protected TcApp( IDriver driver )
        {
            this.Driver = driver;
        }

        /// <summary>
        ///  Gets the TestExecute driver used by this instance.
        /// </summary>
        /// <value>
        /// The driver.
        /// </value>
        public IDriver Driver { get; }

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
