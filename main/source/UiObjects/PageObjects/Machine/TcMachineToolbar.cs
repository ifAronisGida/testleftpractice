using System;
using System.Threading;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Machine;

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

        public bool WaitNewBendMachineEnabled( TimeSpan machineFirstImportTimeout )
        {
            var menuItem = NewMachineButton.Parent.Cast<IWPFMenu>().WPFMenu.Items[ 0 ].SubMenu.Items[ 1 ];
            var startTime = DateTime.Now;
            NewMachineButton.Parent.Cast<IWPFMenu>().Click();

            while( !menuItem.Enabled && DateTime.Now - startTime < machineFirstImportTimeout )
            {
                Thread.Sleep( 1000 );
            }

            return menuItem.Enabled;
        }
    }
}
