using HomeZone.UiObjects.TestSettings;
using HomeZone.UiObjectInterfaces.Customer;

namespace HomeZone.UiCommonFunctions.PageObjectHelpers
{
    public class TcCustomerHelper
    {
        /// <summary>
        /// Delete all test materials
        /// </summary>
        /// <param name="testSettings">test settings</param>
        /// <param name="customers">customers page</param>
        public void DeleteTestCustomers( TcTestSettings testSettings, TiCustomers customers )
        {
            customers.Goto();
            customers.DeleteCustomersWithNameContaining( testSettings.NamePrefix );
            customers.Apply();
            customers.Cancel();
        }
    }
}
