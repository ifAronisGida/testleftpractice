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
using HomeZone.UiObjectInterfaces.Flux;
using SmartBear.TestLeft;
using System;
using System.Threading;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.Waiting;
#endregion


namespace HomeZone.UiObjects.PageObjects.Flux
{
    /// <summary>
    /// Class representing Flux
    /// </summary>
    public class TcFluxApp : ProcessObject, TiFluxApp
    {
        #region private constants

        private readonly Lazy<TcToolManagementDialog> mToolManagementDialog;
        private readonly Lazy<TcFluxMessageBox> mMessageBox;
        #endregion

        #region constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="processname">Flux process name</param>
        /// <param name="driver">driver</param>
        public TcFluxApp( string processname, IDriver driver ) : base( processname )
        {
            Driver = driver;
            mToolManagementDialog = new Lazy<TcToolManagementDialog>( On<TcToolManagementDialog> );
            mMessageBox = new Lazy<TcFluxMessageBox>( On<TcFluxMessageBox> );
        }

        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// ToolManagement Dialog
        /// </summary>
        public TiToolManagementDialog ToolManagement => On<TcToolManagementDialog>();

        /// <summary>
        /// Check if the ToolManagmeent Dialog Exists
        /// </summary>
        public Wool ToolManamgementDialogExists => mToolManagementDialog.Value.Exists;

        /// <summary>
        /// Wait until Flux and Boost ist synchronized
        /// </summary>
        /// <param name="timeout">Synchronisation timeout</param>
        public void WaitForSynchronization( TimeSpan timeout )
        {
            Thread.Sleep( timeout );
        }

        public void SaveChanges()
        {
            MessageBoxExists.WaitFor( TimeSpan.FromSeconds( 60 ) );
            mMessageBox.Value.Save();
        }

        #endregion

        #region private methods

        private Wool MessageBoxExists => mMessageBox.Value.Exists;

        #endregion

        #region public static members
        #endregion

        #region private static members
        #endregion

        #region private members
        #endregion

        #region properties
        #endregion
    }
}
