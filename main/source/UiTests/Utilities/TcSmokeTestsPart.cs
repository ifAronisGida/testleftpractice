using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Base;

namespace HomeZone.UiTests.Utilities
{
    /// <summary>
    /// This test class contains smoke tests for parts.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcSmokeTestsPart : TcBaseTestClass
    {
        /// <summary>
        /// Executes the part smoke tests.
        /// </summary>
        [TestMethod, UniqueName( "C04679F1-DD36-4F15-9490-9F87DA3C15F5" )]
        [Tag( "SmokeTestsPart" )]
        public void ExecutePartSmokeTests()
        {
            //new TcDesignTest().DoDesignOpenClose();
            //new TcCutTest().DoCutOpenClose();
            //new TcFluxTest().DoFluxOpenClose();

        }
    }
}
