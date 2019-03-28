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
    /// <summary>
    /// bend deduction value dialog interface
    /// </summary>
    public interface TiDeductionValueDialog
    {
        #region public methods

        /// <summary>
        /// Close the bend deduction value dialog
        /// </summary>
        void Close();

        /// <summary>
        /// Import csv file
        /// </summary>
        /// <param name="csvFilePath">path to the csv file</param>
        void Import( string csvFilePath );

        /// <summary>
        /// Get the amount of csv entries
        /// </summary>
        /// <returns>amount of csv entries as displayed by Flux</returns>
        int Entries();

        #endregion

        #region properties
        #endregion
    }
}
