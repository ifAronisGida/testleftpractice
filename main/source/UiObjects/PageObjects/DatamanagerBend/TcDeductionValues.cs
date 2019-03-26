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
using HomeZone.UiObjectInterfaces.DatamanagerBend;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

#endregion

namespace HomeZone.UiObjects.PageObjects.DatamanagerBend
{
    public class TcDeductionValues : TcPageObjectBase, IChildOf<TcDatamanagerBendApp>, TiDeductionValues
    {
        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Goto the deduction value tab
        /// </summary>
        public override void Goto()
        {
            this.Node.Cast<IControl>().Click();
        }

        /// <summary>
        /// Export TBS CSV file
        /// </summary>
        public void ExportTBSCSV()
        {
            ExportButton.Click();
        }

        #endregion

        #region private methods

        protected override Search SearchPattern => Search.By( new WPFPattern { ClrFullClassName = "Trumpf.TruTops.DataMigrationTool.Views.TcBendFactorTabView" } );

        TiButton ExportButton => Find<TiButton>( "DeductionValues.ExportTBSCSV" );

        #endregion

        #region public static members
        #endregion

        #region private static members
        #endregion

        #region private members
        #endregion

        #region properties

        /// <summary>
        /// TBS export dialog
        /// </summary>
        public TiTBSExportDialog TBSExportDialog => On<TcTBSExportDialog>();

        #endregion
    }
}
