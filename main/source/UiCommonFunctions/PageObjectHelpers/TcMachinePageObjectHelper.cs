#region HEADER
//--------------------------------------------------------------------------------------------------
// All rights reserved to TRUMPF GmbH + Co. KG, Germany
// -------------------------------------------------------------------------------------------------
//
//$File: $
//$Author: $
//$Revision: $ - $Date: $ 
// -------------------------------------------------------------------------------------------------
#endregion

#region USING

using HomeZone.UiObjectInterfaces.Machine;
using HomeZone.UiObjects.TestSettings;
using System.Collections.Generic;

#endregion

namespace HomeZone.UiCommonFunctions
{
    public class TcMachinePageObjectHelper
    {
        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods

        public void CreateAndSaveBendMachine( TcTestSettings testSettings, TiMachines machines, string machineType, string machineName = null )
        {
            if( machineName == null )
            {
                machineName = machineType.Replace( "/", "_" ); //Replace not allowed characters
            }
            machineName = testSettings.NamePrefix + machineName;
            mCreatedMachineList.Add( machineName );
            machines.NewBendMachine( machineType, machineName );
            machines.Toolbar.Save();
            machines.WaitForDetailOverlayAppear( testSettings.MachineOverlayAppearTimeout );
            machines.WaitForDetailOverlayDisappear( testSettings.MachineOverlayDisappearTimeout );
        }

        public void DeleteCreatedMachines( TiMachines machines )
        {
            machines.Goto();
            foreach( var machine in mCreatedMachineList )
            {
                machines.DeleteMachine( machine );
            }
            mCreatedMachineList.Clear();
        }

        #endregion

        #region private methods
        #endregion

        #region public static members
        #endregion

        #region private static members
        #endregion

        #region private members

        List<string> mCreatedMachineList = new List<string>();

        #endregion

        #region properties
        #endregion
    }
}
