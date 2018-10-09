using PageObjectInterfaces.Customer;
using PageObjectInterfaces.CutJob;
using PageObjectInterfaces.Machine;
using PageObjectInterfaces.Material;
using PageObjectInterfaces.Part;
using PageObjectInterfaces.PartOrder;
using PageObjectInterfaces.Shell;
using TestLeft.TestLeftBase.PageObjects.Customer;
using TestLeft.TestLeftBase.PageObjects.CutJob;
using TestLeft.TestLeftBase.PageObjects.Machine;
using TestLeft.TestLeftBase.PageObjects.Material;
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
    public class TcHomeZoneApp : ProcessObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TcHomeZoneApp"/> class.
        /// </summary>
        /// <param name="processname">The name of the HomeZone process.</param>
        public TcHomeZoneApp( string processname ) : base( processname )
        {
        }

        public TiMainTabControl MainTabControl => On<TcMainTabControl>();

        public TiCustomers GotoCustomers()
        {
            return Goto<TcCustomers>();
        }

        public TiMainMenu GotoMainMenu()
        {
            return Goto<TcMainMenu>();
        }

        public TiParts GotoParts()
        {
            return Goto<TcParts>();
        }

        public TiMaterials GotoMaterials()
        {
            return Goto<TcMaterials>();
        }

        public TiMachines GotoMachines()
        {
            return Goto<TcMachines>();
        }

        public TiPartOrders GotoPartOrders()
        {
            return Goto<TcPartOrders>();
        }

        public TiCutJobs GotoCutJobs()
        {
            return Goto<TcCutJobs>();
        }

        /// <summary>
        /// Gets the interface of the PageObject.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TPageObject">The type of the page object.</typeparam>
        /// <returns>Interface of the target page object</returns>
        public TInterface On<TInterface, TPageObject>() where TInterface : class where TPageObject : class, IPageObject
        {
            return On<TPageObject>() as TInterface;
        }
    }
}
