using HomeZone.UiObjectInterfaces;
using HomeZone.UiObjectInterfaces.Common;
using HomeZone.UiObjectInterfaces.Customer;
using HomeZone.UiObjectInterfaces.CutJob;
using HomeZone.UiObjectInterfaces.Machine;
using HomeZone.UiObjectInterfaces.Material;
using HomeZone.UiObjectInterfaces.NestingTemplate;
using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjectInterfaces.PartOrder;
using HomeZone.UiObjectInterfaces.Shell;

namespace UiCommonFunctions.Utilities
{
    public static class TcHomeZoneExtensions
    {
        public static TiMaterials GotoMaterials( this TiHomeZoneApp app ) => Goto( app.Materials );

        public static TiMachines GotoMachines( this TiHomeZoneApp app ) => Goto( app.Machines );

        public static TiParts GotoParts( this TiHomeZoneApp app ) => Goto( app.Parts );

        public static TiPartOrders GotoPartOrders(this TiHomeZoneApp app) => Goto( app.PartOrders );

        public static TiCutJobs GotoCutJobs(this TiHomeZoneApp app) => Goto( app.CutJobs );

        public static TiNestingTemplates GotoNestingTemplates(this TiHomeZoneApp app) => Goto( app.NestingTemplates );

        public static TiCustomers GotoCustomers( this TiHomeZoneApp app )
        {
            var cust = app.Customers;
            cust.Goto();

            return cust;
        }

        public static TiMainMenu GotoMainMenu( this TiHomeZoneApp app )
        {
            var menu = app.MainMenu;
            menu.Goto();

            return menu;
        }

        private static T Goto<T>(T obj) where T : TiGoto
        {
            obj.Goto();

            return obj;
        }
    }
}
