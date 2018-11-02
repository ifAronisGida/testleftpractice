using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using UiTests.Base;
using UiTests.Utilities;

namespace UiTests.Design
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
        [Tag( "Design" )]
        public void DesignOpenCloseTest()
        {
            Act( DoDesignOpenClose );
        }

        public void DoDesignOpenClose()
        {
            Trace.WriteLine( @"Starting Design open / close test." );
            var parts = HomeZone.GotoParts();

            parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );

            parts.SingleDetailDesign.Open();

            var visible = DesignApp.IsMainWindowVisible( TestSettings.DesignStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
            if( visible )
            {
                DesignApp.CloseApp();

                parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );
            }

            parts.Toolbar.Delete();

            Assert.IsTrue( visible, "Design window was not visible." );
        }
    }
}
