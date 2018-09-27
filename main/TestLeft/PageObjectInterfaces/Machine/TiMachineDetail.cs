using PageObjectInterfaces.Controls;

namespace PageObjectInterfaces.Machine
{
    public interface TiMachineDetail
    {
        TiValueControl<string> Name { get; }
        TiValueControl<string> MachineNumber { get; }
        TiValueControl<string> LaserPower { get; }
        TiValueControl<string> TransferDirectory { get; }
        TiValueControl<bool> CreateSubDirectory { get; }

        /// <summary>
        /// Gets or sets the type of the cut machine.
        /// </summary>
        /// <value>
        /// The type of the cut machine.
        /// </value>
        string CutMachineType { get; set; }

        /// <summary>
        /// Gets or sets the type of the bend machine.
        /// </summary>
        /// <value>
        /// The type of the bend machine.
        /// </value>
        string BendMachineType { get; set; }

        /// <summary>
        /// Opens the machine configuration for bend.
        /// </summary>
        void OpenMachineConfigurationBend();
    }
}
