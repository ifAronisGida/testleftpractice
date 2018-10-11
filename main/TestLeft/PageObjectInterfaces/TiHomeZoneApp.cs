using PageObjectInterfaces.Customer;
using PageObjectInterfaces.CutJob;
using PageObjectInterfaces.Machine;
using PageObjectInterfaces.Material;
using PageObjectInterfaces.Part;
using PageObjectInterfaces.PartOrder;
using PageObjectInterfaces.Shell;
using SmartBear.TestLeft;

namespace PageObjectInterfaces
{
    public interface TiHomeZoneApp
    {
        /// <summary>
        ///  Gets or sets the (static) TestExecute driver.
        /// </summary>
        /// <value>
        /// The driver.
        /// </value>
        IDriver Driver { get; set; }

        TiMainTabControl MainTabControl { get; }

        TiCustomers GotoCustomers();

        TiMainMenu GotoMainMenu();

        TiParts GotoParts();

        TiMaterials GotoMaterials();

        TiMachines GotoMachines();

        TiPartOrders GotoPartOrders();

        TiCutJobs GotoCutJobs();
    }
}
