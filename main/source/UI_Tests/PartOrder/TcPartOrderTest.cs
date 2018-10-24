﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.UI_Tests.Base;
using TestLeft.UI_Tests.Utilities;
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
                var parts = HomeZone.GotoParts();
                parts.Toolbar.New();
                parts.SingleDetail.Id = "TestPart";
                parts.SingleDetail.Name.Value = "TestPart";
                parts.Toolbar.Save();

                var partOrders = HomeZone.GotoPartOrders();
                var toolbar = partOrders.Toolbar;

                toolbar.New();

                //TODO complete test
                Assert.IsFalse( toolbar.CanSave );

                partOrders.BaseInfo.ID.Value = "TestOrder";
                partOrders.PartInfo.SelectPart( "TestPart" );
                partOrders.Toolbar.Save();

                partOrders.ResultColumn.SelectItem( "TestOrder" );

                Assert.IsTrue( toolbar.CanDelete );
                toolbar.Delete();
                Assert.IsFalse( toolbar.CanDelete );

                parts = HomeZone.GotoParts();
                parts.ResultColumn.SelectItem( "TestPart" );
                parts.Toolbar.Delete();
            } );
        }

        [TestMethod, UniqueName( "79662E0F-0AF8-4F6D-8A44-F81537CF8430" )]
        public void SelectPartIntoOrderTest()
        {
            var parts = HomeZone.GotoParts();
            parts.Toolbar.New();
            parts.SingleDetail.Id = "TestPart";
            parts.SingleDetail.Name.Value = "TestPart";
            parts.Toolbar.Save();

            var partOrders = HomeZone.GotoPartOrders();
            partOrders.Toolbar.New();
            partOrders.PartInfo.SelectPart( "TestPart" );

            Assert.IsTrue( partOrders.Toolbar.CanSave );
        }
    }
}