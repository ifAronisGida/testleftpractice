using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Design;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
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
            Act( () =>
            {
                Driver.Log.Message( @"Starting Design open / close test." );
                var parts = HomeZoneApp.Goto<TcParts>();

                parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );
                parts.WaitForDetailOverlayAppear( TcSettings.PartImportOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartImportOverlayDisappearTimeout );

                parts.SingleDetailDesign.Open();

                var design = new TcDesign( Driver );

                var visible = design.MainWindowVisible( TcSettings.DesignStartTimeout, TimeSpan.FromMilliseconds( 500 ) );
                if( visible )
                {
                    design.CloseApp();

                    parts.WaitForDetailOverlayDisappear( TcSettings.PartImportOverlayDisappearTimeout );
                }

                parts.DeletePart();

                Assert.IsTrue( visible );
            } );
        }
    }
}
