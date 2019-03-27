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

using HomeZone.UiObjectInterfaces.Common;

#endregion


namespace HomeZone.UiObjectInterfaces.DatamanagerBend
{
    public interface TiDeductionValues : TiGoto
    {
        #region public methods

        /// <summary>
        /// Export TBS CSV file
        /// </summary>
        void ExportTBSCSV();

        #endregion

        #region properties

        /// <summary>
        /// TBS export dialog
        /// </summary>
        TiTBSExportDialog TBSExportDialog { get; }

        #endregion
    }
}
