﻿#region HEADER
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
        private readonly Lazy<TcAppSettingsDialog> mAppSettingsDialog;
        private readonly Lazy<TcDeductionValueDialog> mDeductionValuesDialog;
        private readonly Lazy<TcMachineConfigurationDialog> mMachineConfigurationDialog;
        private readonly Lazy<TcMainWindowFlux> mMainWindowFlux;

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
            mAppSettingsDialog = new Lazy<TcAppSettingsDialog>( On<TcAppSettingsDialog> );
            mDeductionValuesDialog = new Lazy<TcDeductionValueDialog>( On<TcDeductionValueDialog> );
            mMachineConfigurationDialog = new Lazy<TcMachineConfigurationDialog>( On<TcMachineConfigurationDialog> );
            mMainWindowFlux = new Lazy<TcMainWindowFlux>( On<TcMainWindowFlux> );
        }

        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Wait until Flux and Boost ist synchronized
        /// </summary>
        /// <param name="timeout">Synchronisation timeout</param>
        public void WaitForSynchronization( TimeSpan timeout )
        {
            Thread.Sleep( timeout );
        }

        /// <summary>
        /// Save Changes when asked in a message box
        /// </summary>
        public void SaveChanges()
        {
            MessageBoxExists.WaitFor( TcPageObjectSettings.Instance.FluxUITimeouts );
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

        /// <summary>
        /// Check if the ToolManagmeent Dialog Exists
        /// </summary>
        public Wool ToolManamgementDialogExists => mToolManagementDialog.Value.Exists;

        /// <summary>
        /// ToolManagement Dialog
        /// </summary>
        public TiToolManagementDialog ToolManagement => On<TcToolManagementDialog>();

        /// <summary>
        /// Check if the AppSettings Dialog Exists
        /// </summary>
        public Wool AppSettingsDialogExists => mAppSettingsDialog.Value.Exists;

        /// <summary>
        /// AppSettings Dialog
        /// </summary>
        public TiAppSettingsDialog AppSettings => On<TcAppSettingsDialog>();

        /// <summary>
        /// Check if the deduction value dialog exists
        /// </summary>
        public Wool DeductionValueDialogExists => mDeductionValuesDialog.Value.Exists;

        /// <summary>
        /// Deduction value dialog
        /// </summary>
        public TiDeductionValueDialog DeductionValueDialog => On<TcDeductionValueDialog>();

        /// <summary>
        /// Check if the machine configuration dialog exists
        /// </summary>
        public Wool MachineConfigurationDialogExists => mMachineConfigurationDialog.Value.Exists;

        /// <summary>
        /// machine configuration dialog
        /// </summary>
        public TiMachineConfigurationDialog MachineConfigurationDialog => On<TcMachineConfigurationDialog>();

        /// <summary>
        /// Check if the Flux Main Window exists
        /// </summary>
        public Wool MainWindowFluxExists => mMainWindowFlux.Value.Exists;

        /// <summary>
        /// Flux Main Window
        /// </summary>
        public TiMainWindowFlux MainWindowFlux => On<TcMainWindowFlux>();

        #endregion
    }
}
