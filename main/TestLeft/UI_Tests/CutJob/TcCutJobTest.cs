using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.CutJob;
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
    }
}
