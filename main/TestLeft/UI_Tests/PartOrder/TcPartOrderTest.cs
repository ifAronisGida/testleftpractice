using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.PartOrder;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.Settings;
using Trumpf.TruTops.Control.TestLeft.UI_Tests.Base;

namespace Trumpf.TruTops.Control.TestLeft.UI_Tests.PartOrder
{
    [TestClass]
    public class TcPartOrderTest : TcBaseTestClass
    {
        #region Class initializers
        [ClassInitialize]
        public static void ClassInitialize( TestContext context )
        {
            InitializeClass( context );
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            FinalizeClass();
        }
        #endregion

        [TestMethod]
        public void NewPartOrderTest()
        {
            var partOrders = HomeZoneApp.On<TcPartOrders>();

            partOrders.Goto();

            partOrders.NewPartOrder();

            //partOrders.SingleDetail.Name = TcSettings.NamePrefix + "NewPartTest";

            //partOrders.SavePart();
        }

        [TestMethod]
        public void DeletePartOrderTest()
        {
            var partOrders = HomeZoneApp.On<TcPartOrders>();

            partOrders.Goto();

            partOrders.NewPartOrder();

            partOrders.DeletePartOrder();
        }
    }
}
