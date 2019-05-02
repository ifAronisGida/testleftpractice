using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.UiObjectsTests.PartOrder
{
    [TestClass]
    public class TcPartOrderTest : TcBaseTestClass
    {
        [TestMethod, UniqueName( "223E645A-9210-42A7-8C71-DCE3DFDC2AE7" )]
        [Tag( "PartOrder" )]
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
        [Tag( "PartOrder" )]
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

        [TestMethod]
        public void ImportPartOrderTest()
        {
            var partOrders = HomeZone.GotoPartOrders();
            partOrders.Toolbar.Import( @"c:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            partOrders.WaitForDetailOverlayAppear();
            partOrders.WaitForDetailOverlayDisappear();

            partOrders.PartInfo.Design.Boost();
            partOrders.WaitForDetailOverlayAppear();
            partOrders.WaitForDetailOverlayDisappear();
        }

        [TestMethod]
        public void BulkImportTest()
        {
            var partOrders = HomeZone.GotoPartOrders();
            partOrders.ImportDirectory( @"c:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase" );
        }

        [TestMethod]
        public void BulkChangeTest()
        {
            var parts = HomeZone.GotoParts();

            Log.Info( "Import 2 parts." );
            parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );
            parts.WaitForDetailOverlayAppear();
            parts.WaitForDetailOverlayDisappear();
            parts.SingleDetail.Id = TestSettings.NamePrefix + "Bulk1";
            parts.Toolbar.Save();
            parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Zugwinkel.scdoc" );
            parts.WaitForDetailOverlayAppear();
            parts.WaitForDetailOverlayDisappear();
            parts.SingleDetail.Id = TestSettings.NamePrefix + "Bulk2";
            parts.Toolbar.Save();

            Log.Info( "Select the imported parts and create part orders." );
            parts.ResultColumn.SelectItems( TestSettings.NamePrefix + "Bulk" );
            parts.ResultColumn.SelectAll();
            parts.Toolbar.CreatePartOrder();

            var partOrders = HomeZone.GotoPartOrders();
            partOrders.BaseInfoBulk.ID.Value = "BulkID";

        }
    }
}
