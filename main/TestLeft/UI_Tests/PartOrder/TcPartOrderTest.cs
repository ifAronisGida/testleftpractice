using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.PageObjects.PartOrder;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;
namespace TestLeft.UI_Tests.PartOrder
{
    [TestClass]
    public class TcPartOrderTest : TcBaseTestClass
    {
        [TestMethod, UniqueName( "223E645A-9210-42A7-8C71-DCE3DFDC2AE7" )]
        public void NewPartOrderAndDeleteTest()
        {
            Act( () =>
            {
                var partOrders = HomeZoneApp.Goto<TcPartOrders>();

                partOrders.NewPartOrder();

                //TODO complete test
                Assert.IsFalse( partOrders.CanSave );

                Assert.IsTrue( partOrders.CanDelete );
                partOrders.DeletePartOrder();
                Assert.IsFalse( partOrders.CanDelete );
            } );
        }

        [TestMethod, UniqueName( "79662E0F-0AF8-4F6D-8A44-F81537CF8430" )]
        public void SelectPartIntoOrderTest()
        {
            var parts = HomeZoneApp.Goto<TcParts>();
            parts.NewPart();
            parts.SingleDetail.Id = "TestPart";
            parts.SingleDetail.Name = "TestPart";
            parts.SavePart();

            var partOrders = HomeZoneApp.Goto<TcPartOrders>();
            partOrders.NewPartOrder();
            partOrders.SelectPart( "TestPart" );

            Assert.IsTrue( partOrders.CanSave );
        }
    }
}
