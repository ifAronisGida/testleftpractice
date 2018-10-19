using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
using TestLeft.UI_Tests.Utilities;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Design
{
    /// <summary>
    /// This test class contains Design specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcDesignTest : TcBaseTestClass
    {
        /// <summary>
        /// Creates a new part, opens and closes Design.
        /// </summary>
        [TestMethod, UniqueName( "744806A6-EABF-40FB-BC99-F3683F62D44C" )]
        public void DesignOpenCloseTest()
        {
            Act( DoDesignOpenClose );
        }

        public void DoDesignOpenClose()
        {
            Trace.WriteLine( @"Starting Design open / close test." );
            var parts = HomeZone.GotoParts();

            parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

            parts.SingleDetailDesign.Open();

            var visible = DesignApp.IsMainWindowVisible( TcSettings.DesignStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            if( visible )
            {
                DesignApp.CloseApp();

                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
            }

            parts.Toolbar.Delete();

            Assert.IsTrue( visible, "Design window was not visible." );
        }
    }
}
