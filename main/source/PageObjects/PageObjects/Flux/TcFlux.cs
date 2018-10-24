using System;
using System.Threading;
using PageObjectInterfaces.Flux;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Flux
{
    /// <summary>
    /// PageObject for the Flux app.
    /// </summary>
    public class TcFlux : TcApp, TiFlux
    {
        private TcAppProcess mApp;
        private IControl mMainWindow;
        private readonly string mFluxProcessName;

        public TcFlux( string fluxProcessName, IDriver driver ) : base( driver )
        {
            mFluxProcessName = fluxProcessName;
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
                        ProcessName = mFluxProcessName,
                        Index = index
                    }, 1, out var flux );

                    if( processFound )       // search MainWindow
                    {
                        mApp = new TcAppProcess( flux, Driver );

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
        /// Saves the and close part in flux.
        /// </summary>
        public void SaveAndClosePartInFlux()
        {
            // Open the menu File
            var fileButton = mMainWindow.Find<IWPFMenu>( new WPFPattern()
            {
                WPFControlName = "mMainMenu"
            }, 3 ).Find<IControl>( new WPFPattern()
            {
                WPFControlName = "menuFile"
            } );
            fileButton.Click();

            // Press save
            IProcess flux = Driver.Find<IProcess>( new ProcessPattern()
            {
                ProcessName = mFluxProcessName
            } );
            flux.TryFind<IControl>( new WPFPattern { ClrFullClassName = "System.Windows.Controls.Primitives.PopupRoot" }, 2, out var popup );
            var save = popup.Find<IControl>( new WPFPattern()
            {
                WPFControlName = "menuSave"
            }, 3 );
            save.Click();

            // Close flux
            var close = mMainWindow.Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.Image",
                WPFControlOrdinalNo = 3
            }, 5 );
            close.Click();
        }

        /// <summary>
        /// Changes the solution.
        /// WARNING: This function is language dependent
        /// </summary>
        public void ChangeSolution()
        {
            // Skip 1st bend
            IProcess flux = Driver.Find<IProcess>( new ProcessPattern()
            {
                ProcessName = mFluxProcessName
            } );
            var firstBend = flux.Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "Flux.BendNavigator"
            }, 2 ).Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.TextBlock",
                WPFControlText = "1"
            }, 7 );
            firstBend.Click();

            var skipBendButton = flux.Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "Flux.GlobHost"
            }, 2 ).Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.TextBlock",
                WPFControlText = "Biegung überspringen"  // This is not language independent
            }, 4 );
            skipBendButton.Click();

            // close part
            var close = mMainWindow.Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.Image",
                WPFControlOrdinalNo = 3
            }, 5 );
            close.Click();

            // check for message box
            var noButton = flux.Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "Flux.MsgBox"
            }, 2 ).Find<IButton>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.Button",
                WPFControlText = "Nein"  // This is not language independent
            }, 3 );
            noButton.Click();
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        public override void CloseApp()
        {
            mMainWindow?.CallMethod( "Close" );
        }
    }
}
