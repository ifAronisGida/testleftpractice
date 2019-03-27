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

using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.DatamanagerBend;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

#endregion

namespace HomeZone.UiObjects.PageObjects.DatamanagerBend
{
    public class TcMainWindowDatamanagerBend : TcPageObjectBase, IChildOf<TcDatamanagerBendApp>, TiMainWindowDatamanagerBend
    {
        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Close the datamanager
        /// </summary>
        public void Close()
        {
            CloseButton.Click();
        }

        #endregion

        #region private methods
        #endregion

        #region public static members
        #endregion

        #region private static members
        #endregion

        #region private members

        protected override Search SearchPattern => Search.ByControlName( "ShellWindow" );

        private TiButton CloseButton => FindByControlName<TiButton>( "WindowButtonClose" );

        #endregion

        #region properties
        #endregion
    }
}
