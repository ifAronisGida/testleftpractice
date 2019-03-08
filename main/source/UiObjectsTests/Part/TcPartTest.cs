using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.UiObjectsTests.Part
{
    /// <summary>
    /// This test class contains part specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcPartTest : TcBaseTestClass
    {
        /// <summary>
        /// Creates a new part, saves and then deletes it.
        /// </summary>
        [TestMethod, UniqueName( "FD4D71C7-26F6-4A4F-B16D-4A82C575FA33" )]
        [Tag( "Part" )]
        public void NewPartAndDeleteTest()
        {
            Act( () =>
            {
                var partName = TestSettings.NamePrefix + "NewPartTest";

                var parts = HomeZone.Parts;
                parts.Goto();

                parts.Toolbar.New();
                parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );

                parts.SingleDetail.Name.Value = partName;

                parts.SingleDetail.DrawingNumber.Value = "NewPartTest_DrawNr";
                parts.SingleDetail.DrawingVersion.Value = "V08.15-007";
                parts.SingleDetail.ExternalName.Value = "NewPartTest_ExtName";
                parts.SingleDetail.Archivable = false;
                parts.SingleDetail.Note.Value = "ImportPartTest_Note";

                Assert.IsTrue( parts.Toolbar.CanSave );
                parts.Toolbar.Save();
                parts.WaitForDetailOverlayDisappear( TestSettings.SavingTimeout );
                Assert.IsFalse( parts.Toolbar.CanSave );

                Assert.IsTrue( parts.Toolbar.CanDelete );
                parts.Toolbar.Delete();
                parts.WaitForDetailOverlayDisappear( TestSettings.SavingTimeout );
                Assert.IsFalse( parts.Toolbar.CanDelete );
            } );
        }

        /// <summary>
        /// Imports a part, waits until the overlay disappears, fills some controls, saves the part and then deletes it.
        /// </summary>
        [TestMethod, UniqueName( "D74CE52A-BEF2-4959-83B8-3FD7088583A4" )]
        [Tag( "Part" )]
        public void ImportPartTest()
        {
            Act( () =>
                {
                    var parts = HomeZone.GotoParts();

                    parts.Toolbar.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );

                    parts.WaitForDetailOverlayAppear();
                    parts.WaitForDetailOverlayDisappear();
                    parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );

                    parts.SingleDetail.Name.Value = TestSettings.NamePrefix + "ImportPartTest";

                    parts.SingleDetail.DrawingNumber.Value = "ImportPartTest_DrawNr";
                    parts.SingleDetail.DrawingVersion.Value = "V08.15-007";
                    parts.SingleDetail.ExternalName.Value = "ImportPartTest_ExtName";
                    parts.SingleDetail.Archivable = false;
                    parts.SingleDetail.Note.Value = "ImportPartTest_Note";
                    parts.SingleDetailBendSolutions.New();
                    parts.SingleDetailCutSolutions.New();

                    Assert.IsTrue( parts.Toolbar.CanSave );
                    parts.Toolbar.Save();
                    Assert.IsFalse( parts.Toolbar.CanSave );

                    Assert.IsTrue( parts.Toolbar.CanBoost );
                    parts.Toolbar.Boost();
                    parts.WaitForDetailOverlayAppear();
                    parts.WaitForDetailOverlayDisappear();

                    // boost again to check dialog box handling
                    Assert.IsTrue( parts.Toolbar.CanBoost );
                    parts.Toolbar.Boost();
                    parts.WaitForDetailOverlayAppear();
                    parts.WaitForDetailOverlayDisappear();

                    Assert.IsTrue( parts.Toolbar.CanDelete );
                    parts.Toolbar.Delete();
                    Assert.IsFalse( parts.Toolbar.CanDelete );
                } );
        }

        /// <summary>
        /// Imports a part via Import Design button, waits until the overlay disappears, fills some controls, saves the part and then deletes it.
        /// </summary>
        [TestMethod, UniqueName( "6A3D54A6-59A6-4CC5-A8F4-5AB3A34BD462" )]
        [Tag( "Part" )]
        public void ImportDesignTest()
        {
            Act( () =>
            {
                var parts = HomeZone.GotoParts();

                parts.Toolbar.New();

                parts.SingleDetailDesign.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );

                parts.WaitForDetailOverlayAppear();
                parts.WaitForDetailOverlayDisappear();
                parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );

                parts.SingleDetail.Name.Value = TestSettings.NamePrefix + "ImportDesignTest";

                parts.SingleDetail.DrawingNumber.Value = "ImportDesignTestt_DrawNr";
                parts.SingleDetail.DrawingVersion.Value = "V08.15-007";
                parts.SingleDetail.Id = "UIT_" + parts.SingleDetail.Id;
                parts.SingleDetail.ExternalName.Value = "ImportDesignTest_ExtName";
                parts.SingleDetail.Archivable = false;
                parts.SingleDetail.Note.Value = "ImportDesignTest_Note";
                parts.SingleDetailBendSolutions.New();
                parts.SingleDetailCutSolutions.New();

                Assert.IsTrue( parts.Toolbar.CanSave );
                parts.Toolbar.Save();
                Assert.IsFalse( parts.Toolbar.CanSave );

                Assert.IsTrue( parts.Toolbar.CanBoost );
                parts.Toolbar.Boost();
                parts.WaitForDetailOverlayAppear();
                parts.WaitForDetailOverlayDisappear();

                Assert.IsTrue( parts.Toolbar.CanDelete );
                parts.Toolbar.Delete();
                Assert.IsFalse( parts.Toolbar.CanDelete );
            } );
        }

        [TestMethod, UniqueName( "FC1DB80F-D95D-49C1-A83C-5E37D513B30C" )]
        [Tag( "Part" )]
        public void NewPartTest()
        {
            var parts = HomeZone.Parts;     // get access to the parts category

            parts.Goto();                   // go to the parts category

            parts.Toolbar.New();            // create a new part

            parts.SingleDetail.Name.Value = TestSettings.NamePrefix + "NewPart";    // assign a new name

            parts.Toolbar.Save();           // save the new part
        }
    }
}
