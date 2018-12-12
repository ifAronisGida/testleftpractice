using System;
using System.Windows.Forms;
using System.Windows.Navigation;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Machine;
using SmartBear.TestLeft;


namespace HomeZone.UiObjects.PageObjects.Machine
{
    /// <summary>
    /// The machine toolbar.
    /// </summary>
    public class TcMachineToolbar : TcToolbar, TiMachineToolbar
    {
        protected override Search SearchPattern => Search.ByUid( "Machine.Toolbar" );

        private IObjectTreeNode NewMachineButton => Node.Find<IObjectTreeNode>( new WPFPattern()
        {
            ClrFullClassName = "System.Windows.Controls.MenuItem",
            Uid = "Machine.Toolbar.New"
        } );

        public TcMachineToolbar()
        {
            SaveButton = new Lazy<TiButton>( () => Find<TiButton>( "Machine.Toolbar.Save" ) );
            RevertButton = new Lazy<TiButton>( () => Find<TiButton>( "Machine.Toolbar.Revert" ) );
            DeleteButton = new Lazy<TiButton>( () => Find<TiButton>( "Machine.Toolbar.Delete" ) );
        }

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

        public bool IsNewBendMachineEnabled
        {
            get
            {
                var disableReasonCount = NewMachineButton.GetDataContextProperty<int>( "NewBendWorkplaceCommand.DisableReasons.Count" );

                return disableReasonCount == 0;
            }
        }
    }
}
