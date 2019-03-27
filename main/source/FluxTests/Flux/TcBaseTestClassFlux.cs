using HomeZone.UiCommonFunctions;
using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiCommonFunctions.PageObjectHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        protected TcPartPageObjectHelper mPartHelper = new TcPartPageObjectHelper();

        /// <summary>
        /// Cleanup before testing
        /// </summary>
        protected override void DoInitialization()
        {
            base.DoInitialization();
            mPartHelper.DeleteImportedParts( TestSettings, HomeZone.Parts );
            mMachineHelper.DeleteCreatedMachines( HomeZone.Machines );
        }
    }
}
