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
    /// app settings dialog
    /// </summary>
    public class TcAppSettingsDialog : TcPageObjectBase, IChildOf<TcFluxApp>, TiAppSettingsDialog
    {
        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Close the tool managment dialog
        /// </summary>
        public void Close()
        {
            IControlObject closeButton = Find<TcGenericControlObject>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.Image"
            } );
            closeButton.Click();
        }

        #endregion

        #region private methods

        protected override Search SearchPattern => Search.By( new WPFPattern { ClrFullClassName = "Flux.SheafEdit" } );

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
