using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Part;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.Settings;
using Trumpf.TruTops.Control.TestLeft.UI_Tests.Base;

namespace Trumpf.TruTops.Control.TestLeft.UI_Tests.Part
{
    /// <summary>
    /// This test class contains part specific tests.
    /// These test methods are mainly used for module and PageObject tests.
    /// It is not secured that the methods are cleaning up at the end.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcPartTest : TcBaseTestClass
    {
        #region Class initializers
        [ClassInitialize]
        public static void ClassInitialize( TestContext context )
        {
            InitializeClass( context );
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            FinalizeClass();
        }
        #endregion

        /// <summary>
        /// Creates a new part and saves it.
        /// </summary>
        [TestMethod]
        public void NewPartTest()
        {
            var parts = HomeZoneApp.On<TcParts>();

            parts.Goto();

            parts.NewPart();

            parts.SingleDetail.Name = TcSettings.NamePrefix + "NewPartTest";

            parts.SavePart();
        }

        /// <summary>
        /// Imports a part, waits until the overlay disappears, fills some controls and saves the part.
        /// </summary>
        [TestMethod]
        public void ImportPartTest()
        {
            var parts = HomeZoneApp.On<TcParts>();

            parts.Goto();

            parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );

            parts.WaitForDetailOverlayAppear( TcSettings.PartImportOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TcSettings.PartImportOverlayDisappearTimeout );
            parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );

            parts.SingleDetail.Name = TcSettings.NamePrefix + "ImportPartTest";

            parts.SingleDetail.Customer = TcSettings.NamePrefix + "Kunde 2";        // der Kunde muss bereits angelegt sein

            parts.SingleDetail.DrawingNumber = "ImportPartTest_DrawNr";
            parts.SingleDetail.DrawingVersion = "V08.15-007";
            parts.SingleDetail.ExternalName = "ImportPartTest_ExtName";
            parts.SingleDetail.Archivable = false;
            parts.SingleDetail.Note = "ImportPartTest_Note";

            parts.SavePart();
        }

        /// <summary>
        /// Imports a part via Import Design button, waits until the overlay disappears, fills some controls and saves the part.
        /// </summary>
        [TestMethod]
        public void ImportDesignTest()
        {
            var parts = HomeZoneApp.On<TcParts>();

            parts.Goto();

            parts.NewPart();

            parts.SingleDetailDesign.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );

            parts.WaitForDetailOverlayAppear( TcSettings.PartImportOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TcSettings.PartImportOverlayDisappearTimeout );
            parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );

            parts.SingleDetail.Name = TcSettings.NamePrefix + "ImportDesignTest";

            parts.SingleDetail.Customer = TcSettings.NamePrefix + "Kunde 2";        // der Kunde muss bereits angelegt sein

            parts.SingleDetail.DrawingNumber = "ImportDesignTestt_DrawNr";
            parts.SingleDetail.DrawingVersion = "V08.15-007";
            parts.SingleDetail.Id = "UIT_" + parts.SingleDetail.Id;
            parts.SingleDetail.ExternalName = "ImportDesignTest_ExtName";
            parts.SingleDetail.Archivable = false;
            parts.SingleDetail.Note = "ImportDesignTest_Note";

            parts.SavePart();
        }

        /// Imports a part, waits until the overlay disappears, fills some controls, saves the part and then deletes it.
        [TestMethod]
        public void DeletePartTest()
        {
            var parts = HomeZoneApp.On<TcParts>();

            parts.Goto();

            parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );

            parts.WaitForDetailOverlayAppear( TcSettings.PartImportOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TcSettings.PartImportOverlayDisappearTimeout );
            parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );

            parts.SingleDetail.Name = TcSettings.NamePrefix + "DeletePartTest";

            //parts.SingleDetail.Customer = TcSettings.NamePrefix + "Kunde 2";        // der Kunde muss bereits angelegt sein

            parts.SingleDetail.DrawingNumber = "DeletePartTest_DrawNr";
            parts.SingleDetail.DrawingVersion = "V08.15-007";
            parts.SingleDetail.ExternalName = "DeletePartTest_ExtName";
            parts.SingleDetail.Archivable = false;
            parts.SingleDetail.Note = "DeletePartTest_Note";

            parts.SavePart();

            parts.DeletePart();
        }

        /// <summary>
        /// Tests the MessageBox handling via deleting a part.
        /// </summary>
        [TestMethod]
        public void MessageBoxTest()
        {
            var parts = HomeZoneApp.On<TcParts>();

            parts.Goto();

            parts.NewPart();

            parts.SingleDetail.Name = TcSettings.NamePrefix + "ImportPartTest";
            parts.DeletePart();
        }
    }
}
