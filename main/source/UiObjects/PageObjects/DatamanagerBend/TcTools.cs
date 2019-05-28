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
using HomeZone.UiObjectInterfaces.Dialogs;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

#endregion

namespace HomeZone.UiObjects.PageObjects.DatamanagerBend
{
    public class TcTools : TcPageObjectBase, IChildOf<TcDatamanagerBendApp>, TiTools
    {
        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Import (tools, deduction values, ...)
        /// </summary>
        /// <param name="filename"></param>
        public void Import( string filename )
        {
            ImportButton.Click();
            var openDlg = On<TiOpenFileDialog, TcOpenFileDialogDatamanager>();
            openDlg.SetFilename( filename );
        }

        #endregion

        #region private methods

        protected override Search SearchPattern => Search.By( new WPFPattern { ClrFullClassName = "System.Windows.Controls.TabControl" } );

        TiButton ImportButton => Find<TiButton>( "Tools.Import" );

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
