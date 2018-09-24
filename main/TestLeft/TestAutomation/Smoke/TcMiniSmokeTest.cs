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
        private readonly TcSmokeHelpers mSmokeHelpers= new TcSmokeHelpers();


        /// <summary>
        /// Mini smoke test: creating test items, adding bend and cut solutions to parts, ..., deleting the test items.
        /// </summary>
        [TestMethod, UniqueName( "524A05EA-D25E-423E-8974-EF4CC6B7F8F0" )]
        [Tag( "Smoke" )]
        public void _1_MiniSmokeTest()
        {
            Act( () =>
            {
                mSmokeHelpers.CreateTestItems();

                //TODO
                //testing...

                mSmokeHelpers.DeleteTestItems();
            } );
        }
    }
}
