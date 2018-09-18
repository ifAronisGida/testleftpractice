#region HEADER
//--------------------------------------------------------------------------------------------------
// All rights reserved to TRUMPF GmbH + Co. KG, Germany
// -------------------------------------------------------------------------------------------------
//
//$File: //SW08/HomeZone_Testing/main/TestLeft/TestLeftBase/PageObjects/Flux/TcFluxConfigureMachine.cs $
//$Author: gutzwillersi $
//$Revision: #1 $ - $Date: 2018/08/29 $ 
// -------------------------------------------------------------------------------------------------
#endregion

#region USING

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;

#endregion

namespace TestLeft.TestLeftBase.PageObjects.Flux
{
    public class TcFluxConfigureMachine
    {
        #region private constants
        #endregion

        #region constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">The driver.</param>
        public TcFluxConfigureMachine( IDriver driver )
        {
            mDriver = driver;
        }

        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Is the tools dialog visible?
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="retryWaitTime">The retry wait time.</param>
        /// <returns>true if visible</returns>
        public bool MachineDialogVisible( TimeSpan timeout, TimeSpan retryWaitTime )
        {
            mApp = null;
            mMachineDialog = null;
            DateTime startTime = DateTime.Now;
            bool visible = false;

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
                            if( mApp.Node.TryFind<IControl>( new WPFPattern { ClrFullClassName = "Flux.App.MachineDBDlg" }, out var window, 2 ) )
                            {
                                if( window.VisibleOnScreen )
                                {
                                    mMachineDialog = window;
                                    visible = true;
                                }
                            }
                        }
                        catch( Exception )
                        {
                            break;
                        }
                    }

                    index++;    // -> not found, search next process

                } while( processFound );

                Thread.Sleep( retryWaitTime );        // nothing found, wait and retry until timeout
            }

            return visible;
        }

        public void CloseMachienDialog()
        {
            var closeButton = mMachineDialog.Find<IControl>( new WPFPattern()
            {
                WPFControlName = "cCloseBtn"
            }, 4 );
            closeButton.Click();
        }

        #endregion

        #region private methods
        #endregion

        #region public static members
        #endregion

        #region private static members
        #endregion

        #region private members

        /// <summary>
        /// The driver
        /// </summary>
        private readonly IDriver mDriver;

        /// <summary>
        /// The application
        /// </summary>
        private TcFluxApp mApp;

        /// <summary>
        /// The machine dialog
        /// </summary>
        private IControl mMachineDialog;

        #endregion

        #region properties

        #endregion
    }
}