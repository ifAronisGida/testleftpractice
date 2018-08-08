using System;
using System.Threading;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Flux
{
    /// <summary>
    /// PageObject for the Flux app.
    /// </summary>
    public class TcFlux
    {
        private TcFluxApp mApp;
        private IControl mMainWindow;
        private readonly IDriver mDriver;

        public TcFlux( IDriver driver )
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
                        ProcessName = "Flux",
                        Index = index
                    }, 1, out var flux );

                    if( processFound )       // search MainWindow
                    {
                        mApp = new TcFluxApp( flux ) { Driver = mDriver };

                        try
                        {
                            if( mApp.Node.TryFind<IControl>( new WPFPattern { ClrFullClassName = "Flux.App.MainWindow" }, out var window, 2 ) )
                            {
                                if( window.VisibleOnScreen )         // -> found, store MainWindow and return
                                {
                                    mMainWindow = window;
                                    return true;
                                }
                            }
                        }
                        catch( Exception )
                        {
                            // empty
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
        /// DEMO
        /// </summary>
        /// <returns>true</returns>
        public bool MenuFile()
        {
            var rc = mMainWindow.Find<IWPFMenu>( new WPFPattern()
            {
                WPFControlName = "mMainMenu"
            }, 3 ).Find<IControl>( new WPFPattern()
            {
                WPFControlName = "menuFile"
            } );

            // MainWindow holen:
            // IDriver driver = new LocalDriver();
            // IControl menuItem = driver.Find<IProcess>(new ProcessPattern(){ 
            //	                                                ProcessName = "Flux" 
            //                                                  }).Find<IControl>(new WPFPattern(){ 
            //	                                                                    ClrFullClassName = "Flux.App.MainWindow" 
            //                                                                      }, 2)       

            // dann den Menüeintrag finden:
            // .Find<IWPFMenu>(new WPFPattern()
            //    { 
            //      WPFControlName = "mMainMenu" 
            //    }, 3).Find<IControl>(new WPFPattern()
            //    { 
            //	    WPFControlName = "menuFile" 
            //    });
            
            return true;
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        public void CloseApp()
        {
            mMainWindow?.CallMethod( "Close" );
        }
    }
}
