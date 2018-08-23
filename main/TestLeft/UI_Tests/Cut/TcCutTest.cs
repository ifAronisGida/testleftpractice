using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Cut;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Cut
{
    /// <summary>
    /// This test class contains Cut specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcCutTest : TcBaseTestClass
    {
        /// <summary>
        /// Creates a new part with cut solution, opens it and closes Cut.
        /// </summary>
        [TestMethod, UniqueName( "5F3AF1BB-5308-440E-8E46-9268518E0FF1" )]
        public void CutOpenCloseTest()
        {
            Act( () =>
            {
                Driver.Log.Message( @"Starting Cut open / close test." );
                var parts = HomeZoneApp.Goto<TcParts>();

                parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                parts.SingleDetailCutSolutions.New();
                parts.SingleDetailCutSolutions.OpenCutSolution( "Cut1" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );

                var cut = new TcCut( Driver );

                if( cut.TechnologyTableSelectionDialog.DialogIsVisible( TcSettings.CutStartTimeout, TimeSpan.FromMilliseconds( 500 ) ) )
                {
                    cut.TechnologyTableSelectionDialog.Close();
                }

                var visible = cut.MainWindowIsVisible( TcSettings.CutStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                if( visible )
                {
                    cut.CloseApp();

                    parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
                }

                parts.DeletePart();

                Assert.IsTrue( visible, "Cut window was not visible." );
            } );
        }
    }
}
