using System;
using System.Threading;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WinForms;

namespace TestLeft.TestLeftBase.PageObjects.Design
{
    /// <summary>
    /// PageObject for the Design app.
    /// </summary>
    public class TcDesign
    {
        private TcDesignApp mApp;
        private ITopLevelWindow mMainWindow;
        private readonly IDriver mDriver;

        public TcDesign( IDriver driver )
        {
            mDriver = driver;
        }

        /// <summary>
        /// Gets a value indicating whether the main window is visible.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="retryWaitTime">The retry wait time.</param>
        /// <returns></returns>
        /// <value>
        ///   <c>true</c> if main window is visible; otherwise, <c>false</c>.
        /// </value>
        public bool MainWindowVisible( TimeSpan timeout, TimeSpan retryWaitTime )
        {
            mApp = null;
            mMainWindow = null;
            var startTime = DateTime.Now;

            while( DateTime.Now - startTime < timeout )
            {
                bool processFound;
                var index = 1;          // first index is 1

                do
                {
                    // search process
                    processFound = mDriver.TryFind<IProcess>( new ProcessPattern()
                    {
                        ProcessName = "SpaceClaim",
                        Index = index
                    }, 1, out var proc );

                    if( processFound )       // search MainWindow
                    {
                        mApp = new TcDesignApp( proc ) { Driver = mDriver };

                        if( mApp.Node.TryFind<ITopLevelWindow>( new WinFormsPattern { WinFormsControlName = "MainForm" }, out var window, 1 ) )
                        {
                            if( window.VisibleOnScreen )         // -> found, store MainWindow and return
                            {
                                mMainWindow = window;
                                return true;
                            }
                        }
                    }

                    index++;    // -> not found, search next process

                } while( processFound );

                Thread.Sleep( retryWaitTime );        // nothing found, wait and retry until timeout
            }

            mApp = null;
            mMainWindow = null;

            return false;
        }

        /// <summary>
        /// Closes the Flux application.
        /// </summary>
        public void CloseApp()
        {
            mMainWindow?.CallMethod( "Close" );
        }
    }
}
