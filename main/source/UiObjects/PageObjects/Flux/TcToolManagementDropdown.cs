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

using HomeZone.UiObjectInterfaces.Flux;
using HomeZone.UiObjects.Utilities;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

#endregion

namespace HomeZone.UiObjects.PageObjects.Flux
{
    /// <summary>
    /// Dropdown of the tool management dialog. Appears after pression the action button
    /// </summary>
    public class TcToolManagementDropdown : TcPageObjectBase, IChildOf<TcFluxApp>, TiToolManagementDropdown
    {
        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Click the new tool list entry
        /// </summary>
        public void NewToolList()
        {
            IControlObject newToolListButton= Parent.Find<TcGenericControlObject>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.MenuItem",
                WPFControlOrdinalNo = 1
            } );
            newToolListButton.Click();
        }

        /// <summary>
        /// Clilck the delete tool list entry
        /// </summary>
        public void DeleteToolList()
        {
            IControlObject deleteToolListButton= Parent.Find<TcGenericControlObject>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.MenuItem",
                WPFControlOrdinalNo = 4
            } );
            deleteToolListButton.Click();
        }

        #endregion

        #region private methods

        protected override Search SearchPattern => Search.By( new WPFPattern { ClrFullClassName = "System.Windows.Window", Visible = true } );

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
