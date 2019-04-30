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

namespace HomeZone.UiObjectInterfaces.DatamanagerBend
{
    public interface TiTBSExportDialog
    {
        #region public methods

        /// <summary>
        /// Select all materials
        /// </summary>
        void SelectAll();

        /// <summary>
        /// Select Deduction values by material name
        /// </summary>
        /// <param name="materialName">material name</param>
        void SelectByMaterialName( string materialName );

        /// <summary>
        /// Select coining values (default is air bending)
        /// </summary>
        void SelectCoining();

        /// <summary>
        /// Export deduction values
        /// </summary>
        void Export();

        #endregion

        #region properties
        #endregion

    }
}
