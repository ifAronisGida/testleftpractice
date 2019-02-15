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
    public interface TiToolManagementDialog
    {
        #region public methods

        /// <summary>
        /// Create a new tool list
        /// </summary>
        /// <param name="toolListName">tool list name</param>
        void NewToolList( string toolListName );

        /// <summary>
        /// Close the tool managment dialog
        /// </summary>
        void Close();

        /// <summary>
        /// Delete a given tool list
        /// </summary>
        /// <param name="toolListName">tool list name of the tool list to be deleted</param>
        void DeleteToolList( string toolListName );

        /// <summary>
        /// Renmae a given tool list
        /// </summary>
        /// <param name="toolListName"></param>
        void RenameToolList( string oldToolListName, string newToolListName );
        #endregion

        #region properties
        #endregion
    }
}
