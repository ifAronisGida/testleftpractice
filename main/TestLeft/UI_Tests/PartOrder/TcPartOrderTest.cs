using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.PartOrder;
using TestLeft.TestLeftBase.Settings;
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
                var partOrders = HomeZoneApp.On<TcPartOrders>();

                partOrders.Goto();

                partOrders.NewPartOrder();

                //TODO complete test
                //partOrders.SingleDetail.Name = TcSettings.NamePrefix + "NewPartTest";

                //Assert.IsTrue( partOrders.Toolbar.SaveButton.Enabled );
                //partOrders.SavePart();
                Assert.IsFalse( partOrders.Toolbar.SaveButton.Enabled );

                Assert.IsTrue( partOrders.Toolbar.DeleteButton.Enabled );
                partOrders.DeletePartOrder();
                Assert.IsFalse( partOrders.Toolbar.DeleteButton.Enabled );
            } );
        }
    }
}
