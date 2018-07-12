using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.UI_Tests.Base;
using TestLeft.UI_Tests.Utilities;
using Trumpf.AutoTest.Facts;

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
        /// <summary>
        /// Mini smoke test: creating test items, adding bend and cut solutions to parts and boosting them, deleting the test items.
        /// </summary>
        [TestMethod, UniqueName( "524A05EA-D25E-423E-8974-EF4CC6B7F8F0" )]
        public void _1_MiniSmokeTest()
        {
            Act( () =>
            {
                CreateTestItems();

                //TODO
                //testing...

                DeleteTestItems();
            } );
        }

        /// <summary>
        /// Creates the test items.
        /// </summary>
        public void CreateTestItems()
        {
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
