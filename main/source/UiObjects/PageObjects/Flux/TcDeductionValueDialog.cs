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
using HomeZone.UiObjectInterfaces.Dialogs;
using HomeZone.UiObjectInterfaces.Flux;
using HomeZone.UiObjects.PageObjects.Dialogs;
using SmartBear.TestLeft.TestObjects.WPF;
using System;
using System.Linq;
using System.Threading;
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

        /// <summary>
        /// Import csv file
        /// </summary>
        /// <param name="csvFilePath">path to the csv file</param>
        public void Import( string csvFilePath )
        {
            ImportButton.Click();
            var openDlg = On<TiOpenFileDialog, TcOpenFileDialog>();
            openDlg.SetFilename( csvFilePath );
            Thread.Sleep( 20000 ); //Flux UI Freezes during import ...
        }

        /// <summary>
        /// Get the amount of csv entries
        /// </summary>
        /// <returns>amount of csv entries as displayed by Flux</returns>
        public int Entries()
        {
            string text = EntriesTextField.Value;
            return Int32.Parse( string.Join( "", text.ToCharArray().Where( Char.IsDigit ) ) );
        }

        #endregion

        #region private methods

        protected override Search SearchPattern => Search.By( new WPFPattern { ClrFullClassName = "Flux.App.UserBendDBDlg" } );

        private TiButton CloseBendDeductionValueDailog => FindByControlName<TiButton>( "cCloseBtn" );

        private TiButton ImportButton => FindByControlName<TiButton>( "cImport" );

        private TiValueControl<string> EntriesTextField => FindByControlName<TiValueControl<string>>( "cEntries" );

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
