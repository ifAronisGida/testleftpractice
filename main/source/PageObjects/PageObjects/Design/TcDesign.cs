using System;
using System.Threading;
using PageObjectInterfaces.Design;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WinForms;

namespace TestLeft.TestLeftBase.PageObjects.Design
{
    /// <summary>
    /// PageObject for the Design app.
    /// </summary>
    public class TcDesign : TcApp, TiDesign
    {
        private TcAppProcess mApp;
        private ITopLevelWindow mMainWindow;

        public TcDesign( IDriver driver ) : base( driver )
        {
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
        public override bool IsMainWindowVisible( TimeSpan timeout, TimeSpan retryWaitTime )
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
                    processFound = Driver.TryFind<IProcess>( new ProcessPattern()
                    {
                        ProcessName = "SpaceClaim",
                        Index = index
                    }, 1, out var proc );

                    if( processFound )       // search MainWindow
                    {
                        mApp = new TcAppProcess( proc, Driver );

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
        /// Closes the Design application.
        /// </summary>
        public override void CloseApp()
        {
            mMainWindow?.CallMethod( "Close" );

            var messageBox = mApp.On<TcDesignMessageBox>();
            if( messageBox.MessageBoxExists() )
            {
                messageBox.No();
            }
        }
    }
}
