﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Customer;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;
using Trumpf.AutoTest.Utilities;

namespace TestLeft.UI_Tests.Part
{
    /// <summary>
    /// This test class contains part specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcPartTest : TcBaseTestClass
    {
        private string mTestCustomerName;

        /// <summary>
        /// Gets the extended test environment.
        /// Creates / deletes the test customer used by the test methods
        /// </summary>
        //public override IDoSequence TestEnvironment => base.TestEnvironment
        //    .Do( CreateTestCustomer, DeleteTestCustomer, "TestCustomer" );

        /// <summary>
        /// Creates a new part, saves and then deletes it.
        /// </summary>
        [TestMethod, UniqueName( "FD4D71C7-26F6-4A4F-B16D-4A82C575FA33" )]
        public void NewPartAndDeleteTest()
        {
            Act( () =>
                {
                    var partName = TcSettings.NamePrefix + "NewPartTest";

                    var parts = HomeZoneApp.Goto<TcParts>();

                    parts.NewPart();
                    parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );

                    parts.SingleDetail.Name.Value = partName;

                    //parts.SingleDetail.Customer = mTestCustomerName;

                    parts.SingleDetail.DrawingNumber.Value = "NewPartTest_DrawNr";
                    parts.SingleDetail.DrawingVersion.Value = "V08.15-007";
                    parts.SingleDetail.ExternalName.Value = "NewPartTest_ExtName";
                    parts.SingleDetail.Archivable = false;
                    parts.SingleDetail.Note.Value = "ImportPartTest_Note";

                    Assert.IsTrue( parts.Toolbar.SaveButton.Enabled );
                    parts.SavePart();
                    Assert.IsFalse( parts.Toolbar.SaveButton.Enabled );

                    Assert.IsTrue( parts.Toolbar.DeleteButton.Enabled );
                    parts.DeletePart();
                    Assert.IsFalse( parts.Toolbar.DeleteButton.Enabled );
                } );
        }

        /// <summary>
        /// Imports a part, waits until the overlay disappears, fills some controls, saves the part and then deletes it.
        /// </summary>
        [TestMethod, UniqueName( "D74CE52A-BEF2-4959-83B8-3FD7088583A4" )]
        public void ImportPartTest()
        {
            Act( () =>
                {
                    var parts = HomeZoneApp.Goto<TcParts>();

                    parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );

                    parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                    parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
                    parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );

                    parts.SingleDetail.Name.Value = TcSettings.NamePrefix + "ImportPartTest";

                    parts.SingleDetail.Customer = mTestCustomerName;

                    parts.SingleDetail.DrawingNumber.Value = "ImportPartTest_DrawNr";
                    parts.SingleDetail.DrawingVersion.Value = "V08.15-007";
                    parts.SingleDetail.ExternalName.Value = "ImportPartTest_ExtName";
                    parts.SingleDetail.Archivable = false;
                    parts.SingleDetail.Note.Value = "ImportPartTest_Note";
                    parts.SingleDetailBendSolutions.New();
                    parts.SingleDetailCutSolutions.New();

                    Assert.IsTrue( parts.Toolbar.SaveButton.Enabled );
                    parts.SavePart();
                    Assert.IsFalse( parts.Toolbar.SaveButton.Enabled );

                    Assert.IsTrue( parts.Toolbar.BoostButton.Enabled );
                    parts.BoostPart();
                    parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                    parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                    // boost again to check dialog box handling
                    Assert.IsTrue( parts.Toolbar.BoostButton.Enabled );
                    parts.BoostPart();
                    parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                    parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                    Assert.IsTrue( parts.Toolbar.DeleteButton.Enabled );
                    parts.DeletePart();
                    Assert.IsFalse( parts.Toolbar.DeleteButton.Enabled );
                } );
        }

        /// <summary>
        /// Imports a part via Import Design button, waits until the overlay disappears, fills some controls, saves the part and then deletes it.
        /// </summary>
        [TestMethod, UniqueName( "6A3D54A6-59A6-4CC5-A8F4-5AB3A34BD462" )]
        public void ImportDesignTest()
        {
            Act( () =>
            {
                var parts = HomeZoneApp.Goto<TcParts>();

                parts.NewPart();

                parts.SingleDetailDesign.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );

                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
                parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );

                parts.SingleDetail.Name.Value = TcSettings.NamePrefix + "ImportDesignTest";

                parts.SingleDetail.Customer = mTestCustomerName;

                parts.SingleDetail.DrawingNumber.Value = "ImportDesignTestt_DrawNr";
                parts.SingleDetail.DrawingVersion.Value = "V08.15-007";
                parts.SingleDetail.Id = "UIT_" + parts.SingleDetail.Id;
                parts.SingleDetail.ExternalName.Value = "ImportDesignTest_ExtName";
                parts.SingleDetail.Archivable = false;
                parts.SingleDetail.Note.Value = "ImportDesignTest_Note";
                parts.SingleDetailBendSolutions.New();
                parts.SingleDetailCutSolutions.New();

                Assert.IsTrue( parts.Toolbar.SaveButton.Enabled );
                parts.SavePart();
                Assert.IsFalse( parts.Toolbar.SaveButton.Enabled );

                Assert.IsTrue( parts.Toolbar.BoostButton.Enabled );
                parts.BoostPart();
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

                Assert.IsTrue( parts.Toolbar.DeleteButton.Enabled );
                parts.DeletePart();
                Assert.IsFalse( parts.Toolbar.DeleteButton.Enabled );
            } );
        }

        private void CreateTestCustomer()
        {
            mTestCustomerName = TcSettings.NamePrefix + Guid.NewGuid();

            var customers = HomeZoneApp.On<TcCustomers>();

            customers.NewCustomer(
                                  mTestCustomerName,
                                  "C" + Guid.NewGuid(),
                                  "TRUMPF Allee 1",
                                  "71254",
                                  "Ditzingen",
                                  "Deutschland",
                                  "no comment" );

            customers.Apply();
            customers.Cancel();
        }

        private void DeleteTestCustomer()
        {
            var customers = HomeZoneApp.Goto<TcCustomers>();

            customers.DeleteCustomersWithNameContaining( mTestCustomerName );

            customers.Apply();
            customers.Cancel();
        }
    }
}
