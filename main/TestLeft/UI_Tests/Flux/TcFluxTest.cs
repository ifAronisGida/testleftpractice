using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Flux;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Flux
{
    /// <summary>
    /// This test class contains Flux specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcFluxTest : TcBaseTestClass
    {
        /// <summary>
        /// Creates a new part with bend solution, opens it and closes Flux.
        /// </summary>
        [TestMethod, UniqueName( "572477DE-8303-4579-AB5A-4CD33905319A" )]
        public void FluxOpenCloseTest()
        {
            Act( () =>
            {
                Driver.Log.Message( @"Starting Flux open / close test." );
                var parts = HomeZoneApp.Goto<TcParts>();

                parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                parts.SingleDetailBendSolutions.New();
                parts.SingleDetailBendSolutions.OpenBendSolution( "Bend1" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );

                var flux = new TcFlux( Driver );

                var visible = flux.MainWindowVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                if( visible )
                {
                    flux.CloseApp();

                    parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
                }

                parts.DeletePart();

                Assert.IsTrue( visible );
            } );
        }
    }
}
