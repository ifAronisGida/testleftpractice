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

        /// <summary>
        /// Close the Flux Window
        /// </summary>
        void Close();

        /// <summary>
        /// Open the Flux Menu
        /// </summary>
        void OpenMenu();

        #endregion

        #region properties

        /// <summary>
        /// Settings Menu
        /// </summary>
        TiSettingsMenuFlux SettingsMenu { get; }

        #endregion
    }
}
