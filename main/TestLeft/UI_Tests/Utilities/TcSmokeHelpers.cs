using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjectInterfaces.Customer;
using PageObjectInterfaces.Material;
using PageObjectInterfaces.Part;
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
        // test materials
        private readonly IList<string> mMaterialNames = new List<string>{ "1.0038", "Cu", "Ti" };

        // test machines
        private readonly IList<string> mBendMachineNames = new List<string>{ "TruBend 5320 (6-axes) B23", "TruBend 1066 (4-axes,Trumpf_80mm) B22" };
        private readonly IList<Tuple<string,string>> mCutMachineNames = new List<Tuple<string,string>>
        {
            new Tuple<string, string>(  "TruLaser 3030 (L20)", "5000"),
            new Tuple<string, string>(  "TruLaser Center 7030 (L26)","6000"),
            new Tuple<string, string>(  "TruLaser 3060 (L66)","8000")
        };
        private bool mTestMachinesCreated ;

        // test customers
        private readonly IList<string> mCustomerNames = new List<string>{"Testkunde1","Testkunde2","Testkunde3"};
        private bool mTestCustomersCreated;

        // test parts
        private readonly IList<FileInfo> mPartNames = new List<FileInfo>
        {
            new FileInfo( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc"),
            new FileInfo( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Demoteil.geo"),
            new FileInfo( @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Zugwinkel.scdoc")
        };

        /// <summary>
        /// Creates some test materials by duplicating existing materials
        /// </summary>
        [TestMethod]
        public void CreateTestMaterials()
        {
            var materials = HomeZoneApp.Goto<TiMaterials, TcMaterials>();
            var materialCount = materials.ResultColumn.Count;
            var materialsCreatedCount = 0;

            foreach( var material in mMaterialNames )
            {
                if( DuplicateAndSave( material ) )
                {
                    materialsCreatedCount++;
                }
            }

            materials.ResultColumn.ClearSearch();

            Assert.AreEqual( materialCount + materialsCreatedCount, materials.ResultColumn.Count );

            bool DuplicateAndSave( string materialId )
            {
                if( materials.ResultColumn.SelectItem( Name2UIT_Name( materialId ) ) )
                {
                    return false;     // material already exists
                }

                materials.ResultColumn.SelectItem( materialId );

                materials.DuplicateMaterial();

                var name = Name2UIT_Name( materials.Detail.Id.Value );
                materials.Detail.Id.Value = name;
                materials.Detail.Name.Value = name;

                Assert.IsTrue( materials.Toolbar.SaveButton.Enabled );
                materials.SaveMaterial();
                materials.WaitForDetailOverlayAppear( TcSettings.MaterialOverlayAppearTimeout );
                materials.WaitForDetailOverlayDisappear( TcSettings.MaterialOverlayDisappearTimeout );
                Assert.IsFalse( materials.Toolbar.SaveButton.Enabled );
                return true;
            }
        }

        /// <summary>
        /// Deletes the test materials.
        /// </summary>
        [TestMethod]
        public void DeleteTestMaterials()
        {
            var materials = HomeZoneApp.Goto<TiMaterials, TcMaterials>();
            var currentMaterialsCount = materials.ResultColumn.Count;
            var deletedMaterialsCount = 0;

            foreach( var material in mMaterialNames )
            {
                if( materials.DeleteMaterial( Name2UIT_Name( material ) ) )
                {
                    materials.WaitForDetailOverlayAppear( TcSettings.MaterialOverlayAppearTimeout );
                    materials.WaitForDetailOverlayDisappear( TcSettings.MaterialOverlayDisappearTimeout );
                    deletedMaterialsCount++;
                }
            }

            materials.ResultColumn.ClearSearch();
            Assert.AreEqual( currentMaterialsCount - deletedMaterialsCount, materials.ResultColumn.Count );
        }

        /// <summary>
        /// Creates some bend and cut test machines.
        /// </summary>
        [TestMethod]
        public void CreateTestMachines()
        {
            var machines = HomeZoneApp.Goto<TcMachines>();

            machines.ResultColumn.ClearSearch();

            var machineCount = machines.ResultColumn.Count;
            var machinesCreatedCount = 0;

            // create bend machines
            foreach( var bendMachineName in mBendMachineNames )
            {
                if( machines.ResultColumn.SelectItem( Name2UIT_Name( bendMachineName ) ) )
                {
                    continue;   // machine already exists
                }

                machines.NewBendMachine( bendMachineName, Name2UIT_Name( bendMachineName ) );
                Assert.IsTrue( machines.Toolbar.SaveButton.Enabled );
                machines.SaveMachine();
                Assert.IsFalse( machines.Toolbar.SaveButton.Enabled );

                machines.WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );
                machinesCreatedCount++;
            }

            // create cut machines
            foreach( var cutMachineName in mCutMachineNames )
            {
                if( machines.ResultColumn.SelectItem( Name2UIT_Name( cutMachineName.Item1 ) ) )
                {
                    continue;   // machine already exists
                }

                machines.NewCutMachine( cutMachineName.Item1, Name2UIT_Name( cutMachineName.Item1 ), cutMachineName.Item2 );
                Assert.IsTrue( machines.Toolbar.SaveButton.Enabled );
                machines.SaveMachine();
                Assert.IsFalse( machines.Toolbar.SaveButton.Enabled );

                machines.WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );
                machinesCreatedCount++;
            }

            machines.ResultColumn.ClearSearch();

            Assert.AreEqual( machineCount + machinesCreatedCount, machines.ResultColumn.Count );
            mTestMachinesCreated = true;
        }

        /// <summary>
        /// Deletes the test machines.
        /// </summary>
        [TestMethod]
        public void DeleteTestMachines()
        {
            var machines = HomeZoneApp.Goto<TcMachines>();
            var machineCount = machines.ResultColumn.Count;
            var deletedMachinesCount = 0;

            foreach( var bendMachineName in mBendMachineNames )
            {
                if( machines.DeleteMachine( Name2UIT_Name( bendMachineName ) ) )
                {
                    deletedMachinesCount++;
                }
            }

            foreach( var cutMachineName in mCutMachineNames )
            {
                if( machines.DeleteMachine( Name2UIT_Name( cutMachineName.Item1 ) ) )
                {
                    deletedMachinesCount++;
                }
            }

            machines.ResultColumn.ClearSearch();

            Assert.AreEqual( machineCount - deletedMachinesCount, machines.ResultColumn.Count );
            mTestMachinesCreated = false;
        }

        /// <summary>
        /// Creates some test customers.
        /// </summary>
        [TestMethod]
        public void CreateTestCustomers()
        {
            var customers = HomeZoneApp.Goto<TiCustomers, TcCustomers>();
            var customersCreatedCount = 0;
            var customersCount = customers.Count();
            if( string.IsNullOrEmpty( customers.Name.Value ) )
            {
                customersCount--;       // do not count empty entry
            }

            foreach( var customer in mCustomerNames )
            {
                if( customers.SelectCustomer( Name2UIT_Name( customer ) ) )
                {
                    continue;       // customer already exists
                }
                customers.NewCustomer(
                                      Name2UIT_Name( customer ),
                                      null,
                                      "TRUMPF Allee 1",
                                      "71254",
                                      "Ditzingen",
                                      "Deutschland",
                                      "kein Kommentar" );
                customersCreatedCount++;
            }

            customers.Apply();

            Assert.AreEqual( customersCount + customersCreatedCount, customers.Count() );

            customers.Cancel();
            mTestCustomersCreated = true;
        }

        /// <summary>
        /// Deletes the test customers.
        /// </summary>
        [TestMethod]
        public void DeleteTestCustomers()
        {
            var customers = HomeZoneApp.Goto<TiCustomers, TcCustomers>();
            var customersCount = customers.Count();
            var deletedCustomersCount = 0;

            foreach( var customer in mCustomerNames )
            {
                if( customers.DeleteCustomer( Name2UIT_Name( customer ) ) )
                {
                    deletedCustomersCount++;
                }
            }

            customers.Apply();
            Assert.AreEqual( customersCount - deletedCustomersCount, customers.Count() );

            customers.Cancel();
            mTestCustomersCreated = false;
        }

        /// <summary>
        /// Creates some test parts: adding a bend and a cut solution and boosting.
        /// Needs test machines and customers to be present.
        /// </summary>
        [TestMethod]
        public void CreateTestParts()
        {
            if( !mTestMachinesCreated )
            {
                CreateTestMachines();
            }

            if( !mTestCustomersCreated )
            {
                CreateTestCustomers();
            }

            var parts = HomeZoneApp.Goto<TiParts, TcParts>();
            var partCount = parts.ResultColumn.Count;
            var partsCreatedCount = 0;

            for( int i = 0; i < mPartNames.Count; i++ )
            {
                if( parts.ResultColumn.SelectItem( Name2UIT_Name( Path.GetFileNameWithoutExtension( mPartNames[ i ].Name ) ) ) )
                {
                    continue;   // part already exists
                }

                parts.Import( mPartNames[ i ].FullName );
                parts.WaitForDetailOverlayAppear( TcSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TcSettings.PartOverlayDisappearTimeout );
                parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );
                parts.SingleDetail.Name.Value = TcSettings.NamePrefix + parts.SingleDetail.Name.Value;
                parts.SingleDetail.Id = parts.SingleDetail.Name.Value;
                parts.SingleDetail.Customer = Name2UIT_Name( mCustomerNames[ i ] );
                parts.SingleDetail.DrawingNumber.Value = TcSettings.NamePrefix + "DrawNr";
                parts.SingleDetail.DrawingVersion.Value = "V08.15-007";
                parts.SingleDetail.ExternalName.Value = TcSettings.NamePrefix + "ExtName";
                parts.SingleDetail.Note.Value = TcSettings.NamePrefix + "Note";
                parts.SingleDetailBendSolutions.New();
                parts.SingleDetailCutSolutions.New();
                Assert.IsTrue( parts.Toolbar.SaveButton.Enabled );
                parts.SavePart();
                Assert.IsFalse( parts.Toolbar.SaveButton.Enabled );
                partsCreatedCount++;
            }

            parts.ResultColumn.ClearSearch();

            Assert.AreEqual( partCount + partsCreatedCount, parts.ResultColumn.Count );
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
            var deletedPartsCount = 0;

            for( int i = 0; i < mPartNames.Count; i++ )
            {
                var partName = Path.GetFileNameWithoutExtension( mPartNames[ i ].Name );
                if( parts.DeletePart( Name2UIT_Name( partName ) ) )
                {
                    deletedPartsCount++;
                }
            }

            parts.ResultColumn.ClearSearch();

            Assert.AreEqual( partCount - deletedPartsCount, parts.ResultColumn.Count );
        }

        /// <summary>
        /// Creates some test part orders.
        /// </summary>
        [TestMethod]
        public void CreateTestPartOrders()
        {
            var partOrders = HomeZoneApp.Goto<TcPartOrders>();

            partOrders.Toolbar.New();
            //TODO
            partOrders.Toolbar.Delete();
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

        private string Name2UIT_Name( string name )
        {
            return TcSettings.NamePrefix + name;
        }
    }
}
