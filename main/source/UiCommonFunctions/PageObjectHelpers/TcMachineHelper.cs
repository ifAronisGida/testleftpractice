using HomeZone.UiCommonFunctions.TestSettings;
using HomeZone.UiObjectInterfaces.Machine;

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

		/// <summary>
		/// Gets the actual release path of a specific machine.
		/// </summary>
		/// <param name="machineName">Name of the Machine.</param>
		/// <param name="machines">The machine tab.</param>
		/// <returns>The actual release path or <code>string.Empty</code> if the machine was not found.</returns>
		public string GetReleasePathOfMachine(string machineName, TiMachines machines)
		{
			string actualPath = string.Empty;

			machines.Goto();
			if( machines.ResultColumn.SelectItems( machineName ) == 1 )
			{
				actualPath = machines.Detail.TransferDirectory.Value;
			}

			return actualPath;
		}

		/// <summary>
		/// Changes the release path of a specific machine.
		/// </summary>
		/// <param name="machineName">Name of the Machine.</param>
		/// <param name="releasePath">The new release path to set.</param>
		/// <param name="machines">The machine tab.</param>
		/// <returns><code>true</code> if path was set, <code>false</code> if the machine was not found.</returns>
		public bool ChangeReleasePathOfMachine(string machineName, string releasePath, TiMachines machines )
        {
            var machineFoundAndPathSet = false;

            machines.Goto();
            if(machines.ResultColumn.SelectItems( machineName ) == 1)
            {
                machines.Detail.TransferDirectory.Value = releasePath;
                machines.Toolbar.Save();

                machineFoundAndPathSet = true;
            }

            return machineFoundAndPathSet;
        }
    }
}