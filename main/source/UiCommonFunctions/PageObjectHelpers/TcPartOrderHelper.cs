using HomeZone.UiCommonFunctions.TestSettings;
using HomeZone.UiObjectInterfaces.PartOrder;

namespace HomeZone.UiCommonFunctions.PageObjectHelpers
{
    public class TcPartOrderHelper
    {
        /// <summary>
        /// Delete all test part orders
        /// </summary>
        /// <param name="testSettings">test settings</param>
        /// <param name="partOrder">part order page</param>
        public void DeleteTestPartOrders( TcTestSettings testSettings, TiPartOrders partOrder )
        {
            partOrder.Goto();
            partOrder.ResultColumn.SelectItems( testSettings.NamePrefix );
            if( partOrder.ResultColumn.Count > 0 )
            {
                partOrder.Toolbar.Delete();
            }
            partOrder.ResultColumn.ClearSearch();
        }
    }
}
