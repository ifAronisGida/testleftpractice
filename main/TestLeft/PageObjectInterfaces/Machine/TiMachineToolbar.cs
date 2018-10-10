using PageObjectInterfaces.Common;

namespace PageObjectInterfaces.Machine
{
    public interface TiMachineToolbar : TiVisibility
    {
        bool CanSave { get; }
        bool CanDelete { get; }
        bool CanRevert { get; }

        /// <summary>
        /// Creates a new cut machine.
        /// </summary>
        void NewCutMachine();

        /// <summary>
        /// Creates a new bend machine.
        /// </summary>
        void NewBendMachine();

        /// <summary>
        /// Saves the current machine.
        /// </summary>
        void Save();

        /// <summary>
        /// Deletes the current machine.
        /// </summary>
        void Delete();
    }
}
