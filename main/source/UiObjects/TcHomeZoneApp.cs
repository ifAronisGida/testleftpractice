using HomeZone.UiObjectInterfaces;
using HomeZone.UiObjectInterfaces.Customer;
using HomeZone.UiObjectInterfaces.CutJob;
using HomeZone.UiObjectInterfaces.Machine;
using HomeZone.UiObjectInterfaces.Material;
using HomeZone.UiObjectInterfaces.NestingTemplate;
using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjectInterfaces.PartOrder;
using HomeZone.UiObjectInterfaces.Shell;
using HomeZone.UiObjects.PageObjects.Customer;
using HomeZone.UiObjects.PageObjects.CutJob;
using HomeZone.UiObjects.PageObjects.Machine;
using HomeZone.UiObjects.PageObjects.Material;
using HomeZone.UiObjects.PageObjects.NestingTemplate;
using HomeZone.UiObjects.PageObjects.Part;
using HomeZone.UiObjects.PageObjects.PartOrder;
using HomeZone.UiObjects.PageObjects.Shell;
using SmartBear.TestLeft;
using System;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.Waiting;
using HomeZone.UiObjectInterfaces.Dialogs;
using HomeZone.UiObjects.PageObjects.Dialogs;

namespace HomeZone.UiObjects
{
    /// <summary>
    /// The HomeZone ProcessObject.
    /// </summary>
    /// <seealso cref="ProcessObject" />
    public class TcHomeZoneApp : ProcessObject, TiHomeZoneApp
    {
        private readonly Lazy<TcMainWindow> mMainWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcHomeZoneApp"/> class.
        /// </summary>
        /// <param name="processname">The name of the HomeZone process.</param>
        /// <param name="driver">The driver to be used by this instance.</param>
        public TcHomeZoneApp( string processname, IDriver driver ) : base( processname )
        {
            Driver = driver;
            mMainWindow = new Lazy<TcMainWindow>( On<TcMainWindow> );
        }

        public Wool MainWindowExists => mMainWindow.Value.Exists;

        public TiMessageBox MessageBox => On<TcMessageBox>();

        public TiMainTabControl MainTabControl => On<TcMainTabControl>();

        public TiCustomers Customers => On<TcCustomers>();

        public TiMainMenu MainMenu => On<TcMainMenu>();

        public TiParts Parts => On<TcParts>();

        public TiMaterials Materials => On<TcMaterials>();

        public TiMachines Machines => On<TcMachines>();

        public TiPartOrders PartOrders => On<TcPartOrders>();

        public TiCutJobs CutJobs => On<TcCutJobs>();

        public TiNestingTemplates NestingTemplates => On<TcNestingTemplates>();

        public TiWelcomeScreen WelcomeScreen => On<TcWelcomeScreen>();

        public bool BendMachineTemplatesLoaded( TimeSpan? machineFirstImportTimeout = null )
        {
            Machines.Goto();
            return Machines.Toolbar.WaitNewBendMachineEnabled(
                machineFirstImportTimeout ?? TcPageObjectSettings.Instance.MachineFirstImportTimeout );
        }

        public void Maximize()
        {
            mMainWindow.Value.Maximize();
        }

        public IVisualObject VisualObject => ( ( Trumpf.Coparoo.Desktop.Core.UIObjectNode )mMainWindow.Value.Node ).Root;
    }
}
