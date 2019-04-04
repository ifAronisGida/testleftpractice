using System;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.Waiting;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Machine;
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.PageObjects.Shell;

namespace HomeZone.UiObjects.PageObjects.Machine
{
    /// <summary>
    /// PageObject for the machines category.
    /// </summary>
    /// <seealso cref="IChildOf{T}" />
    public class TcMachines : TcDomain<TiMachineToolbar>, IChildOf<TcMainTabControl>, TiMachines
    {
        /// <summary>
        /// Gets the toolbar.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        public override TiMachineToolbar Toolbar => On<TcMachineToolbar>( cache: true );

        /// <summary>
        /// Gets the PopupMenu.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        public TcMachinePopupMenu Popup => On<TcMachinePopupMenu>( cache: true );

        /// <summary>
        /// Gets the detail area.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        public TiMachineDetail Detail => On<TcMachineDetail>( cache: true );

        /// <summary>
        /// Waits for detail overlay appear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitForDetailOverlayAppear( TimeSpan? timeout = null )
        {
            return DetailOverlay.Visible.TryWaitFor( timeout ?? TcPageObjectSettings.Instance.MachineOverlayAppearTimeout );
        }

        /// <summary>
        /// Waits for detail overlay disappear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitForDetailOverlayDisappear( TimeSpan? timeout = null )
        {
            return DetailOverlay.Visible.TryWaitForFalse( timeout ?? TcPageObjectSettings.Instance.MachineOverlayDisappearTimeout );
        }

        /// <summary>
        /// Creates a new cut machine with the given properties.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        /// <param name="name">The name.</param>
        /// <param name="laserPowerValue">The laser power value. Relevant only for laser and kombi machines.</param>
        public void NewCutMachine( string machineType, string name, string laserPowerValue = null )
        {
            Goto();
            Toolbar.NewCutMachine();
            Detail.CutMachineType = machineType;

            DetailOverlay.Visible.TryWaitFor( TimeSpan.FromSeconds( 5 ) );
            DetailOverlay.Visible.WaitForFalse( TimeSpan.FromSeconds( 10 ) );

            Detail.Name.Value = name;

            if( !string.IsNullOrEmpty( laserPowerValue ) )
            {
                Detail.LaserPower.Value = laserPowerValue;
            }
        }

        /// <summary>
        /// Creates a new bend machine with the given properties.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        /// <param name="name">The name.</param>
        public void NewBendMachine( string machineType, string name )
        {
            Goto();
            Toolbar.NewBendMachine();
            Detail.BendMachineType = machineType;
            Detail.Name.Value = name;
        }

        /// <summary>
        /// Deletes the given machine.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if deleted</returns>
        public bool DeleteMachine( string id )
        {
            if( !ResultColumn.SelectItem( id ) )
            {
                ResultColumn.ClearSearch();
                return false;
            }

            Toolbar.Delete();
            ResultColumn.ClearSearch();
            return true;
        }

        protected override void DoGoto()
        {
            On<TcDomainsMore>().GotoWorkplace();
        }
    }
}
