using HomeZone.UiObjectInterfaces.Controls;
using System.Collections.Generic;

namespace HomeZone.UiObjectInterfaces.Machine
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

        ICollection<string> GetAvailableBendMachineTemplates();

        /// <summary>
        /// Checks if a preview Image is available
        /// </summary>
        /// <returns>true if a preview image is available</returns>
        bool IsPreviewImageAvailable();
    }
}
