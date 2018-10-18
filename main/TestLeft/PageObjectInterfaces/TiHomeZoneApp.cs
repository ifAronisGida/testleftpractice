using PageObjectInterfaces.Customer;
using PageObjectInterfaces.CutJob;
using PageObjectInterfaces.Machine;
using PageObjectInterfaces.Material;
using PageObjectInterfaces.NestingTemplate;
using PageObjectInterfaces.Part;
using PageObjectInterfaces.PartOrder;
using PageObjectInterfaces.Shell;

namespace PageObjectInterfaces
{
    public interface TiHomeZoneApp
    {
        TiMainTabControl MainTabControl { get; }

        TiCustomers GotoCustomers();

        TiMainMenu GotoMainMenu();

        TiParts GotoParts();

        TiMaterials GotoMaterials();

        TiMachines GotoMachines();

        TiPartOrders GotoPartOrders();

        TiCutJobs GotoCutJobs();

        TiNestingTemplates GotoNestingTemplates();
    }
}
