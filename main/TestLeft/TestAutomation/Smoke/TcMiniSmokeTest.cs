using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.UI_Tests.Base;
using TestLeft.UI_Tests.Utilities;

namespace TestLeft.TestAutomation.Smoke
{
    /// <summary>
    /// This test class contains smoke tests and supporting test methods.
    /// These test methods are mainly used for module and PageObject tests.
    /// The smoke tests should clean up at the end.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcMiniSmokeTest : TcBaseTestClass
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

        /// <summary>
        /// Mini smoke test: creating test items, adding bend and cut solutions to parts and boosting them, deleting the test items.
        /// </summary>
        [TestMethod]
        public void _1_MiniSmokeTest()
        {
            CreateTestItems();

            //TODO
            //testing...

            DeleteTestItems();
        }

        /// <summary>
        /// Creates the test items.
        /// </summary>
        public void CreateTestItems()
        {
            Driver.Log.Message("Creating test items");
            var smokeHelpers = new TcSmokeHelpers();

            smokeHelpers.CreateTestMaterials();
            smokeHelpers.CreateTestMachines();
            smokeHelpers.CreateTestCustomers();
            smokeHelpers.CreateTestParts();
            smokeHelpers.CreateTestPartOrders();
            smokeHelpers.CreateTestCutJobs();
        }

        /// <summary>
        /// Deletes the test items.
        /// </summary>
        public void DeleteTestItems()
        {
            var smokeHelpers = new TcSmokeHelpers();

            smokeHelpers.DeleteTestCutJobs();
            smokeHelpers.DeleteTestPartOrders();
            smokeHelpers.DeleteTestParts();
            smokeHelpers.DeleteTestCustomers();
            smokeHelpers.DeleteTestMachines();
            smokeHelpers.DeleteTestMaterials();
        }
    }
}
