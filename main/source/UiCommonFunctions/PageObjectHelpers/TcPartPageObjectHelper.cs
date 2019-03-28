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

using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjects.TestSettings;

#endregion

namespace HomeZone.UiCommonFunctions.PageObjectHelpers
{
    public class TcPartPageObjectHelper
    {
        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods

        public void ImportPart( TcTestSettings testSettings, TiParts parts, string filePath )
        {
            parts.Toolbar.Import( filePath );
            parts.WaitForDetailOverlayAppear();
            parts.WaitForDetailOverlayDisappear();
            parts.SingleDetail.Name.Value = testSettings.NamePrefix + parts.SingleDetail.Name.Value;
        }


        public void DeleteImportedParts( TcTestSettings testSettings, TiParts parts )
        {
            parts.Goto();
            parts.ResultColumn.SelectItems( testSettings.NamePrefix );
            if( parts.ResultColumn.Count > 0 )
            {
                parts.Toolbar.Delete();
            }
            parts.ResultColumn.ClearSearch();
        }
        #endregion

        #region private methods
        #endregion

        #region public static members
        #endregion

        #region private static members
        #endregion

        #region private members
        #endregion

        #region properties
        #endregion
    }
}
