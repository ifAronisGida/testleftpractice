using System;
using System.Threading;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Flux
{
    /// <summary>
    /// PageObject for the Flux app.
    /// </summary>
    /// <seealso cref="RepeaterObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcFluxApp}" />
    public class TcFlux : PageObject
    {
        protected override Search SearchPattern => Search.Any;

        private TcFluxApp mFluxApp;
        private IControl mMainWindow;
        private IDriver mDriver;

        public TcFlux( IDriver driver )
        {
            mDriver = driver;
        }

        /// <summary>
        /// Gets a value indicating whether the Flux window is visible.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="retryWaitTime">The retry wait time.</param>
        /// <returns></returns>
        /// <value>
        ///   <c>true</c> if Flux window is visible; otherwise, <c>false</c>.
        /// </value>
        public bool FluxWindowVisible( TimeSpan timeout, TimeSpan retryWaitTime )
        {
            mFluxApp = null;
            mMainWindow = null;
            var startTime = DateTime.Now;

            while( DateTime.Now - startTime < timeout )
            {
                bool fluxProcessFound;
                var index = 1;          // first index is 1

                do
                {
                    IProcess flux;

                    // search Flux process
                    fluxProcessFound = mDriver.TryFind<IProcess>( new ProcessPattern()
                    {
                        ProcessName = "Flux",
                        Index = index
                    }, 1, out flux );

                    if( fluxProcessFound )       // search MainWindow
                    {
                        mFluxApp = new TcFluxApp( flux ) { Driver = mDriver };

                        IControl window = null;
                        if( mFluxApp.Node.TryFind<IControl>( new WPFPattern { ClrFullClassName = "Flux.App.MainWindow" }, out window, 2 ) )
                        {
                            if( window.VisibleOnScreen )         // -> found, store MainWindow and return
                            {
                                mMainWindow = window;
                                return true;
                            }
                        }
                    }

                    index++;    // -> not found, search next Flux process

                } while( fluxProcessFound );

                Thread.Sleep( retryWaitTime );        // nothing found, wait and retry until timeout
            }

            mFluxApp = null;
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
