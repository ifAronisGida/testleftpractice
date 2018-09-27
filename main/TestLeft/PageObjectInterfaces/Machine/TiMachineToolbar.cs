using PageObjectInterfaces.Controls;
using SmartBear.TestLeft.TestObjects;

namespace PageObjectInterfaces.Machine
{
    public interface TiMachineToolbar
    {
        /// <summary>
        /// Gets the new machine button.
        /// </summary>
        /// <value>
        /// The new machine button.
        /// </value>
        IObjectTreeNode NewMachineButton { get; }

        /// <summary>
        /// Gets the save button.
        /// </summary>
        /// <value>
        /// The save button.
        /// </value>
        TiButton SaveButton { get; }

        /// <summary>
        /// Gets the revert button.
        /// </summary>
        /// <value>
        /// The revert button.
        /// </value>
        TiButton RevertButton { get; }

        /// <summary>
        /// Gets the delete button.
        /// </summary>
        /// <value>
        /// The delete button.
        /// </value>
        TiButton DeleteButton { get; }
    }
}
