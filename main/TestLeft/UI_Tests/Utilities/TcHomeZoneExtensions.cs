using System;
using PageObjectInterfaces;
using PageObjectInterfaces.Common;
using PageObjectInterfaces.Customer;
using PageObjectInterfaces.CutJob;
using PageObjectInterfaces.Machine;
using PageObjectInterfaces.Material;
using PageObjectInterfaces.NestingTemplate;
using PageObjectInterfaces.Part;
using PageObjectInterfaces.PartOrder;
using PageObjectInterfaces.Shell;

namespace TestLeft.UI_Tests.Utilities
{
    internal static class TcHomeZoneExtensions
    {
        public static TiMaterials GotoMaterials( this TiHomeZoneApp app ) => Goto( () => app.Materials );

        public static TiMachines GotoMachines( this TiHomeZoneApp app ) => Goto( () => app.Machines );

        public static TiParts GotoParts( this TiHomeZoneApp app ) => Goto( () => app.Parts );

        public static TiPartOrders GotoPartOrders(this TiHomeZoneApp app) => Goto( () => app.PartOrders );

        public static TiCutJobs GotoCutJobs(this TiHomeZoneApp app) => Goto( () => app.CutJobs );

        public static TiNestingTemplates GotoNestingTemplates(this TiHomeZoneApp app) => Goto( () => app.NestingTemplates );

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

        private static T Goto<T>(Func<T> domain) where T : TiDomain
        {
            var obj = domain();
            obj.Goto();

            return obj;
        }
    }
}
