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

using Trumpf.Coparoo.Desktop.Waiting;

#endregion

namespace HomeZone.UiObjectInterfaces.DatamanagerBend
{
    public interface TiDatamanagerBendApp
    {
        #region public methods

        void Close();

        #endregion

        #region properties

        Wool MainWindowExists { get; }



        #endregion
    }
}
