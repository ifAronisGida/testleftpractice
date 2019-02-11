using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiObjects.PageObjects.Part;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Trumpf.AutoTest.Facts;
using Trumpf.Coparoo.Desktop.Waiting;
using UiCommonFunctions.Utilities;

namespace HomeZone.UiObjectsTests.Utilities
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
        [TestMethod, UniqueName( "B7FF4E45-01F3-4BED-921F-D1CF480AD0C9" )]
        public void CreateTestMaterials()
        {
            var materials = HomeZone.GotoMaterials();
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

                Wait.ActAndWaitForChange( materials.Toolbar.Duplicate, () => materials.ResultColumn.Count );

                var name = Name2UIT_Name( materials.Detail.Id.Value );
                materials.Detail.Id.Value = name;
                materials.Detail.Name.Value = name;

                Assert.IsTrue( materials.Toolbar.CanSave );
                materials.Toolbar.Save();
                materials.WaitForDetailOverlayAppear( TestSettings.MaterialOverlayAppearTimeout );
                materials.WaitForDetailOverlayDisappear( TestSettings.MaterialOverlayDisappearTimeout );
                Assert.IsFalse( materials.Toolbar.CanSave );
                return true;
            }
        }

        /// <summary>
        /// Deletes the test materials.
        /// </summary>
        [TestMethod, UniqueName( "BE80E7E6-D3E0-466D-A1BB-258EE54BF188" )]
        public void DeleteTestMaterials()
        {
            var materials = HomeZone.GotoMaterials();
            var currentMaterialsCount = materials.ResultColumn.Count;
            var deletedMaterialsCount = 0;

            foreach( var material in mMaterialNames )
            {
                if( materials.DeleteMaterial( Name2UIT_Name( material ) ) )
                {
                    materials.WaitForDetailOverlayAppear( TestSettings.MaterialOverlayAppearTimeout );
                    materials.WaitForDetailOverlayDisappear( TestSettings.MaterialOverlayDisappearTimeout );
                    deletedMaterialsCount++;
                }
            }

            materials.ResultColumn.ClearSearch();
            Assert.AreEqual( currentMaterialsCount - deletedMaterialsCount, materials.ResultColumn.Count );
        }

        /// <summary>
        /// Creates some bend and cut test machines.
        /// </summary>
        [TestMethod, UniqueName( "2F659CB3-F9E1-4C23-80A2-5D9984878D5C" )]
        public void CreateTestMachines()
        {
            var machines = HomeZone.GotoMachines();

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
                Assert.IsTrue( machines.Toolbar.CanSave );
                machines.Toolbar.Save();
                Assert.IsFalse( machines.Toolbar.CanSave );

                machines.WaitForDetailOverlayDisappear( TestSettings.SavingTimeout );
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
                Assert.IsTrue( machines.Toolbar.CanSave );
                machines.Toolbar.Save();
                Assert.IsFalse( machines.Toolbar.CanSave );

                machines.WaitForDetailOverlayDisappear( TestSettings.SavingTimeout );
                machinesCreatedCount++;
            }

            machines.ResultColumn.ClearSearch();

            Assert.AreEqual( machineCount + machinesCreatedCount, machines.ResultColumn.Count );
            mTestMachinesCreated = true;
        }

        /// <summary>
        /// Deletes the test machines.
        /// </summary>
        [TestMethod, UniqueName( "5548C38A-0B90-4FD3-ACDC-B325B05B99A8" )]
        public void DeleteTestMachines()
        {
            var machines = HomeZone.GotoMachines();
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
        [TestMethod, UniqueName( "1A7DB08C-B1F9-44EF-8DD8-A4805B140E1F" )]
        public void CreateTestCustomers()
        {
            var customers = HomeZone.GotoCustomers();
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
        [TestMethod, UniqueName( "51909558-AB5D-48F0-8A67-CF60458DBC5D" )]
        public void DeleteTestCustomers()
        {
            var customers = HomeZone.GotoCustomers();
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
        [TestMethod, UniqueName( "2A2DDFB4-4AA0-4CFC-A234-774609B8BFBF" )]
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

            var parts = HomeZone.GotoParts();
            var partCount = parts.ResultColumn.Count;
            var partsCreatedCount = 0;

            for( int i = 0; i < mPartNames.Count; i++ )
            {
                if( parts.ResultColumn.SelectItem( Name2UIT_Name( Path.GetFileNameWithoutExtension( mPartNames[ i ].Name ) ) ) )
                {
                    continue;   // part already exists
                }

                parts.Toolbar.Import( mPartNames[ i ].FullName );
                parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );
                parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );
                parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 10 ) );
                parts.SingleDetail.Name.Value = TestSettings.NamePrefix + parts.SingleDetail.Name.Value;
                parts.SingleDetail.Id = parts.SingleDetail.Name.Value;
                parts.SingleDetail.Customer = Name2UIT_Name( mCustomerNames[ i ] );
                parts.SingleDetail.DrawingNumber.Value = TestSettings.NamePrefix + "DrawNr";
                parts.SingleDetail.DrawingVersion.Value = "V08.15-007";
                parts.SingleDetail.ExternalName.Value = TestSettings.NamePrefix + "ExtName";
                parts.SingleDetail.Note.Value = TestSettings.NamePrefix + "Note";
                parts.SingleDetailBendSolutions.New();
                parts.SingleDetailCutSolutions.New();
                Assert.IsTrue( parts.Toolbar.CanSave );
                parts.Toolbar.Save();
                Assert.IsFalse( parts.Toolbar.CanSave );
                partsCreatedCount++;
            }

            parts.ResultColumn.ClearSearch();

            Assert.AreEqual( partCount + partsCreatedCount, parts.ResultColumn.Count );
        }

        private bool OpenFluxBendSolutionAndCloseFlux( TcParts parts )
        {
            parts.SingleDetailBendSolutions.OpenBendSolution( "Bend1" );
            parts.WaitForDetailOverlayAppear( TestSettings.PartOverlayAppearTimeout );

            var flux = FluxApp;
            var visible = flux.IsMainWindowVisible( TestSettings.FluxBoostAndStartTimeout, TimeSpan.FromMilliseconds( 500 ) );

            if( visible )
            {
                flux.CloseApp();

                parts.WaitForDetailOverlayDisappear( TestSettings.PartOverlayDisappearTimeout );
            }

            Assert.IsTrue( visible );

            return true;
        }

        /// <summary>
        /// Deletes the test parts.
        /// </summary>
        [TestMethod, UniqueName( "3D759D38-F6CD-44DE-92E5-FD5FA5E587FD" )]
        public void DeleteTestParts()
        {
            var parts = HomeZone.GotoParts();
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
        [TestMethod, UniqueName( "620C3D83-9CE7-4B28-BCEF-5665FADC1E78" )]
        public void CreateTestPartOrders()
        {
            var partOrders = HomeZone.GotoPartOrders();

            partOrders.Toolbar.New();
            //TODO
            partOrders.Toolbar.Delete();
        }

        /// <summary>
        /// Deletes the test part orders.
        /// </summary>
        [TestMethod, UniqueName( "06EA8653-D88C-4605-8C21-72EC3366EB99" )]
        public void DeleteTestPartOrders()
        {
            //TODO

        }

        /// <summary>
        /// Creates some test cut jobs.
        /// </summary>
        [TestMethod, UniqueName( "D07C2E9E-E864-4F90-AE22-015551F9C768" )]
        public void CreateTestCutJobs()
        {
            var cutJobs = HomeZone.GotoCutJobs();

            cutJobs.Toolbar.New();
            //TODO
            cutJobs.Toolbar.Delete();
        }

        /// <summary>
        /// Deletes the test cut jobs.
        /// </summary>
        [TestMethod, UniqueName( "49524C47-CC25-41BA-A6DA-3230FE7B0A7B" )]
        public void DeleteTestCutJobs()
        {
            //TODO

        }

        /// <summary>
        /// Creates the test items.
        /// </summary>
        [TestMethod, UniqueName( "C515019F-E2AB-4DD7-8C1F-211A2E1ADBCF" )]
        public void DoCreateTestItems()
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
        [TestMethod, UniqueName( "D511E169-3EFB-437F-867F-0365F58939A3" )]
        public void DoDeleteTestItems()
        {
            var smokeHelpers = new TcSmokeHelpers();

            smokeHelpers.DeleteTestCutJobs();
            smokeHelpers.DeleteTestPartOrders();
            smokeHelpers.DeleteTestParts();
            smokeHelpers.DeleteTestCustomers();
            smokeHelpers.DeleteTestMachines();
            smokeHelpers.DeleteTestMaterials();
        }

        /// <summary>
        /// Creates the test items.
        /// </summary>
        [TestMethod, UniqueName( "34D1BC63-EF77-4B73-9A64-9E19C9D2D226" )]
        public void CreateTestItems()
        {
            Act( DoCreateTestItems );
        }

        /// <summary>
        /// Deletes the test items.
        /// </summary>
        [TestMethod, UniqueName( "BA224F20-1FF2-4307-90C4-3102CBD691B7" )]
        public void DeleteTestItems()
        {
            Act( DoDeleteTestItems );
        }

        private string Name2UIT_Name( string name )
        {
            return TestSettings.NamePrefix + name;
        }
    }
}
