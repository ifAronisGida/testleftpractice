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
    }
}
