using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.CutJob;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.CutJob
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
        public void NewCutJobAndDeleteTest()
        {
            Act( () =>
                {
                    var cutJobs = HomeZoneApp.Goto<TcCutJobs>();

                    cutJobs.NewCutJob();

                    cutJobs.SingleDetail.Id = TcSettings.NamePrefix + Guid.NewGuid().ToString().Replace( '-', '_' );

                    Assert.IsTrue( cutJobs.Toolbar.SaveButton.Enabled );
                    cutJobs.SaveCutJob();
                    Assert.IsFalse( cutJobs.Toolbar.SaveButton.Enabled );

                    Assert.IsTrue( cutJobs.Toolbar.DeleteButton.Enabled );
                    cutJobs.DeleteCutJob();
                    Assert.IsFalse( cutJobs.Toolbar.DeleteButton.Enabled );
                } );
        }

        [TestMethod, UniqueName( "2CE74B5D-0F60-4076-B34D-51BB571C197C" )]
        public void RawMaterialSelectionTest()
        {
            Act( () =>
            {
                var cutJobs = HomeZoneApp.Goto<TcCutJobs>();

                cutJobs.NewCutJob();

                cutJobs.SingleDetail.SelectRawMaterial( 1 );

                Thread.Sleep( 3000 );

                cutJobs.SingleDetail.SelectRawMaterial( "AL0M0130---" );

                Assert.IsTrue( cutJobs.Toolbar.RevertButton.Enabled );
                cutJobs.RevertCutJob();
                Assert.IsFalse( cutJobs.Toolbar.RevertButton.Enabled );
            } );
        }

        [TestMethod, UniqueName( "C3E21D8B-A964-4B72-89BC-C3940289ECE0" )]
        public void OrdersTableTest()
        {
            // Requires unfortunately a specially prepared nesting at the moment.

            Act( () =>
            {
                var orders = HomeZoneApp.On<TcCutJobContainedOrders>();

                var row = orders.GetRow( 0 );

                Assert.IsNotNull( row.DrawingButton );
                Assert.AreEqual( "UIT_Eckwinkel (Eckwinkel)", row.PartLink.Label );
                Assert.AreEqual( 0, row.Pending );
                Assert.AreEqual( 1, row.Total );
                Assert.AreEqual( "OR1", row.OrderLink.Label );
                Assert.AreEqual( "UIT_Kunde 1", row.Customer );
                Assert.AreEqual( new DateTime( 2018, 7, 31 ), row.TargetDate );
                Assert.AreEqual( "Cut1", row.CuttingProgram );
                Assert.IsTrue( row.AngularPositions.Contains( "360" ) );
                Assert.AreEqual( "Grid machining", row.DistanceMode );
                Assert.IsFalse( row.IgnoreProcessings.Checked );
                Assert.AreEqual( 0, row.SamplePartsCount );
                Assert.AreEqual( "UIT_Note", row.Note );

                row.DrawingButton.Click();
                Thread.Sleep( 5000 );
                Assert.IsTrue( HomeZoneApp.On<TcParts>().Visible );
            } );
        }
    }
}
