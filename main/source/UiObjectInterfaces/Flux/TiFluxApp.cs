#region HEADER
//--------------------------------------------------------------------------------------------------
// All rights reserved to TRUMPF GmbH + Co. KG, Germany
// -------------------------------------------------------------------------------------------------
//
//$File: $
//$Author: $
//$Revision: $ - $Date: $ 
// -------------------------------------------------------------------------------------------------
#endregion

#region USING

using System;
using Trumpf.Coparoo.Desktop.Waiting;

#endregion

namespace HomeZone.UiObjectInterfaces.Flux
{
    public interface TiFluxApp
    {
        #region public methods

        /// <summary>
        /// Wait until Flux and Boost ist synchronized
        /// </summary>
        /// <param name="timeout">Synchronisation timeout</param>
        void WaitForSynchronization( TimeSpan timeout );

        /// <summary>
        /// Save Changes when asked in a message box
        /// </summary>
        void SaveChanges();

        #endregion

        #region properties

        /// <summary>
        /// Check if the ToolManagmeent Dialog Exists
        /// </summary>
        Wool ToolManamgementDialogExists { get; }

        /// <summary>
        /// ToolManagement Dialog
        /// </summary>
        TiToolManagementDialog ToolManagement { get; }

        /// <summary>
        /// Check if the AppSettings Dialog Exists
        /// </summary>
        Wool AppSettingsDialogExists { get; }

        /// <summary>
        /// AppSettings Dialog
        /// </summary>
        TiAppSettingsDialog AppSettings { get; }

        #endregion
    }
}
