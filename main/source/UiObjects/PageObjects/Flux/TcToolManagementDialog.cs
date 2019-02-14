using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Flux;
using HomeZone.UiObjects.Utilities;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.Flux
{
    internal class TcToolManagementDialog : TcPageObjectBase, IChildOf<TcFluxApp>, TiToolManagementDialog
    {

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
            System.Threading.Thread.Sleep( 1000 );
            IControlObject newToolListButton= Parent.Find<TcGenericControlObject>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.MenuItem",
                WPFControlText = "_A  Werkzeugliste anlegen"
            } );
            newToolListButton.Click();
            System.Threading.Thread.Sleep( 1000 );
        }

        private void DeleteToolListButton()
        {
            System.Threading.Thread.Sleep( 1000 );
            IControlObject newToolListButton= Parent.Find<TcGenericControlObject>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.MenuItem",
                WPFControlOrdinalNo = 4
            } );
            newToolListButton.Click();
            System.Threading.Thread.Sleep( 1000 );
        }

        private void SaveChanges()
        {

        }

        private IControlObject SelectToolList( string toolListName )
        {
            return Parent.Find<TcGenericControlObject>( new WPFPattern()
            {
                ClrFullClassName = "System.Windows.Controls.MenuItem",
                WPFControlText = toolListName
            } );
        }

        public void NewToolList( string toolListName )
        {
            ActionsButton.Click();
            AddNewToolList();
            EditToolListNameButton.Click();
            ToolListText.Value = toolListName;
            SaveToolListNameButton.Click();
        }

        public void Close()
        {
            CloseToolManagementDialogButton.Click();
        }

        public void DeleteToolList( string toolListName )
        {
            OpenToolListsDropdown.Click();
            SelectToolList( toolListName );
            DeleteToolListButton();
            SaveChanges();
        }

        public void RenameToolList( string toolListName )
        {

            EditToolListNameButton.Click();
            ToolListText.Value = toolListName;
            SaveToolListNameButton.Click();
            throw new System.NotImplementedException();
        }
    }
}
