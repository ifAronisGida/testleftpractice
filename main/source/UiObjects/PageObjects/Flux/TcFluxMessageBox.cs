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
    internal class TcFluxMessageBox : TcPageObjectBase, IChildOf<TcFluxApp>, TiFluxMessageBox
    {
        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Press Save or Yes. Is mapped to ordinal number 1
        /// </summary>
        public void Save()
        {
            IControlObject saveButton = Find<TcGenericControlObject>( new WPFPattern
            {
                ClrFullClassName = "System.Windows.Controls.Button",
                WPFControlOrdinalNo = 1
            } );
            saveButton.Click();
        }
        #endregion

        #region private methods
        protected override Search SearchPattern => Search.By( new WPFPattern { ClrFullClassName = "Flux.MsgBox" } );

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
