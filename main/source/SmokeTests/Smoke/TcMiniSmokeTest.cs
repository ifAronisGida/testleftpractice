using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using UiTests.Base;
using UiTests.Utilities;


namespace SmokeTests.Smoke
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
        private readonly TcSmokeTestsPart mSmokeTestsPart = new TcSmokeTestsPart();

        /// <summary>
        /// Mini smoke test: creating test items, adding bend and cut solutions to parts, testing..., deleting the test items.
        /// </summary>
        [TestMethod, UniqueName( "524A05EA-D25E-423E-8974-EF4CC6B7F8F0" )]
        [Tag( "Smoke" )]
        public void MiniSmokeTest()
        {
            Act( () =>
            {
                mSmokeHelpers.CreateTestItems();

                //TODO
                //testing...
                mSmokeTestsPart.ExecutePartSmokeTests();

                mSmokeHelpers.DeleteTestItems();
            } );
        }
    }
}
