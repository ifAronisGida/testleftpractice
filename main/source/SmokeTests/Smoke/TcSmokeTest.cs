using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using HomeZone.UiTests.Base;
using HomeZone.UiTests.Utilities;

namespace HomeZone.SmokeTests.Smoke
{
    /// <summary>
    /// This test class contains smoke tests and supporting test methods.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcSmokeTest : TcBaseTestClass
    {
        private readonly TcSmokeHelpers mSmokeHelpers= new TcSmokeHelpers();
        private readonly TcSmokeTestsPart mSmokeTestsPart = new TcSmokeTestsPart();

        /// <summary>
        /// Smoke test: creating test items, adding bend and cut solutions to parts, testing..., deleting the test items.
        /// </summary>
        [TestMethod, UniqueName( "524A05EA-D25E-423E-8974-EF4CC6B7F8F0" )]
        [Tag( "Smoke" )]
        public void SmokeTest()
        {
            Act( DoSmokeTest );
        }

        /// <summary>
        /// Repeating:
        ///     Smoke test: creating test items, adding bend and cut solutions to parts, testing..., deleting the test items.
        /// Endless
        /// </summary>
        //[TestMethod, UniqueName( "4E5079D6-6820-4C01-B623-E1BB86AD8825" )]
        //[Tag( "Smoke" )]
        public void EndlessMiniSmokeTest()
        {
            Act( () =>
            {
                while( true )
                {
                    HomeZone.MainTabControl.AddNewTab();
                    DoSmokeTest();
                }
            } );
        }

        private void DoSmokeTest()
        {
            mSmokeHelpers.DoCreateTestItems();

            //TODO
            //testing...
            mSmokeTestsPart.ExecutePartSmokeTests();

            mSmokeHelpers.DoDeleteTestItems();
        }
    }
}
