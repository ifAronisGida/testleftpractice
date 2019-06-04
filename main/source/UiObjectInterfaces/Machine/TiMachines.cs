using System;
using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.Machine
{
    public interface TiMachines : TiDomain
    {
        /// <summary>
        /// Gets the toolbar.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        TiMachineToolbar Toolbar { get; } 
        
        /// <summary>
        /// Gets the detail area.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        TiMachineDetail Detail { get; }

        /// <summary>
        /// Creates a new cut machine with the given properties.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        /// <param name="name">The name.</param>
        /// <param name="laserPowerValue">The laser power value.</param>
        void NewCutMachine( string machineType, string name, string laserPowerValue = null );

        /// <summary>
        /// Creates a new bend machine with the given properties.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        /// <param name="name">The name.</param>
        void NewBendMachine( string machineType, string name );

        /// <summary>
        /// Deletes the given machine.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if deleted</returns>
        bool DeleteMachine( string id );
    }
}
