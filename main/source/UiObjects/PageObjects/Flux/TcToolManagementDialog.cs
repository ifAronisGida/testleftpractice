#region HEADER
//--------------------------------------------------------------------------------------------------
// All rights reserved to TRUMPF GmbH + Co. KG, Germany
// -------------------------------------------------------------------------------------------------
//
//$File: //SW08/HomeZone_Testing/main/source/UiObjects/PageObjects/Flux/TcLandingPages.cs $
//$Author: steinertth $
//$Revision: #1 $ - $Date: 2018/10/24 $ 
// -------------------------------------------------------------------------------------------------
#endregion

#region USING

using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Flux;
using HomeZone.UiObjects.Utilities;
using SmartBear.TestLeft.TestObjects.WPF;
using System;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.Waiting;
using Trumpf.Coparoo.Desktop.WPF;
#endregion


namespace HomeZone.UiObjects.PageObjects.Flux
{
    /// <summary>
    /// Tool Management Dialog
    /// </summary>
    internal class TcToolManagementDialog : TcPageObjectBase, IChildOf<TcFluxApp>, TiToolManagementDialog
    {
        #region private constants

        private readonly Lazy<TcToolManagementDropdown> mDropDown;
        private readonly Lazy<TcFluxMessageBox> mMessageBox;

        #endregion

        #region constructor

        public TcToolManagementDialog()
        {
            mDropDown = new Lazy<TcToolManagementDropdown>( On<TcToolManagementDropdown> );
            mMessageBox = new Lazy<TcFluxMessageBox>( On<TcFluxMessageBox> );
        }

        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Create a new tool list
        /// </summary>
        /// <param name="toolListName">tool list name</param>
        public void NewToolList( string toolListName )
        {
            ActionsButton.Click();
            AddNewToolList();
            EditToolListNameButton.Click();
            ToolListText.Value = toolListName;
            SaveToolListNameButton.Click();
        }

        /// <summary>
        /// Close the tool managment dialog
        /// </summary>
        public void Close()
        {
            CloseToolManagementDialogButton.Click();
        }

        /// <summary>
        /// Delete a given tool list
        /// </summary>
        /// <param name="toolListName">tool list name of the tool list to be deleted</param>
        public void DeleteToolList( string toolListName )
        {
            OpenToolListsDropdown.Click();
            SelectToolList( toolListName );
            ActionsButton.Click();
            DeleteToolListButton();
            mMessageBox.Value.Exists.WaitFor( TimeSpan.FromSeconds( 60 ) );
            mMessageBox.Value.Save();
        }

        /// <summary>
        /// Renmae a given tool list
        /// </summary>
        /// <param name="toolListName"></param>
        public void RenameToolList( string oldToolListName, string newToolListName )
        {
            OpenToolListsDropdown.Click();
            SelectToolList( oldToolListName );
            EditToolListNameButton.Click();
            ToolListText.Value = newToolListName;
            SaveToolListNameButton.Click();
        }


        #endregion

        #region private methods

        protected override Search SearchPattern => Search.By( new WPFPattern { ClrFullClassName = "Flux.App.BToolsDlg" } );

        private TiButton ActionsButton => FindByControlName<TiButton>( "btnActions" );

        private TiButton EditToolListNameButton => FindByControlName<TiButton>( "imgRename" );

        private TiValueControl<string> ToolListText => FindByControlName<TiValueControl<string>>( "txtRename" );

        private TiButton SaveToolListNameButton => FindByControlName<TiButton>( "imgOK" );

        private TiButton CloseToolManagementDialogButton => FindByControlName<TiButton>( "cCloseBtn" );

        private TiButton OpenToolListsDropdown => FindByControlName<TiButton>( "cbCollection" );

        /// <summary>
        /// Add a new tool list
        /// IMPORTANT: This function is language dependent!
        /// </summary>
        private void AddNewToolList()
        {
            DrowDownExists.WaitFor( TimeSpan.FromSeconds( 60 ) );
            mDropDown.Value.NewToolList();
        }

        private Wool DrowDownExists => mDropDown.Value.Exists;

        private void DeleteToolListButton()
        {
            DrowDownExists.WaitFor( TimeSpan.FromSeconds( 60 ) );
            mDropDown.Value.DeleteToolList();
        }

        private void SelectToolList( string toolListName )
        {
            System.Threading.Thread.Sleep( 500 );
            IControlObject dropDownEntry =  Parent.Find<TcGenericControlObject>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.ComboBoxItem",
                WPFControlText = toolListName
            } );
            dropDownEntry.Click();
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
