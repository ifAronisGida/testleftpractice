using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using SmartBear.TestLeft.TestObjects.WPF;
using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects.Core;

namespace TestLeft.TestLeftBase.PageObjects.Machine
{
    /// <summary>
    /// The machine toolbar.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcToolbars}" />
    public class TcMachineToolbar : PageObjectBase, IChildOf<TcToolbars>
    {
        protected override Search SearchPattern => Search.ByUid( "Machine.Toolbar" );

        /// <summary>
        /// Gets the new machine button.
        /// </summary>
        /// <value>
        /// The new machine button.
        /// </value>
        public IObjectTreeNode NewMachineButton => Node.Find<IObjectTreeNode>( new WPFPattern() {
            ClrFullClassName = "System.Windows.Controls.MenuItem",
            Uid = "Machine.Toolbar.New"
        } );

        /// <summary>
        /// Gets the save button.
        /// </summary>
        /// <value>
        /// The save button.
        /// </value>
        public TiButton SaveButton => Find<TiButton>( "Machine.Toolbar.Save" );

        /// <summary>
        /// Gets the revert button.
        /// </summary>
        /// <value>
        /// The revert button.
        /// </value>
        public TiButton RevertButton => Find<TiButton>( "Machine.Toolbar.Revert" );

        /// <summary>
        /// Gets the delete button.
        /// </summary>
        /// <value>
        /// The delete button.
        /// </value>
        public TiButton DeleteButton => Find<TiButton>( "Machine.Toolbar.Delete" );
    }
}
