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

        void ExportTBSCSV();

        #endregion

        #region properties

        TiTBSExportDialog TBSExportDialog { get; }

        #endregion
    }
}
