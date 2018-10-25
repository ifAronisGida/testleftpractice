using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;
using UiObjectInterfaces.Machine;
using UiObjects.PageObjects.Dialogs;
using UiObjects.PageObjects.Shell;


namespace UiObjects.PageObjects.Machine
{
    /// <summary>
    /// The machine toolbar.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcToolbars}" />
    public class TcMachineToolbar : TcPageObjectBase, IChildOf<TcToolbars>, TiMachineToolbar
    {
        public bool CanSave => SaveButton.Enabled;
        public bool CanDelete => DeleteButton.Enabled;
        public bool CanRevert => RevertButton.Enabled;

        protected override Search SearchPattern => Search.ByUid( "Machine.Toolbar" );

        private IObjectTreeNode NewMachineButton => Node.Find<IObjectTreeNode>( new WPFPattern()
        {
            ClrFullClassName = "System.Windows.Controls.MenuItem",
            Uid = "Machine.Toolbar.New"
        } );
        private TiButton SaveButton => Find<TiButton>( "Machine.Toolbar.Save" );
        private TiButton RevertButton => Find<TiButton>( "Machine.Toolbar.Revert" );
        private TiButton DeleteButton => Find<TiButton>( "Machine.Toolbar.Delete" );

        /// <summary>
        /// Creates a new cut machine.
        /// </summary>
        public void NewCutMachine()
        {
            NewMachineButton.Parent.Cast<IWPFMenu>().WPFMenu.Click( "|[0]" );
        }

        /// <summary>
        /// Creates a new bend machine.
        /// </summary>
        public void NewBendMachine()
        {
            NewMachineButton.Parent.Cast<IWPFMenu>().WPFMenu.Click( "|[1]" );
        }

        /// <summary>
        /// Saves the current machine.
        /// </summary>
        public void Save()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Deletes the current machine.
        /// </summary>
        public void Delete()
        {
            DeleteButton.Click();

            var dialog = On<TcMessageBox>();
            if( dialog.MessageBoxExists() )
            {
                dialog.Yes();
            }
        }
    }
}
