using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiObjectsTests.FunctionalTests.DA07_Nesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;

namespace HomeZone.SmokeTests.FunctionalTests
{
    /// <summary>
    /// This test class contains functional tests for nesting (DA07).
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcDa07_Nesting : TcBaseTestClass
    {
        private readonly TcDa07 mDa07 = new TcDa07();

        /// <summary>
        /// Functional tests DA07 Nesting.
        /// </summary>
        [ TestMethod, UniqueName( "DEE02D2D-F772-438E-9A2B-1567BFCE2BE4" ) ]
        //[Tag( "Functional tests" )]
        public void Da07_Nesting()
        {
            Act( mDa07.DA7_01 );
        }
    }
}
