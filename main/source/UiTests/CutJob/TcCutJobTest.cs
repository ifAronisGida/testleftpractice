using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using HomeZone.UiTests.Base;
using HomeZone.UiTests.Utilities;

namespace HomeZone.UiTests.CutJob
{
    /// <summary>
    /// This test class contains cut job specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcCutJobTest : TcBaseTestClass
    {
        /// <summary>
        /// Creates a new cut job, saves and then deletes it.
        /// </summary>
        [TestMethod, UniqueName( "6329FFBB-0DEA-43D0-A43F-472929C319A8" )]
        [Tag( "CutJob" )]
        public void NewCutJobAndDeleteTest()
        {
            Act( () =>
                {
                    var cutJobs = HomeZone.GotoCutJobs();

                    cutJobs.Toolbar.New();

                    cutJobs.BaseInfo.Id.Value = TestSettings.NamePrefix + Guid.NewGuid().ToString().Replace( '-', '_' );

                    Assert.IsTrue( cutJobs.Toolbar.CanSave );
                    cutJobs.Toolbar.Save();
                    Assert.IsFalse( cutJobs.Toolbar.CanSave );

                    Assert.IsTrue( cutJobs.Toolbar.CanDelete );
                    cutJobs.Toolbar.Delete();
                    Assert.IsFalse( cutJobs.Toolbar.CanDelete );
                } );
        }

        [TestMethod, UniqueName( "2CE74B5D-0F60-4076-B34D-51BB571C197C" )]
        [Tag( "CutJob" )]
        public void RawMaterialSelectionTest()
        {
            Act( () =>
            {
                var cutJobs = HomeZone.GotoCutJobs();

                cutJobs.Toolbar.New();

                cutJobs.BaseInfo.RawMaterial.Value = "AL0M0130---";

                Thread.Sleep( 3000 );

                Assert.IsTrue( cutJobs.Toolbar.CanRevert );
                cutJobs.Toolbar.Revert();
                Assert.IsFalse( cutJobs.Toolbar.CanRevert );
            } );
        }

        [TestMethod, UniqueName( "C3E21D8B-A964-4B72-89BC-C3940289ECE0" )]
        [Tag( "CutJob" )]
        public void OrdersTableTest()
        {
            const string PartName = "UiT_Demoteil";
            const string OrderName = "UiT_OR_OrdersTable";
            const string NestingName = "UiT_N_OrdersTable";
            const string CustomerName = "UiT_OrdersTableTest";
            var FinishDate = new DateTime( 2018, 7, 31 );

            Act( () =>
            {
                var parts = HomeZone.GotoParts();
                parts.Toolbar.Import( @"c:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                parts.SingleDetail.Name.Value = PartName;
                parts.SingleDetail.Id = PartName;
                parts.SingleDetail.Note.Value = "Noote";

                var customerAdmin = parts.SingleDetail.OpenCustomerAdministration();
                if( customerAdmin.Count() == 1 && customerAdmin.Name.Value == string.Empty )
                {
                    customerAdmin.Name.Value = CustomerName;
                    customerAdmin.Apply();
                    customerAdmin.Select();
                }
                else if( !customerAdmin.SelectCustomer( CustomerName ) )
                {
                    customerAdmin.NewCustomer( CustomerName, "", "", "", "", "", "" );
                    customerAdmin.Apply();
                    customerAdmin.Select();
                }
                else
                {
                    customerAdmin.Select();
                }

                parts.Toolbar.Save();

                var partOrders = HomeZone.GotoPartOrders();
                partOrders.Toolbar.New();
                partOrders.BaseInfo.ID.Value = OrderName;
                partOrders.BaseInfo.FinishDate.Value = FinishDate;
                partOrders.PartInfo.SelectPart( PartName );
                partOrders.Toolbar.Save();

                var nestings = HomeZone.GotoCutJobs();
                nestings.Toolbar.New();
                nestings.BaseInfo.Id.Value = NestingName;
                nestings.ContainedOrders.AddPartOrder( OrderName );
                nestings.Toolbar.Save();

                var row = nestings.ContainedOrders.GetRow( 0 );

                Assert.IsNotNull( row.DrawingButton );
                Assert.AreEqual( $"{PartName} ({PartName})", row.PartLink.Label );
                Assert.AreEqual( 0, row.Pending );
                Assert.AreEqual( 1, row.Total );
                Assert.AreEqual( OrderName, row.OrderLink.Label );
                Assert.AreEqual( CustomerName, row.Customer );
                Assert.AreEqual( StripTime( FinishDate ), StripTime( row.TargetDate.Value ) );
                Assert.AreEqual( "Reprocessing", row.CuttingProgram );
                Assert.IsTrue( row.AngularPositions.Contains( "0" ) );
                Assert.AreEqual( "Grid machining", row.DistanceMode );
                Assert.IsFalse( row.IgnoreProcessings.Value );
                Assert.AreEqual( 0, row.SamplePartsCount );
                Assert.AreEqual( "Noote", row.Note );

                row.DrawingButton.Click();
                Thread.Sleep( 5000 );

                Assert.IsTrue( parts.IsVisible );

                HomeZone.GotoCutJobs();
                nestings.ResultColumn.SelectItem( NestingName );
                nestings.Toolbar.Delete();

                HomeZone.GotoPartOrders();
                partOrders.ResultColumn.SelectItem( OrderName );
                partOrders.Toolbar.Delete();

                HomeZone.GotoParts();
                parts.ResultColumn.SelectItem( PartName );
                parts.Toolbar.Delete();
            } );
        }

        [TestMethod, UniqueName( "6E535F11-9B88-4F75-8240-B70C97EC8471" )]
        [Tag( "CutJob" )]
        public void RawSheetsTest()
        {
            Act( () =>
            {
                var cutJobs = HomeZone.GotoCutJobs();
                cutJobs.Toolbar.New();

                cutJobs.BaseInfo.RawMaterial.Value = "AL0M0050---";

                Thread.Sleep( 2000 );

                var solution = cutJobs.SheetProgram;
                Assert.AreEqual( 1, solution.RawSheets.Count );

                var newRawSheet = solution.AddRawSheet();
                newRawSheet.Quantity.Value = 3;

                Thread.Sleep( 2000 );

                newRawSheet.Delete();

                cutJobs.Toolbar.Save();
            } );
        }

        private DateTime? StripTime( DateTime? date )
        {
            if( date == null )
            {
                return null;
            }

            var d = ( DateTime )date;

            return new DateTime( d.Year, d.Month, d.Day );
        }
    }
}
