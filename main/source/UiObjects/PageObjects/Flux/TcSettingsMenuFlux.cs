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
using HomeZone.UiObjectInterfaces.Flux;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

#endregion

namespace HomeZone.UiObjects.PageObjects.Flux
{
    public class TcSettingsMenuFlux : TcPageObjectBase, IChildOf<TcFluxApp>, TiSettingsMenuFlux
    {
        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Save current work
        /// </summary>
        public void Save()
        {
            SaveButton.Click();
        }

        #endregion

        #region private methods
        #endregion

        #region public static members
        #endregion

        #region private static members
        #endregion

        #region private members

        protected override Search SearchPattern => Search.By( new WPFPattern { ClrFullClassName = "System.Windows.Controls.Primitives.PopupRoot" } );

        private TiButton SaveButton => FindByControlName<TiButton>( "menuSave" );

        #endregion

        #region properties
        #endregion
    }
}
