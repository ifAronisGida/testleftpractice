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

        TiCustomers Customers { get; }

        TiMainMenu MainMenu { get; }

        TiParts Parts { get; }

        TiMaterials Materials { get; }

        TiMachines Machines { get; }

        TiPartOrders PartOrders { get; }

        TiCutJobs CutJobs { get; }

        TiNestingTemplates NestingTemplates { get; }
    }
}
