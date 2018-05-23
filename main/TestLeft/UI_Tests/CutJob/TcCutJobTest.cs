﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.CutJob;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.Settings;
using Trumpf.TruTops.Control.TestLeft.UI_Tests.Base;

namespace Trumpf.TruTops.Control.TestLeft.UI_Tests.CutJob
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
            var cutJobs = HomeZoneApp.On<TcCutJobs>();

            cutJobs.Goto();

            cutJobs.NewCutJob();

            //cutJobs.SingleDetail.Name = TcSettings.NamePrefix + "NewPartTest";

            //cutJobs.SavePart();
        }

        [TestMethod]
        public void DeleteCutJobTest()
        {
            var cutJobs = HomeZoneApp.On<TcCutJobs>();

            cutJobs.Goto();

            cutJobs.NewCutJob();

            cutJobs.DeleteCutJob();
        }
    }
}
