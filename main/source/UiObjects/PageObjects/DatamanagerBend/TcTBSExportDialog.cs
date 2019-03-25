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
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

#endregion

namespace HomeZone.UiObjects.PageObjects.DatamanagerBend
{
    public class TcTBSExportDialog : TcPageObjectBase, IChildOf<TcDatamanagerBendApp>, TiTBSExportDialog
    {
        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods
        public void Export()
        {
            ExportButton.Click();
            //var dlg = Parent.Node.Find<IWindow>( new WindowPattern { WndClass = "#32770" }, 1 );
            //dlg.
            //dlg.Cast<IOpenFileDialog>().OpenFile( filename );
        }

        public void SelectAll()
        {
            SelectAllCheckbox.Click();
        }
        #endregion

        #region private methods

        protected override Search SearchPattern => Search.By( new WPFPattern { ClrFullClassName = "Trumpf.TruTops.DataMigrationTool.Views.Bend_Factor_Explorer.TcBendFactorTbsExportDialog" } );

        private TiButton SelectAllCheckbox => Find<TiButton>( "DeductionValues.TBSExportDialog.SelectAll" );

        private TiButton ExportButton => Find<TiButton>( "DeductionValues.TBSExportDialog.Export" );

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
