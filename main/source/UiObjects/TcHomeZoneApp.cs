using SmartBear.TestLeft;
using Trumpf.Coparoo.Desktop;
using UiObjectInterfaces;
using UiObjectInterfaces.Customer;
using UiObjectInterfaces.CutJob;
using UiObjectInterfaces.Machine;
using UiObjectInterfaces.Material;
using UiObjectInterfaces.NestingTemplate;
using UiObjectInterfaces.Part;
using UiObjectInterfaces.PartOrder;
using UiObjectInterfaces.Shell;
using UiObjects.PageObjects.Customer;
using UiObjects.PageObjects.CutJob;
using UiObjects.PageObjects.Machine;
using UiObjects.PageObjects.Material;
using UiObjects.PageObjects.NestingTemplate;
using UiObjects.PageObjects.Part;
using UiObjects.PageObjects.PartOrder;
using UiObjects.PageObjects.Shell;

namespace UiObjects
{
    /// <summary>
    /// The HomeZone ProcessObject.
    /// </summary>
    /// <seealso cref="ProcessObject" />
    public class TcHomeZoneApp : ProcessObject, TiHomeZoneApp
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TcHomeZoneApp"/> class.
        /// </summary>
        /// <param name="processname">The name of the HomeZone process.</param>
        /// <param name="driver">The driver to be used by this instance.</param>
        public TcHomeZoneApp( string processname, IDriver driver ) : base( processname )
        {
            Driver = driver;
        }

        public TiMainTabControl MainTabControl => On<TcMainTabControl>();

        public TiCustomers Customers => On<TcCustomers>();

        public TiMainMenu MainMenu => On<TcMainMenu>();

        public TiParts Parts => On<TcParts>();

        public TiMaterials Materials => On<TcMaterials>();

        public TiMachines Machines => On<TcMachines>();

        public TiPartOrders PartOrders => On<TcPartOrders>();

        public TiCutJobs CutJobs => On<TcCutJobs>();

        public TiNestingTemplates NestingTemplates => On<TcNestingTemplates>();
    }
}
