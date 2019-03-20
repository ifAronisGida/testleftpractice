using HomeZone.UiCommonFunctions;
using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;

namespace HomeZone.FluxTests.Flux
{
    /// <summary>
    /// Base class containing helper objects for Flux tests
    /// </summary>
    [TestClass]
    public class TcBaseTestClassFlux : TcBaseTestClass
    {
        /// <summary>
        /// machine helper handling machine creation and deletion
        /// </summary>
        protected TcMachinePageObjectHelper mMachineHelper = new TcMachinePageObjectHelper();

        /// <summary>
        /// Cleanup after testexecution
        /// </summary>
        [TestCleanup, UniqueName( "5AD37799-3B74-494E-B38E-F4919C5C38E8" )]
        [Tag( "Flux" )]
        public void TestCleanup()
        {
            ExecuteUITest( DoTestCleanup, "Cleanup after testexecution" );
        }

        /// <summary>
        /// Cleanup after testexecution
        /// </summary>
        private void DoTestCleanup()
        {
            mMachineHelper.DeleteCreatedMachines( HomeZone.Machines );
        }
    }
}
