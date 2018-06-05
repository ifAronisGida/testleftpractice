using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Flux;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
using Trumpf.PageObjects.Waiting;


namespace TestLeft.UI_Tests.Flux
{
    /// <summary>
    /// This test class contains part specific tests.
    /// These test methods are mainly used for module and PageObject tests.
    /// It is not secured that the methods are cleaning up at the end.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcFluxTest : TcBaseTestClass
    {
        #region Class initializers
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            InitializeClass(context);
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            FinalizeClass();
        }
        #endregion

        /// <summary>
        /// Creates a new part with bend solution, opens it and closes Flux.
        /// </summary>
        [TestMethod]
        public void FluxOpenCloseTest()
        {
            Driver.Log.Message(@"Starting Flux open / close test.");
            var parts = HomeZoneApp.On<TcParts>();

            parts.Goto();

            //parts.Import(@"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo");
            parts.Import(@"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc");
            parts.WaitForDetailOverlayAppear(TcSettings.PartImportOverlayAppearTimeout);
            parts.WaitForDetailOverlayDisappear(TcSettings.PartImportOverlayDisappearTimeout);

            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailBendSolutions.OpenBendSolution("Bend1");
            parts.WaitForDetailOverlayAppear(TcSettings.PartImportOverlayAppearTimeout);

            var flux = new TcFlux();

            if (flux.FluxWindowVisible(TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds(500)))
            {
                flux.CloseApp();

                parts.WaitForDetailOverlayDisappear(TcSettings.PartImportOverlayDisappearTimeout);

                parts.DeletePart();
            }
            else
            {
                Driver.Log.Error(@"Flux main window is not visible.");
            }

            Driver.Log.Message(@"Flux open / close test finished.");
        }
    }
}
