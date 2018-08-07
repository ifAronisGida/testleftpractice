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

            materials.SelectMaterial( "1.0038" );

            materials.DuplicateMaterial();

            var name = TcSettings.NamePrefix + materials.Detail.Id;
            materials.Detail.Id = name;
            materials.Detail.Name = name;

            materials.SaveMaterial();
            materials.WaitForDetailOverlayAppear( TcSettings.MaterialSaveOverlayAppearTimeout );
            materials.WaitForDetailOverlayDisappear( TcSettings.MaterialSaveOverlayDisappearTimeout );

            materials.SelectMaterial( "Cu" );

            materials.DuplicateMaterial();

            name = TcSettings.NamePrefix + materials.Detail.Id;
            materials.Detail.Id = name;
            materials.Detail.Name = name;

            materials.SaveMaterial();
            materials.WaitForDetailOverlayAppear( TcSettings.MaterialSaveOverlayAppearTimeout );
            materials.WaitForDetailOverlayDisappear( TcSettings.MaterialSaveOverlayDisappearTimeout );

            materials.SelectMaterial( "Ti" );

            materials.DuplicateMaterial();

            name = TcSettings.NamePrefix + materials.Detail.Id;
            materials.Detail.Id = name;
            materials.Detail.Name = name;

            materials.SaveMaterial();
            materials.WaitForDetailOverlayAppear( TcSettings.MaterialSaveOverlayAppearTimeout );
            materials.WaitForDetailOverlayDisappear( TcSettings.MaterialSaveOverlayDisappearTimeout );
        }

        /// <summary>
        /// Deletes the test materials.
        /// </summary>
        [TestMethod]
        public void DeleteTestMaterials()
        {
            var materials = HomeZoneApp.Goto<TcMaterials>();

            if( materials.SelectMaterials( TcSettings.NamePrefix ) > 0 )
            {
                materials.DeleteMaterial();
            }

            materials.WaitForDetailOverlayAppear( TcSettings.MaterialSaveOverlayAppearTimeout );
            materials.WaitForDetailOverlayDisappear( TcSettings.MaterialSaveOverlayDisappearTimeout );

            materials.ResultColumn.ClearSearch();
        }

        /// <summary>
        /// Creates some bend and cut test machines.
        /// </summary>
        [TestMethod]
        public void CreateTestMachines()
        {
            var machines = HomeZoneApp.Goto<TcMachines>();

            machines.NewBendMachine( "TruBend 5320 (6-axes) B23", TcSettings.NamePrefix + Guid.NewGuid() );
            machines.SaveMachine();

            machines.WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );

            machines.NewBendMachine( "TruBend 1066 (4-axes,Trumpf_80mm) B22", TcSettings.NamePrefix + Guid.NewGuid() );
            machines.SaveMachine();

            machines.WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );

            machines.NewCutMachine( "TruLaser 3030 (L20)", TcSettings.NamePrefix + Guid.NewGuid(), 3 );
            machines.SaveMachine();

            machines.WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );

            machines.NewCutMachine( "TruLaser Center 7030 (L26)", TcSettings.NamePrefix + Guid.NewGuid(), 0 );
            machines.SaveMachine();

            machines.WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );

            machines.NewCutMachine( "TruLaser 3060 (L66)", TcSettings.NamePrefix + Guid.NewGuid(), "8000" );
            machines.SaveMachine();

            machines.WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );
        }

        /// <summary>
        /// Deletes the test machines.
        /// </summary>
        [TestMethod]
        public void DeleteTestMachines()
        {
            var machines = HomeZoneApp.Goto<TcMachines>();

            if( machines.SelectMachines( TcSettings.NamePrefix ) > 0 )
            {
                machines.DeleteMachine();
            }

            machines.ResultColumn.ClearSearch();
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
        /// </summary>
        [TestMethod]
        public void CreateTestParts()
        {
            var parts = HomeZoneApp.Goto<TcParts>();

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
            OpenFluxBendSolutionAndCloseFlux( parts );
            parts.SavePart();
            parts.BoostPart();

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
            OpenFluxBendSolutionAndCloseFlux( parts );
            parts.SavePart();
            parts.BoostPart();

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
            OpenFluxBendSolutionAndCloseFlux( parts );
            parts.SavePart();
            parts.BoostPart();
        }

        private bool OpenFluxBendSolutionAndCloseFlux( TcParts parts )
        {
            parts.SingleDetailBendSolutions.OpenBendSolution( "Bend1" );
            parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );

            var flux = new TcFlux( Driver );

            if( flux.MainWindowVisible( TcSettings.FluxStartTimeout, TimeSpan.FromMilliseconds( 500 ) ) )
            {
                flux.CloseApp();

                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
            }
            else
            {
                Driver.Log.Error( @"Flux main window is not visible." );
                return false;
            }

            return true;
        }

        /// <summary>
        /// Deletes the test parts.
        /// </summary>
        [TestMethod]
        public void DeleteTestParts()
        {
            var parts = HomeZoneApp.Goto<TcParts>();

            if( parts.SelectParts( TcSettings.NamePrefix ) > 0 )
            {
                parts.DeletePart();
            }

            parts.ResultColumn.ClearSearch();
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

        private void CreateTestCutJobsFromParts()
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
    }
}
