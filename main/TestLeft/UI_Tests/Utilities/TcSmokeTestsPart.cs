using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.UI_Tests.Base;
using TestLeft.UI_Tests.Cut;
using TestLeft.UI_Tests.Design;
using TestLeft.UI_Tests.Flux;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Utilities
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
        public void ExecutePartSmokeTests()
        {
            new TcDesignTest().DoDesignOpenClose();
            new TcCutTest().DoCutOpenClose();
            new TcFluxTest().DoFluxOpenClose();

        }
    }
}
