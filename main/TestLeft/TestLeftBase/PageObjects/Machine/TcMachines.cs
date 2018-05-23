using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Common;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Dialogs;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Shell;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Machine
{
    /// <summary>
    /// PageObject for the machines category.
    /// </summary>
    /// <seealso cref="RepeaterObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcMainTabControl}" />
    public class TcMachines : RepeaterObject, IChildOf<TcMainTabControl>
    {
        private TcMachineToolbar mToolbar;
        private TcMachinePopupMenu mPopup;
        private TcResultColumn mResultColumn;
        private TcMachineDetail mDetail;

        /// <summary>
        /// Gets the detail overlay.
        /// </summary>
        /// <value>
        /// The detail overlay.
        /// </value>
        public TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );

        /// <summary>
        /// Gets the toolbar.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        public TcMachineToolbar Toolbar
        {
            get
            {
                if( mToolbar == null )
                {
                    mToolbar = On<TcMachineToolbar>();
                }

                return mToolbar;
            }
        }

        /// <summary>
        /// Gets the PopupMenu.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        public TcMachinePopupMenu Popup
        {
            get
            {
                if( mPopup == null )
                {
                    mPopup = On<TcMachinePopupMenu>();
                }

                return mPopup;
            }
        }

        /// <summary>
        /// Gets the result column.
        /// </summary>
        /// <value>
        /// The result column.
        /// </value>
        public TcResultColumn ResultColumn
        {
            get
            {
                if( mResultColumn == null )
                {
                    mResultColumn = On<TcResultColumn>();
                }

                return mResultColumn;
            }
        }

        /// <summary>
        /// Gets the detail area.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        public TcMachineDetail Detail
        {
            get
            {
                if( mDetail == null )
                {
                    mDetail = On<TcMachineDetail>();
                }

                return mDetail;
            }
        }

        /// <summary>
        /// Goto the page object, i.e. perform necessary action to make the page object visible on screen, do nothing if the page is already visible on screen.
        /// </summary>
        public override void Goto()
        {
            base.Goto();
            Goto<TcDomainsMore>().GotoWorkplace();
            VisibleOnScreen.WaitFor();
        }

        /// <summary>
        /// Waits for detail overlay appear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitForDetailOverlayAppear( TimeSpan timeout )
        {
            return TryWait.For( () => DetailOverlay.VisibleOnScreen, timeout );
        }

        /// <summary>
        /// Waits for detail overlay disappear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitForDetailOverlayDisappear( TimeSpan timeout )
        {
            return TryWait.For( () => !DetailOverlay.VisibleOnScreen, timeout );
        }

        /// <summary>
        /// Creates a new cut machine.
        /// </summary>
        public void NewCutMachine()
        {
            Toolbar.NewMachineButton.Click();
            Popup.NewCutMachineButton.Click();
            //Toolbar.NewCutMachineButton.Click();
        }

        /// <summary>
        /// Creates a new cut machine with the given properties.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        /// <param name="name">The name.</param>
        /// <param name="laserPowerIndex">Index of the laser power in the ComboBox.</param>
        public void NewCutMachine( string machineType, string name, int laserPowerIndex )
        {
            NewCutMachine();
            Detail.CutMachineType = machineType;
            Detail.Name = name;
            Detail.LaserPowerIndex = laserPowerIndex;
        }

        /// <summary>
        /// Creates a new cut machine with the given properties.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        /// <param name="name">The name.</param>
        /// <param name="laserPowerValue">The laser power value.</param>
        public void NewCutMachine( string machineType, string name, string laserPowerValue )
        {
            NewCutMachine();
            Detail.CutMachineType = machineType;
            Detail.Name = name;
            Detail.LaserPowerValue = laserPowerValue;
        }

        /// <summary>
        /// Creates a new bend machine.
        /// </summary>
        public void NewBendMachine()
        {
            Toolbar.NewMachineButton.Click();
            Popup.NewBendMachineButton.Click();
            //Toolbar.NewBendMachineButton.Click();
        }

        /// <summary>
        /// Creates a new bend machine with the given properties.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        /// <param name="name">The name.</param>
        public void NewBendMachine( string machineType, string name )
        {
            NewBendMachine();
            Detail.BendMachineType = machineType;
            Detail.Name = name;
        }

        /// <summary>
        /// Saves the current machine.
        /// </summary>
        public void SaveMachine()
        {
            Toolbar.SaveButton.Click();
        }

        /// <summary>
        /// Deletes the current machine.
        /// </summary>
        public void DeleteMachine()
        {
            Toolbar.DeleteButton.Click();

            var dialog = On<TcMessageBox>();
            if( dialog.MessageBoxExists() )
            {
                dialog.Yes();
            }
        }

        /// <summary>
        /// Selects the machine via identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void SelectMachine( string id )
        {
            ResultColumn.SelectItem( id );
        }

        /// <summary>
        /// Selects the machines containing the given search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <returns>The amount of selected machines.</returns>
        public int SelectMachines( string searchText )
        {
            return ResultColumn.SelectItems( searchText );
        }

        /// <summary>
        /// Selects all machines.
        /// </summary>
        /// <returns>The amount of selected machines.</returns>
        public int SelectAll()
        {
            return ResultColumn.SelectAll();
        }
    }
}
