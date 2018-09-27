using System;
using PageObjectInterfaces.Common;

namespace PageObjectInterfaces.Machine
{
    public interface TiMachines
    {
        /// <summary>
        /// Gets the toolbar.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        TiMachineToolbar Toolbar { get; } 

        /// <summary>
        /// Gets the result column.
        /// </summary>
        /// <value>
        /// The result column.
        /// </value>
        TiResultColumn ResultColumn { get; }

        /// <summary>
        /// Gets the detail area.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        TiMachineDetail Detail { get; }

        /// <summary>
        /// Goto the page object, i.e. perform necessary action to make the page object visible on screen, do nothing if the page is already visible on screen.
        /// </summary>
        void Goto();

        /// <summary>
        /// Waits for detail overlay appear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        bool WaitForDetailOverlayAppear( TimeSpan timeout );

        /// <summary>
        /// Waits for detail overlay disappear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        bool WaitForDetailOverlayDisappear( TimeSpan timeout );

        /// <summary>
        /// Creates a new cut machine.
        /// </summary>
        void NewCutMachine();

        /// <summary>
        /// Creates a new cut machine with the given properties.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        /// <param name="name">The name.</param>
        /// <param name="laserPowerValue">The laser power value.</param>
        void NewCutMachine( string machineType, string name, string laserPowerValue );

        /// <summary>
        /// Creates a new bend machine.
        /// </summary>
        void NewBendMachine();

        /// <summary>
        /// Creates a new bend machine with the given properties.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        /// <param name="name">The name.</param>
        void NewBendMachine( string machineType, string name );

        /// <summary>
        /// Saves the current machine.
        /// </summary>
        void SaveMachine();

        /// <summary>
        /// Deletes the current machine.
        /// </summary>
        void DeleteMachine();

        /// <summary>
        /// Deletes the given machine.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if deleted</returns>
        bool DeleteMachine( string id );

        /// <summary>
        /// Selects the machine via identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        bool SelectMachine( string id );

        /// <summary>
        /// Selects the machines containing the given search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <returns>The amount of selected machines.</returns>
        int SelectMachines( string searchText );

        /// <summary>
        /// Selects all machines.
        /// </summary>
        /// <returns>The amount of selected machines.</returns>
        int SelectAll();
    }
}
