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
using SmartBear.TestLeft;
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
        /// Select die (air bending) values.
        /// </summary>
        void SelectDie();

        /// <summary>
        /// Select coining values.
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
