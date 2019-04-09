using HomeZone.UiObjectInterfaces.Machine;
using HomeZone.UiObjects.TestSettings;

namespace HomeZone.UiCommonFunctions.PageObjectHelpers
{
    public class TcMachineHelper
    {
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
        /// <param name="testSettings">test settings</param>
        /// <param name="machines">machine page</param>
        public void DeleteTestMachines( TcTestSettings testSettings, TiMachines machines )
        {
            machines.Goto();
            while( machines.ResultColumn.SelectItems( testSettings.NamePrefix ) > 0 )
            {
                machines.Toolbar.Delete();
            }
            machines.ResultColumn.ClearSearch();
        }
    }
}
