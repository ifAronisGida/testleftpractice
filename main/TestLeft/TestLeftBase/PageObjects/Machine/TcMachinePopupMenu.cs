using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Machine
{
    public class TcMachinePopupMenu : PageObject, IChildOf<TcHomeZoneApp>
    {
        protected override Search SearchPattern => Search.Any;
        /// <summary>
        /// Gets the new cut machine button.
        /// </summary>
        /// <value>
        /// The new cut machine button.
        /// </value>
        public IWPFPopupMenuOwner NewCutMachineButton => Parent.Node.Find<IWPFPopupMenuOwner>( new WPFPattern()
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
        public IWPFPopupMenuOwner NewBendMachineButton => Parent.Node.Find<IWPFPopupMenuOwner>( new WPFPattern()
        {
            ClrFullClassName = "System.Windows.Controls.Primitives.PopupRoot"
        }, 2 ).Find<IWPFPopupMenuOwner>( new WPFPattern()
        {
            Uid = "Machine.Toolbar.NewBendMachine"
        }, 3 );

    }
}
