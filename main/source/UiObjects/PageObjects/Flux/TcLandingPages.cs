#region HEADER
//--------------------------------------------------------------------------------------------------
// All rights reserved to TRUMPF GmbH + Co. KG, Germany
// -------------------------------------------------------------------------------------------------
//
//$File: //SW08/HomeZone_Testing/main/source/UiObjects/PageObjects/Flux/TcLandingPages.cs $
//$Author: steinertth $
//$Revision: #1 $ - $Date: 2018/10/24 $ 
// -------------------------------------------------------------------------------------------------
#endregion

#region USING
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using System;
using System.Threading;
#endregion

namespace HomeZone.UiObjects.PageObjects.Flux
{
    public class TcLandingPages
    {
        #region private constants
        #endregion

        #region constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">The driver.</param>
        public TcLandingPages( IDriver driver )
        {
            mDriver = driver;
        }

        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Is the bend factors dialog visible?
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="retryWaitTime">The retry wait time.</param>
        /// <returns>true if visible</returns>
        public bool BendFactorsDialogVisible( TimeSpan timeout, TimeSpan retryWaitTime )
        {
            mApp = null;
            mBendFactorDialog = null;
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
                        mApp = new TcAppProcess( flux, mDriver );

                        try
                        {
                            if( mApp.Node.TryFind<IControl>( new WPFPattern { ClrFullClassName = "Flux.App.UserBendDBDlg" }, out var window, 2 ) )
                            {
                                if( window.VisibleOnScreen )
                                {
                                    mBendFactorDialog = window;
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

        /// <summary>
        /// Is the settings dialog visible?
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="retryWaitTime">The retry wait time.</param>
        /// <returns>true if visible</returns>
        public bool SettingsDialogVisible( TimeSpan timeout, TimeSpan retryWaitTime )
        {
            mApp = null;
            mSettingsDialog = null;
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
                        mApp = new TcAppProcess( flux, mDriver );

                        try
                        {
                            if( mApp.Node.TryFind<IControl>( new WPFPattern { ClrFullClassName = "Flux.SheafEdit" }, out var window, 2 ) )
                            {
                                if( window.VisibleOnScreen )
                                {
                                    mSettingsDialog = window;
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


        public void CloseBendFactorDialog()
        {
            var closeButton = mBendFactorDialog.Find<IControl>( new WPFPattern()
            {
                WPFControlName = "cCloseBtn"
            }, 4 );
            closeButton.Click();
        }

        public void CloseSettingsDialog()
        {
            var closeButton = mSettingsDialog.Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.Border"
            } ).Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.DockPanel",
                WPFControlOrdinalNo = 1
            } ).Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.DockPanel",
                WPFControlOrdinalNo = 1
            } ).Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.Image"
            }, 2 );
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
        private TcAppProcess mApp;

        /// <summary>
        /// The bend factor dialog
        /// </summary>
        private IControl mBendFactorDialog;

        /// <summary>
        /// The settings dialog
        /// </summary>
        private IControl mSettingsDialog;

        #endregion

        #region properties

        #endregion
    }
}
