﻿using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Common;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;
using SmartBear.TestLeft.TestObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Machine
{
    /// <summary>
    /// PageObject for the machines category.
    /// </summary>
    /// <seealso cref="RepeaterObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcMainTabControl}" />
    public class TcMachines : RepeaterObject, IChildOf<TcMainTabControl>
    {
        private readonly Lazy<TcMachineToolbar> mToolbar;
        //private TcMachineToolbar mToolbar;
        private readonly Lazy<TcMachinePopupMenu> mPopup;
        private readonly Lazy<TcResultColumn> mResultColumn;
        private readonly Lazy<TcMachineDetail> mDetail;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcMachines"/> class.
        /// </summary>
        public TcMachines()
        {
            mToolbar = new Lazy<TcMachineToolbar>( () => On<TcMachineToolbar>() );
            mPopup = new Lazy<TcMachinePopupMenu>( () => On<TcMachinePopupMenu>() );
            mResultColumn = new Lazy<TcResultColumn>( () => On<TcResultColumn>() );
            mDetail = new Lazy<TcMachineDetail>( () => On<TcMachineDetail>() );
        }

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
        public TcMachineToolbar Toolbar => mToolbar.Value;
        //public TcMachineToolbar Toolbar => mToolbar?? (mToolbar = On<TcMachineToolbar>());

        /// <summary>
        /// Gets the PopupMenu.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        public TcMachinePopupMenu Popup => mPopup.Value;

        /// <summary>
        /// Gets the result column.
        /// </summary>
        /// <value>
        /// The result column.
        /// </value>
        public TcResultColumn ResultColumn => mResultColumn.Value;

        /// <summary>
        /// Gets the detail area.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        public TcMachineDetail Detail => mDetail.Value;

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
            Toolbar.NewMachineButton.Parent.Cast<IWPFMenu>().WPFMenu.Click( "|[0]" );
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
            Toolbar.NewMachineButton.Parent.Cast<IWPFMenu>().WPFMenu.Click( "|[1]" );
            //Toolbar.NewMachineButton.Click();
            //Popup.NewBendMachineButton.Click();
        }

        /// <summary>
        /// Creates a new bend machine with the given properties.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        /// <param name="name">The name.</param>
        public void NewBendMachine( string machineType, string name )
        {
            NewBendMachine();
            Detail.VisibleOnScreen.WaitFor();
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
