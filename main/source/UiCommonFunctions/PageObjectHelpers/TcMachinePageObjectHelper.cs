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

        /// <summary>
        /// Create and save a bend machine
        /// </summary>
        /// <param name="testSettings">test settings</param>
        /// <param name="machines">machine page</param>
        /// <param name="machineType">name of the machine type</param>
        /// <param name="machineName">machine name; defaults to the machine type name</param>
        public void CreateAndSaveBendMachine( TcTestSettings testSettings, TiMachines machines, string machineType, string machineName = null )
        {
            if( machineName == null )
            {
                machineName = machineType.Replace( "/", "_" ); //Replace not allowed characters
            }
            machineName = testSettings.NamePrefix + machineName;
            machines.NewBendMachine( machineType, machineName );
            machines.Toolbar.Save();
            machines.WaitForDetailOverlayAppear();
            machines.WaitForDetailOverlayDisappear();
        }

        /// <summary>
        /// Delete all machines which were created with the function <see cref="CreateAndSaveBendMachine(TcTestSettings, TiMachines, string, string)"/>
        /// </summary>
        /// <param name="machines">machine page</param>
        public void DeleteCreatedMachines( TcTestSettings testSettings, TiMachines machines )
        {
            machines.Goto();
            machines.ResultColumn.SelectItems( testSettings.NamePrefix );
            if( machines.ResultColumn.Count > 0 )
            {
                machines.Toolbar.Delete();
            }
            machines.ResultColumn.ClearSearch();
        }

        #endregion

        #region private methods
        #endregion

        #region public static members
        #endregion

        #region private static members
        #endregion

        #region private members
        #endregion

        #region properties
        #endregion
    }
}
