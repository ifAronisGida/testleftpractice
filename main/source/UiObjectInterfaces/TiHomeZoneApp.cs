using Trumpf.Coparoo.Desktop.Waiting;
using UiObjectInterfaces.Customer;
using UiObjectInterfaces.CutJob;
using UiObjectInterfaces.Machine;
using UiObjectInterfaces.Material;
using UiObjectInterfaces.NestingTemplate;
using UiObjectInterfaces.Part;
using UiObjectInterfaces.PartOrder;
using UiObjectInterfaces.Shell;

namespace UiObjectInterfaces
{
    public interface TiHomeZoneApp
    {
        Wool MainWindowExists { get; }

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
