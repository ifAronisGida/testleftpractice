using System;
using System.Threading;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using HomeZone.UiObjectInterfaces.Cut;


namespace HomeZone.UiObjects.PageObjects.Cut
{
    /// <summary>
    /// PageObject for the technology table selection dialog.
    /// </summary>
    public class TcTTSelectionDialog : TiTTSelectionDialog
    {
        private TcAppProcess mApp;
        private ITopLevelWindow mWindow;
        private readonly IDriver mDriver;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcTTSelectionDialog"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        public TcTTSelectionDialog( IDriver driver )
        {
            mDriver = driver;
        }

        /// <summary>
        /// Gets a value indicating whether the dialog is visible.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="retryWaitTime">The retry wait time.</param>
        /// <returns>
        ///   <c>true</c> if main window is visible; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDialogVisible( TimeSpan timeout, TimeSpan retryWaitTime )
        {
            mApp = null;
            mWindow = null;

            var tts = TcAppLangDependentStrings.Get( TeStringKey.TechnologyTableSelection );
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
                        ProcessName = "cut",
                        Index = index
                    }, 1, out var proc );

                    if( processFound )       // search dialog
                    {
                        mApp = new TcAppProcess( proc, mDriver );

                        if( mApp.Node.TryFind<ITopLevelWindow>( new WindowPattern()
                                                                    {
                                                                        WndClass = "GritDialogWindow",
                                                                        WndCaption = tts
                                                                    }, out var window, 1 ) )

                        {
                            if( window.VisibleOnScreen )         // -> found, store dialog window and return
                            {
                                mWindow = window;
                                return true;
                            }
                        }
                    }

                    index++;    // -> not found, search next process

                } while( processFound );

                Thread.Sleep( retryWaitTime );        // nothing found, wait and retry until timeout
            }

            mApp = null;
            mWindow = null;

            return false;
        }

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        public void Close()
        {
            mWindow?.CallMethod( "Close" );
        }
    }
}
