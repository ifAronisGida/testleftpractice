using System;
using System.Threading;
using PageObjectInterfaces.Cut;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.Qt;

namespace TestLeft.TestLeftBase.PageObjects.Cut
{
    /// <summary>
    /// PageObject for the Cut app.
    /// </summary>
    public class TcCut : TcApp, TiCut
    {
        private TcAppProcess mApp;
        private ITopLevelWindow mMainWindow;
        private readonly Lazy<TcTTSelectionDialog> mTTSelectionDialog;

        public TcCut( IDriver driver ) : base( driver )
        {
            mTTSelectionDialog = new Lazy<TcTTSelectionDialog>( () => new TcTTSelectionDialog( Driver ) );
        }

        /// <summary>
        /// Gets a value indicating whether the main window is visible.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="retryWaitTime">The retry wait time.</param>
        /// <returns>
        ///   <c>true</c> if main window is visible; otherwise, <c>false</c>.
        /// </returns>
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
                        ProcessName = "cut",
                        Index = index
                    }, 1, out var proc );

                    if( processFound )       // search MainWindow
                    {
                        mApp = new TcAppProcess( proc, Driver );

                        if( mApp.Node.TryFind<ITopLevelWindow>( new QtPattern { objectName = "qt_ribbonMainWindow" }, out var window, 1 ) )
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
        /// Gets the technology table selection dialog.
        /// </summary>
        /// <value>
        /// The technology table selection dialog.
        /// </value>
        public TiTTSelectionDialog TechnologyTableSelectionDialog => mTTSelectionDialog.Value;

        /// <summary>
        /// Closes the application.
        /// </summary>
        public override void CloseApp()
        {
            mMainWindow?.CallMethod( "Close" );

            var messageBox = mApp.On<TcCutMessageBox>();
            if( messageBox.MessageBoxExists() )
            {
                messageBox.No();
            }
        }
    }
}
