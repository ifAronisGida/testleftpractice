using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Customer;
using TestLeft.TestLeftBase.PageObjects.CutJob;
using TestLeft.TestLeftBase.PageObjects.Flux;
using TestLeft.TestLeftBase.PageObjects.Machine;
using TestLeft.TestLeftBase.PageObjects.Material;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.PageObjects.PartOrder;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;

namespace TestLeft.UI_Tests.Utilities
{
    /// <summary>
    /// This test class contains supporting test methods for the smoke tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcSmokeHelpers : TcBaseTestClass
    {
        /// <summary>
        /// Creates some test materials by duplicating existing materials:
        /// 1.0038, Cu and Ti.
        /// </summary>
        [TestMethod]
        public void CreateTestMaterials()
        {
            var materials = HomeZoneApp.Goto<TcMaterials>();
            var materialCount = materials.ResultColumn.Count;

            DuplicateAndSave( "1.0038" );
            DuplicateAndSave( "Cu" );
            DuplicateAndSave( "Ti" );

            materials.ResultColumn.ClearSearch();

            Assert.AreEqual( materialCount + 3, materials.ResultColumn.Count );

            void DuplicateAndSave(string materialId)
            {
                materials.SelectMaterial( materialId );

                materials.DuplicateMaterial();

                var name = TcSettings.NamePrefix + materials.Detail.Id;
                materials.Detail.Id = name;
                materials.Detail.Name = name;

                Assert.IsTrue( materials.Toolbar.SaveButton.Enabled );
                materials.SaveMaterial();
                materials.WaitForDetailOverlayAppear( TcSettings.MaterialOverlayAppearTimeout );
                materials.WaitForDetailOverlayDisappear( TcSettings.MaterialOverlayDisappearTimeout );
                Assert.IsFalse( materials.Toolbar.SaveButton.Enabled );
            }
        }

        /// <summary>
        /// Deletes the test materials.
        /// </summary>
        [TestMethod]
        public void DeleteTestMaterials()
        {
            var materials = HomeZoneApp.Goto<TcMaterials>();
            var materialCount = materials.ResultColumn.Count;

            var testMaterialsCount = materials.SelectMaterials( TcSettings.NamePrefix );
            if( testMaterialsCount > 0 )
            {
                materials.DeleteMaterial();
            }

            materials.WaitForDetailOverlayAppear( TcSettings.MaterialOverlayAppearTimeout );
            materials.WaitForDetailOverlayDisappear( TcSettings.MaterialOverlayDisappearTimeout );

            materials.ResultColumn.ClearSearch();

            Assert.AreEqual( materialCount - testMaterialsCount, materials.ResultColumn.Count );
        }

        /// <summary>
        /// Creates some bend and cut test machines.
        /// </summary>
        [TestMethod]
        public void CreateTestMachines()
        {
            var machines = HomeZoneApp.Goto<TcMachines>();
            var machineCount = machines.ResultColumn.Count;

            machines.NewBendMachine( "TruBend 5320 (6-axes) B23", TcSettings.NamePrefix + Guid.NewGuid() );
            Assert.IsTrue( machines.Toolbar.SaveButton.Enabled );
            machines.SaveMachine();
            Assert.IsFalse( machines.Toolbar.SaveButton.Enabled );

            machines.WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );

            machines.NewBendMachine( "TruBend 1066 (4-axes,Trumpf_80mm) B22", TcSettings.NamePrefix + Guid.NewGuid() );
            Assert.IsTrue( machines.Toolbar.SaveButton.Enabled );
            machines.SaveMachine();
            Assert.IsFalse( machines.Toolbar.SaveButton.Enabled );

            machines.WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );

            machines.NewCutMachine( "TruLaser 3030 (L20)", TcSettings.NamePrefix + Guid.NewGuid(), 3 );
            Assert.IsTrue( machines.Toolbar.SaveButton.Enabled );
            machines.SaveMachine();
            Assert.IsFalse( machines.Toolbar.SaveButton.Enabled );

            machines.WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );

            machines.NewCutMachine( "TruLaser Center 7030 (L26)", TcSettings.NamePrefix + Guid.NewGuid(), 0 );
            Assert.IsTrue( machines.Toolbar.SaveButton.Enabled );
            machines.SaveMachine();
            Assert.IsFalse( machines.Toolbar.SaveButton.Enabled );

            machines.WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );

            machines.NewCutMachine( "TruLaser 3060 (L66)", TcSettings.NamePrefix + Guid.NewGuid(), "8000" );
            Assert.IsTrue( machines.Toolbar.SaveButton.Enabled );
            machines.SaveMachine();
            Assert.IsFalse( machines.Toolbar.SaveButton.Enabled );

            machines.WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );

            Assert.AreEqual( machineCount + 5, machines.ResultColumn.Count );
        }

        /// <summary>
        /// Deletes the test machines.
        /// </summary>
        [TestMethod]
        public void DeleteTestMachines()
        {
            var machines = HomeZoneApp.Goto<TcMachines>();
            var machineCount = machines.ResultColumn.Count;

            var testMachinesCount = machines.SelectMachines( TcSettings.NamePrefix );
            if( testMachinesCount > 0 )
            {
                machines.DeleteMachine();
            }

            machines.ResultColumn.ClearSearch();

            Assert.AreEqual( machineCount - testMachinesCount, machines.ResultColumn.Count );
        }

        /// <summary>
        /// Creates some test customers.
        /// </summary>
        [TestMethod]
        public void CreateTestCustomers()
        {
            var customers = HomeZoneApp.On<TcCustomers>();

            customers.NewCustomer(
                                  TcSettings.NamePrefix + "Kunde 1",
                                  null,
                                  "TRUMPF Allee 1",
                                  "71254",
                                  "Ditzingen",
                                  "Deutschland",
                                  "kein Kommentar" );

            customers.NewCustomer(
                                  TcSettings.NamePrefix + "Kunde 2",
                                  null,
                                  "TRUMPF Allee 2",
                                  "71254",
                                  "Ditzingen",
                                  "Deutschland",
                                  "hier auch nicht" );

            customers.NewCustomer(
                                  TcSettings.NamePrefix + "Kunde 3",
                                  null,
                                  "TRUMPF Allee 3",
                                  "71254",
                                  "Ditzingen",
                                  "Deutschland",
                                  "blablabla" );

            customers.ApplyClick();
            customers.CancelClick();
        }

        /// <summary>
        /// Deletes the test customers.
        /// </summary>
        [TestMethod]
        public void DeleteTestCustomers()
        {
            var customers = HomeZoneApp.Goto<TcCustomers>();

            customers.DeleteCustomersWithNameContaining( TcSettings.NamePrefix );

            customers.ApplyClick();
            customers.CancelClick();
        }

        /// <summary>
        /// Creates some test parts: adding a bend and a cut solution and boosting.
        /// Needs test machines and customers to be present.
        /// </summary>
        [TestMethod]
        public void CreateTestParts()
        {
            var parts = HomeZoneApp.Goto<TcParts>();
            var partCount = parts.ResultColumn.Count;

            parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc" );
            parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
            parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );
            parts.SingleDetail.Name = TcSettings.NamePrefix + parts.SingleDetail.Name;
            parts.SingleDetail.Customer = TcSettings.NamePrefix + "Kunde 1";
            parts.SingleDetail.DrawingNumber = TcSettings.NamePrefix + "DrawNr";
            parts.SingleDetail.DrawingVersion = "V08.15-007";
            parts.SingleDetail.ExternalName = TcSettings.NamePrefix + "ExtName";
            parts.SingleDetail.Note = TcSettings.NamePrefix + "Note";
            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailCutSolutions.New();
            Assert.IsTrue( parts.Toolbar.SaveButton.Enabled );
            parts.SavePart();
            Assert.IsFalse( parts.Toolbar.SaveButton.Enabled );
            OpenFluxBendSolutionAndCloseFlux( parts );
            Assert.IsTrue( parts.Toolbar.BoostButton.Enabled );
            parts.BoostPart();
            parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

            parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo" );
            parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
            parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );
            parts.SingleDetail.Name = TcSettings.NamePrefix + parts.SingleDetail.Name;
            parts.SingleDetail.Customer = TcSettings.NamePrefix + "Kunde 2";
            parts.SingleDetail.DrawingNumber = TcSettings.NamePrefix + "DrawNr";
            parts.SingleDetail.DrawingVersion = "V08.15-007";
            parts.SingleDetail.ExternalName = TcSettings.NamePrefix + "ExtName";
            parts.SingleDetail.Note = TcSettings.NamePrefix + "Note";
            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailCutSolutions.New();
            Assert.IsTrue( parts.Toolbar.SaveButton.Enabled );
            parts.SavePart();
            Assert.IsFalse( parts.Toolbar.SaveButton.Enabled );
            OpenFluxBendSolutionAndCloseFlux( parts );
            Assert.IsTrue( parts.Toolbar.BoostButton.Enabled );
            parts.BoostPart();
            parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

            parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Zugwinkel.scdoc" );
            parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
            parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );
            parts.SingleDetail.Name = TcSettings.NamePrefix + parts.SingleDetail.Name;
            parts.SingleDetail.Customer = TcSettings.NamePrefix + "Kunde 3";
            parts.SingleDetail.DrawingNumber = TcSettings.NamePrefix + "DrawNr";
            parts.SingleDetail.DrawingVersion = "V08.15-007";
            parts.SingleDetail.ExternalName = TcSettings.NamePrefix + "ExtName";
            parts.SingleDetail.Note = TcSettings.NamePrefix + "Note";
            parts.SingleDetailBendSolutions.New();
            parts.SingleDetailCutSolutions.New();
            Assert.IsTrue( parts.Toolbar.SaveButton.Enabled );
            parts.SavePart();
            Assert.IsFalse( parts.Toolbar.SaveButton.Enabled );
            OpenFluxBendSolutionAndCloseFlux( parts );
            Assert.IsTrue( parts.Toolbar.BoostButton.Enabled );
            parts.BoostPart();
            parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

            Assert.AreEqual( partCount + 3, parts.ResultColumn.Count );
        }

        private bool OpenFluxBendSolutionAndCloseFlux( TcParts parts )
        {
            parts.SingleDetailBendSolutions.OpenBendSolution( "Bend1" );
            parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );

            var flux = new TcFlux( Driver );
            var visible = flux.MainWindowVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) );

            if( visible )
            {
                flux.CloseApp();

                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
            }

            Assert.IsTrue( visible );

            return true;
        }

        /// <summary>
        /// Deletes the test parts.
        /// </summary>
        [TestMethod]
        public void DeleteTestParts()
        {
            var parts = HomeZoneApp.Goto<TcParts>();
            var partCount = parts.ResultColumn.Count;

            var testPartsCount = parts.SelectParts( TcSettings.NamePrefix );
            if( testPartsCount > 0 )
            {
                parts.DeletePart();
            }

            parts.ResultColumn.ClearSearch();

            Assert.AreEqual( partCount - testPartsCount, parts.ResultColumn.Count );
        }

        /// <summary>
        /// Creates some test part orders.
        /// </summary>
        [TestMethod]
        public void CreateTestPartOrders()
        {
            var partOrders = HomeZoneApp.Goto<TcPartOrders>();

            partOrders.NewPartOrder();
            //TODO
            partOrders.DeletePartOrder();
        }

        /// <summary>
        /// Deletes the test part orders.
        /// </summary>
        [TestMethod]
        public void DeleteTestPartOrders()
        {
            //TODO
        }

        /// <summary>
        /// Creates some test cut jobs.
        /// </summary>
        [TestMethod]
        public void CreateTestCutJobs()
        {
            var cutJobs = HomeZoneApp.Goto<TcCutJobs>();

            cutJobs.NewCutJob();
            //TODO
            cutJobs.DeleteCutJob();
        }

        /// <summary>
        /// Deletes the test cut jobs.
        /// </summary>
        [TestMethod]
        public void DeleteTestCutJobs()
        {
            //TODO
        }

        private static void CreateTestCutJobsFromParts()
        {
            //CreateTestParts(); //tut nicht ganz
            var parts = HomeZoneApp.Goto<TcParts>();

            parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Training\Laser\GEO\BL_01.geo" );
            parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Training\Laser\GEO\BL_02.geo" );
            parts.Import( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Training\Laser\GEO\BL_03.geo" );
            parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
            parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );

            parts.SelectAll();
            parts.CreateCutJob();
        }

        [TestMethod]
        public void BoostCutJob()
        {
            //CreateTestCutJobsFromParts();

            var cutJobs = HomeZoneApp.Goto<TcCutJobs>();
            //cutJobs.SelectCutJob("N1");

            // Details
            var rawMaterial = cutJobs.SingleDetail.RawMaterial;
            if( rawMaterial == "(Kein Rohmaterial)" )
            {
                cutJobs.SingleDetail.SelectRawMaterial( 1 );
            }

            // Auftragsliste
            var partOrdersCount = cutJobs.ContainedOrders.PartOrdersCount;
            cutJobs.ContainedOrders.UnSelectAllPartOrders();
            cutJobs.ContainedOrders.SelectPartOrder( 1 );
            cutJobs.ContainedOrders.RemovePartOrder();
            //cutJobs.CutJobContainedOrders.AddPartOrder();

            //Tafelprogramm
            cutJobs.CutJobSolution.Note = "Kommentar";
            cutJobs.CutJobSolution.SelectMachine( 1 );
            //cutJobs.CutJobSolution.SelectRawSheet( 1 );
            cutJobs.CutJobSolution.DeleteProgram();
            cutJobs.CutJobSolution.Boost();

            //TODO
            //cutJobs.DeleteCutJobs();
            //partsOrder.DeletePartOder();
            //parts.DeletePart();
        }

        /// <summary>
        /// Creates the test items.
        /// </summary>
        [TestMethod]
        public void CreateTestItems()
        {
            var smokeHelpers = new TcSmokeHelpers();

            smokeHelpers.CreateTestMaterials();
            smokeHelpers.CreateTestMachines();
            smokeHelpers.CreateTestCustomers();
            smokeHelpers.CreateTestParts();
            smokeHelpers.CreateTestPartOrders();
            smokeHelpers.CreateTestCutJobs();
        }

        /// <summary>
        /// Deletes the test items.
        /// </summary>
        [TestMethod]
        public void DeleteTestItems()
        {
            var smokeHelpers = new TcSmokeHelpers();

            smokeHelpers.DeleteTestCutJobs();
            smokeHelpers.DeleteTestPartOrders();
            smokeHelpers.DeleteTestParts();
            smokeHelpers.DeleteTestCustomers();
            smokeHelpers.DeleteTestMachines();
            smokeHelpers.DeleteTestMaterials();
        }
    }
}
