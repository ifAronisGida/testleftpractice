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
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.Utilities;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using System;
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

        /// <summary>
        /// Select all materials
        /// </summary>
        public void SelectAll()
        {
            SelectAllCheckbox.Value = true;
        }

        /// <summary>
        /// Select Deduction values by material name
        /// </summary>
        /// <param name="materialName">material name</param>
        public void SelectByMaterialName( string name )
        {
            IControlObject NamedCheckBox = Find<TcGenericControlObject>( Search.By( new WPFPattern { WPFControlText = name } ));
            NamedCheckBox.Click();
        }

        /// <summary>
        /// Select coining values (default is air bending)
        /// </summary>
        public void SelectCoining()
        {
            //TODO
        }

        /// <summary>
        /// Export deduction values
        /// </summary>
        public void Export()
        {
            ExportButton.Click();
            var dlg = Parent.Node.Find<IWindow>( new WindowPattern { WndClass = "#32770" }, 1 );
            dlg.Find<IButton>( new WindowPattern() { WndClass = "Button", WndCaption = "OK" } ).Click();
            WaitForExportOverlayAppear();
            WaitForExportOverlayDisappear();
        }



        #endregion

        #region private methods

        protected override Search SearchPattern => Search.By( new WPFPattern { ClrFullClassName = "Trumpf.TruTops.DataMigrationTool.Views.Bend_Factor_Explorer.TcBendFactorTbsExportDialog" } );

        private TiValueControl<bool> SelectAllCheckbox => Find<TiValueControl<bool>>( "DeductionValues.TBSExportDialog.SelectAll" );

        private TiButton ExportButton => Find<TiButton>( "DeductionValues.TBSExportDialog.Export" );

        private TcOverlay ExportOverlay => Find<TcOverlay>( Search.ByControlName( "cpMessage" ) );

        private bool WaitForExportOverlayAppear( TimeSpan? timeout = null )
        {
            return ExportOverlay.Visible.TryWaitFor( timeout ?? TcPageObjectSettings.Instance.ExportOverlayDisappearTimeout );
        }
        private bool WaitForExportOverlayDisappear( TimeSpan? timeout = null )
        {
            return ExportOverlay.Visible.TryWaitForFalse( timeout ?? TcPageObjectSettings.Instance.ExportOverlayDisappearTimeout );
        }

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
