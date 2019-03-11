using System;
using HomeZone.UiObjectInterfaces.Customer;
using HomeZone.UiObjectInterfaces.CutJob;
using HomeZone.UiObjectInterfaces.Machine;
using HomeZone.UiObjectInterfaces.Material;
using HomeZone.UiObjectInterfaces.NestingTemplate;
using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjectInterfaces.PartOrder;
using HomeZone.UiObjectInterfaces.Shell;
using Trumpf.Coparoo.Desktop.Waiting;

namespace HomeZone.UiObjectInterfaces
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

        TiWelcomeScreen WelcomeScreen { get; }

        bool BendMachineTemplatesLoaded( TimeSpan? machineFirstImportTimeout = null );
    }
}
