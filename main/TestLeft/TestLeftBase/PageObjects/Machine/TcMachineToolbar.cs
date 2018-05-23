using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Core;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Machine
{
    /// <summary>
    /// The machine toolbar.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcToolbars}" />
    public class TcMachineToolbar : PageObject, IChildOf<TcToolbars>
    {
        protected override Search SearchPattern => Search.ByUid( "Machine.Toolbar" );

        private IProcess mProcess;

        private IProcess Process
        {
            get
            {
                if( mProcess == null )
                {
                    mProcess = ( ( IProcessObjectNode )( ( UIObjectNode )Node ).RootNode ).Process;
                }

                return mProcess;
            }
        }

        /// <summary>
        /// Gets the new machine button.
        /// </summary>
        /// <value>
        /// The new machine button.
        /// </value>
        public IWPFPopupMenuOwner NewMachineButton => Process.Find<IWPFPopupMenuOwner>( new WPFPattern()
        {
            ClrFullClassName = "Trumpf.TruTops.Control.Shell.Views.TcShellView"
        }, 2 ).Find<IWPFPopupMenuOwner>( new WPFPattern()
        {
            WPFControlName = "MainTabControl"
        }, 12 ).Find<IWPFMenu>( new WPFPattern()
        {
            ClrFullClassName = "System.Windows.Controls.Menu"
        }, 11 ).Find<IWPFPopupMenuOwner>( new WPFPattern()
        {
            Uid = "Machine.Toolbar.New"
        } );

        /// <summary>
        /// Gets the new cut machine button.
        /// </summary>
        /// <value>
        /// The new cut machine button.
        /// </value>
        public IWPFPopupMenuOwner NewCutMachineButton => Process.Find<IWPFPopupMenuOwner>( new WPFPattern()
        {
            ClrFullClassName = "System.Windows.Controls.Primitives.PopupRoot"
        }, 2 ).Find<IWPFPopupMenuOwner>( new WPFPattern()
        {
            Uid = "Machine.Toolbar.NewCutMachine"
        }, 3 );

        /// <summary>
        /// Gets the new bend machine button.
        /// </summary>
        /// <value>
        /// The new bend machine button.
        /// </value>
        public IWPFPopupMenuOwner NewBendMachineButton => Process.Find<IWPFPopupMenuOwner>( new WPFPattern()
        {
            ClrFullClassName = "System.Windows.Controls.Primitives.PopupRoot"
        }, 2 ).Find<IWPFPopupMenuOwner>( new WPFPattern()
        {
            Uid = "Machine.Toolbar.NewBendMachine"
        }, 3 );

        /// <summary>
        /// Gets the save button.
        /// </summary>
        /// <value>
        /// The save button.
        /// </value>
        public TcTruIconButton SaveButton => Find<TcTruIconButton>( Search.ByUid( "Machine.Toolbar.Save" ) );

        /// <summary>
        /// Gets the revert button.
        /// </summary>
        /// <value>
        /// The revert button.
        /// </value>
        public TcTruIconButton RevertButton => Find<TcTruIconButton>( Search.ByUid( "Machine.Toolbar.Revert" ) );

        /// <summary>
        /// Gets the delete button.
        /// </summary>
        /// <value>
        /// The delete button.
        /// </value>
        public TcTruIconButton DeleteButton => Find<TcTruIconButton>( Search.ByUid( "Machine.Toolbar.Delete" ) );
    }
}
