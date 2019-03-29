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
    public class TcMainWindowFlux : TcPageObjectBase, IChildOf<TcFluxApp>, TiMainWindowFlux
    {
        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods



        public void Close()
        {
            this.Node.CallMethod( "Close" );
        }

        public void OpenMenu()
        {
            OpenMenuButton.Click();

        }

        #endregion

        #region private methods

        protected override Search SearchPattern => Search.By( new WPFPattern { ClrFullClassName = "Flux.App.MainWindow" } );

        private TiButton OpenMenuButton => FindByControlName<TiButton>( "menuFile" );

        #endregion

        #region public static members
        #endregion

        #region private static members
        #endregion

        #region private members
        #endregion

        #region properties

        public TiSettingsMenuFlux SettingsMenu => On<TcSettingsMenuFlux>();


        #endregion
    }
}
