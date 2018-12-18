using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using HomeZone.UiTests.Base;
using HomeZone.UiTests.Utilities;

namespace HomeZone.UiTests.Cut
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
        /// A cut machine should be available.
        /// </summary>
        [TestMethod, UniqueName( "5F3AF1BB-5308-440E-8E46-9268518E0FF1" )]
        [Tag( "Cut" )]
        public void CutOpenCloseTest()
        {
            Act( DoCutOpenClose );
        }

        public void DoCutOpenClose()
        {
            Trace.WriteLine( @"Starting Cut open / close test." );
            var parts = HomeZone.GotoParts();

            parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            parts.SingleDetailCutSolutions.New();
            parts.SingleDetailCutSolutions.OpenCutSolution( "Cut1" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );

            var cut = CutApp;

            if( cut.TechnologyTableSelectionDialog.IsDialogVisible( TestSettings.CutStartTimeout, TimeSpan.FromMilliseconds( 500 ) ) )
            {
                cut.TechnologyTableSelectionDialog.Close();
            }

            var visible = cut.IsMainWindowVisible( TestSettings.CutStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            if( visible )
            {
                cut.CloseApp();

                parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );
            }

            parts.Toolbar.Delete();

            Assert.IsTrue( visible, "Cut window was not visible." );
        }
    }
}
