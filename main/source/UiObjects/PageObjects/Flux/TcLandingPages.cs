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
using System;
using System.Threading;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
#endregion

namespace UiObjects.PageObjects.Flux
{
    public class TcLandingPages
    {
        #region private constants

        /// <summary>
        /// The synchronize timeout
        /// </summary>
        public static readonly TimeSpan SYNC_TIMEOUT = TimeSpan.FromSeconds( 30 );

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
        /// Is the toollist dialog visible?
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="retryWaitTime">The retry wait time.</param>
        /// <returns>true if visible</returns>
        public bool ToolsListsDialogVisible( TimeSpan timeout, TimeSpan retryWaitTime )
        {
            mApp = null;
            mToolListDialog = null;
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
                            if( mApp.Node.TryFind<IControl>( new WPFPattern { ClrFullClassName = "Flux.App.BToolListsDlg" }, out var window, 2 ) )
                            {
                                if( window.VisibleOnScreen )
                                {
                                    mToolListDialog = window;
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
        /// Is the tools dialog visible?
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="retryWaitTime">The retry wait time.</param>
        /// <returns>true if visible</returns>
        public bool ToolsDialogVisible( TimeSpan timeout, TimeSpan retryWaitTime )
        {
            mApp = null;
            mToolsDialog = null;
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
                            if( mApp.Node.TryFind<IControl>( new WPFPattern { ClrFullClassName = "Flux.App.BToolInventoryDlg" }, out var window, 2 ) )
                            {
                                if( window.VisibleOnScreen )
                                {
                                    mToolsDialog = window;
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

        /// <summary>
        /// Creates a new tool list.
        /// </summary>
        /// <param name="name">The name.</param>
        public void CreateNewToolList( string name )
        {
            // create new list
            var newButton = mToolListDialog.Find<IButton>( new WPFPattern()
            {
                WPFControlName = "cNew"
            }, 4 );
            newButton.Click();

            // get the popup...
            IProcess flux = mDriver.Find<IProcess>( new ProcessPattern()
            {
                ProcessName = "Flux"
            } );
            flux.TryFind<IControl>( new WPFPattern { ClrFullClassName = "Flux.App.BToolListDlg" }, 2, out var toolListDlg );

            // choose all tools
            var selectAll = toolListDlg.Find<IButton>( new WPFPattern()
            {
                WPFControlName = "cSelectAll"
            }, 4 );
            selectAll.Click();

            // put name
            var nameBox = toolListDlg.Find<ITextEdit>( new WPFPattern()
            {
                WPFControlName = "cFilename"
            }, 4 );
            nameBox.SetText( name );

            // save list
            var saveButton = toolListDlg.Find<IButton>( new WPFPattern()
            {
                WPFControlName = "cSave"
            }, 4 );
            saveButton.Click();

            // close dialog
            var closeButton = mToolListDialog.Find<IControl>( new WPFPattern()
            {
                WPFControlName = "cCloseBtn"
            }, 4 );
            closeButton.Click();
        }

        /// <summary>
        /// Deletes the toollist.
        /// WARNING: This function is language dependent
        /// </summary>
        /// <param name="name">The name.</param>
        public void DeleteToollist( string name )
        {
            var list = mToolListDialog.Find<IListBox>( new WPFPattern()
            {
                WPFControlName = "cList"
            }, 3 ).Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.TextBlock",
                WPFControlText = name
            }, 3 );
            list.Click();

            var delete = mToolListDialog.Find<IButton>( new WPFPattern()
            {
                WPFControlName = "cDelete"
            }, 4 );
            delete.Click();

            // get the message box...
            IProcess flux = mDriver.Find<IProcess>( new ProcessPattern()
            {
                ProcessName = "Flux"
            } );
            var msgBox = flux.Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "Flux.MsgBox"
            }, 2 ).Find<IButton>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.Button",
                WPFControlText = "Ja" // this is language dependent
            }, 3 );
            msgBox.Click();

            // close dialog
            var closeButton = mToolListDialog.Find<IControl>( new WPFPattern()
            {
                WPFControlName = "cCloseBtn"
            }, 4 );
            closeButton.Click();
        }

        public void RenameToollist( string oldName, string newName )
        {
            var list = mToolListDialog.Find<IListBox>( new WPFPattern()
            {
                WPFControlName = "cList"
            }, 3 ).Find<IControl>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.TextBlock",
                WPFControlText = oldName
            }, 3 );
            list.Click();

            var edit = mToolListDialog.Find<IButton>( new WPFPattern()
            {
                WPFControlName = "cEdit"
            }, 4 );
            edit.Click();

            // get the popup...
            IProcess flux = mDriver.Find<IProcess>( new ProcessPattern()
            {
                ProcessName = "Flux"
            } );
            flux.TryFind<IControl>( new WPFPattern { ClrFullClassName = "Flux.App.BToolListDlg" }, 2, out var toolListDlg );

            // put name
            var nameBox = toolListDlg.Find<ITextEdit>( new WPFPattern()
            {
                WPFControlName = "cFilename"
            }, 4 );
            nameBox.SetText( newName );

            // save list
            var saveButton = toolListDlg.Find<IButton>( new WPFPattern()
            {
                WPFControlName = "cSave"
            }, 4 );
            saveButton.Click();

            // close dialog
            var closeButton = mToolListDialog.Find<IControl>( new WPFPattern()
            {
                WPFControlName = "cCloseBtn"
            }, 4 );
            closeButton.Click();
        }

        public void CloseToolsDialog()
        {
            var closeButton = mToolsDialog.Find<IControl>( new WPFPattern()
            {
                WPFControlName = "cCloseBtn"
            }, 4 );
            closeButton.Click();
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
        /// The tool list dialog
        /// </summary>
        private IControl mToolListDialog;

        /// <summary>
        /// The tools dialog
        /// </summary>
        private IControl mToolsDialog;

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
