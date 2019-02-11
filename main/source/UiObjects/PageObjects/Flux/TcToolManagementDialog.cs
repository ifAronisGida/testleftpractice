using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Flux;
using SmartBear.TestLeft.TestObjects.WPF;
using System.Collections.Generic;
using System.Linq;
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

        private IList<IControlObject> CreateToolListControl => FindAll<IControlObject>( new WPFPattern { ClrFullClassName = "System.Windows.Controls.MenuItem" } ).ToList();

        public void NewToolList( string name )
        {
            ActionsButton.Click();
            CreateToolListControl[ 0 ].Click();
            EditToolListNameButton.Click();
            ToolListText.Value = name;
            SaveToolListNameButton.Click();
        }

        public void Close()
        {
            CloseToolManagementDialogButton.Click();
        }
    }
}
