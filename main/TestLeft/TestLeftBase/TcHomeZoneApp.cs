using PageObjectInterfaces;
using PageObjectInterfaces.Customer;
using PageObjectInterfaces.CutJob;
using PageObjectInterfaces.Machine;
using PageObjectInterfaces.Material;
using PageObjectInterfaces.NestingTemplate;
using PageObjectInterfaces.Part;
using PageObjectInterfaces.PartOrder;
using PageObjectInterfaces.Shell;
using SmartBear.TestLeft;
using TestLeft.TestLeftBase.PageObjects.Customer;
using TestLeft.TestLeftBase.PageObjects.CutJob;
using TestLeft.TestLeftBase.PageObjects.Machine;
using TestLeft.TestLeftBase.PageObjects.Material;
using TestLeft.TestLeftBase.PageObjects.NestingTemplate;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.PageObjects.PartOrder;
using TestLeft.TestLeftBase.PageObjects.Shell;
using Trumpf.PageObjects;

namespace TestLeft.TestLeftBase
{
    /// <summary>
    /// The HomeZone ProcessObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.ProcessObject" />
    public class TcHomeZoneApp : ProcessObject, TiHomeZoneApp
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TcHomeZoneApp"/> class.
        /// </summary>
        /// <param name="processname">The name of the HomeZone process.</param>
        /// <param name="driver">The driver to be used by this instance.</param>
        public TcHomeZoneApp( string processname, IDriver driver ) : base( processname )
        {
            this.Driver = driver;
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
