using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.CutJob;
using TestLeft.TestLeftBase.PageObjects.PartOrder;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;

namespace TestLeft.UI_Tests.CutJob
{
    [TestClass]
    public class TcCutJobTest : TcBaseTestClass
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
        public void NewCutJobTest()
        {
            var cutJobs = HomeZoneApp.Goto<TcCutJobs>();

            cutJobs.NewCutJob();

            cutJobs.SingleDetail.Id = TcSettings.NamePrefix + "NewPartTest";

            cutJobs.SaveCutJob();
        }

        [TestMethod]
        public void DeleteCutJobTest()
        {
            var cutJobs = HomeZoneApp.Goto<TcCutJobs>();

            cutJobs.NewCutJob();

            cutJobs.DeleteCutJob();
        }

        [TestMethod]
        public void RawMaterialSelectionTest()
        {
            var cutJobs = HomeZoneApp.Goto<TcCutJobs>();

            cutJobs.NewCutJob();

            cutJobs.SingleDetail.SelectRawMaterial(1);

            Thread.Sleep(3000);

            cutJobs.SingleDetail.SelectRawMaterial("AL0M0130---");
        }
    }
}
