﻿#region HEADER
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
    /// <summary>
    /// bend deduction value dailog
    /// </summary>
    public class TcDeductionValueDialog : TcPageObjectBase, IChildOf<TcFluxApp>, TiDeductionValueDialog
    {
        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Close the bend deduction value dialog
        /// </summary>
        public void Close()
        {
            CloseBendDeductionValueDailog.Click();
        }


        #endregion

        #region private methods

        protected override Search SearchPattern => Search.By( new WPFPattern { ClrFullClassName = "Flux.App.UserBendDBDlg" } );

        private TiButton CloseBendDeductionValueDailog => FindByControlName<TiButton>( "cCloseBtn" );


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
