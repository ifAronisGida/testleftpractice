using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.Machine
{
    public interface TiMachineToolbar : TiToolbar
    {
        /// <summary>
        /// Creates a new cut machine.
        /// </summary>
        void NewCutMachine();

        /// <summary>
        /// Creates a new bend machine.
        /// </summary>
        void NewBendMachine();

        /// <summary>
        /// Gets a value indicating whether menuitem new bend machine is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if new bend machine is enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsNewBendMachineEnabled { get; }
    }
}
