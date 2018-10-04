using PageObjectInterfaces.Customer;
using PageObjectInterfaces.Machine;
using PageObjectInterfaces.Material;
using PageObjectInterfaces.Part;
using PageObjectInterfaces.PartOrder;
using PageObjectInterfaces.Settings;
using TestLeft.TestLeftBase.PageObjects.Customer;
using TestLeft.TestLeftBase.PageObjects.Machine;
using TestLeft.TestLeftBase.PageObjects.Material;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.PageObjects.PartOrder;
using TestLeft.TestLeftBase.PageObjects.Settings;
using Trumpf.PageObjects;

namespace TestLeft.TestLeftBase
{
    /// <summary>
    /// The HomeZone ProcessObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.ProcessObject" />
    public class TcHomeZoneApp : ProcessObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TcHomeZoneApp"/> class.
        /// </summary>
        /// <param name="processname">The name of the HomeZone process.</param>
        public TcHomeZoneApp( string processname ) : base( processname )
        {
        }

        public TiCustomers GotoCustomers()
        {
            return Goto<TcCustomers>();
        }

        public TiParts GotoParts()
        {
            return Goto<TcParts>();
        }

        public TiMachines GotoMachines()
        {
            return Goto<TcMachines>();
        }

        public TiMaterials GotoMaterials()
        {
            return Goto<TcMaterials>();
        }

        public TiSettingsDialog GotoSettings()
        {
            return Goto<TcSettingsDialog>();
        }

        public TiPartOrders GotoPartOrders()
        {
            return Goto<TcPartOrders>();
        }
    }
}
