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


#endregion

namespace HomeZone.UiObjectInterfaces.Flux
{
    public interface TiMainWindowFlux
    {
        #region public methods

        void Close();

        void OpenMenu();

        #endregion

        #region properties

        TiSettingsMenuFlux SettingsMenu { get; }

        #endregion
    }
}
