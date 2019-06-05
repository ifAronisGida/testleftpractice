using HomeZone.UiCommonFunctions.Base;
using HomeZone.UiObjectTests.Assertions;
using HomeZone.UiObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trumpf.AutoTest.Facts;
using Trumpf.Coparoo.Desktop.Waiting;
using static HomeZone.UiObjectsTests.Utilities.TcResultListItems;

namespace HomeZone.UiObjectsTests.FunctionalTests.DA07_Nesting
{
    /// <summary>
    /// DA07 Nesting functional tests
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcDa07 : TcBaseTestClass
    {
        // cut machines
        private const string CUT_JOB1_TYPE = @"TruLaser 3030 (L20)";
        private const string CUT_JOB2_TYPE = @"TruLaser Center 7030 (L26)";

        // part
        private const string PART = @"C:\Users\Public\Documents\TRUMPF\TruTops\Samples\Showcase\Eckwinkel.scdoc";
        private const string CUTTING_PROGRAM_NAME = @"Cut1";

        private readonly string mId = @"DA7_01";

        /// <summary>
        /// Create a new job.
        /// </summary>
        [TestMethod, UniqueName( "B918A345-6CAC-47A8-BB2E-6AD370131D21" )]
        [Tag( "Functional Test" )]
        [Tag( "DA07" )]
        public void DA7_01()
        {
            CreatePreConditions();

            var missing = TcAppLangDependentStrings.Missing;
            var cuttingProgram = TcAppLangDependentStrings.CuttingProgram;
            //var incomplete = TcAppLangDependentStrings.Incomplete;

            Log.Info( "Create nesting" );

            var cutJobs = HomeZone.CutJobs;

            // Category "Nesting" is active.
            cutJobs.Goto();

            // Test step: create a new Nesting via toolbar "New Nesting".
            var cutJobCount = cutJobs.ResultColumn.Count;
            cutJobs.Toolbar.New();

            Log.Info( "Check initial values" );

            // Expected results:

            // An empty entry appears at the top of the result list.
            Assert.AreEqual( cutJobCount + 1, cutJobs.ResultColumn.Count );
            var selectedItem = cutJobs.ResultColumn.SelectedItem();
            Assert.IsNotNull( selectedItem, "Nothing selected" );
            Assert.IsTrue( string.IsNullOrEmpty( selectedItem.Id ), "selectedItem.Id is not empty" );
            Assert.IsTrue( string.IsNullOrEmpty( selectedItem.FinishDate ), "selectedItem.FinishDate is not empty" );

            // An empty Job appears in the detail area.
            Assert.IsTrue( string.IsNullOrEmpty( cutJobs.BaseInfo.Id.Value ) );
            Assert.AreEqual( null, cutJobs.BaseInfo.FinishDate );

            // Save button is enabled.
            cutJobs.Toolbar.SaveShouldBeEnabled();

            // There are no contained orders.
            Assert.AreEqual( 0, cutJobs.ContainedOrders.PartOrdersCount, "There should be no contained orders" );

            // All Sheet Program fields are empty except Nesting Mode
            //TODO
            //cutJobs.SheetProgram.

            // No machine is selected ( except if there is only 1 machine available, then this should be selected V2.0X).
            // We have created 2 machines.
            Assert.IsTrue( string.IsNullOrEmpty( cutJobs.SheetProgram.Machine.Value ), "string.IsNullOrEmpty( cutJobs.SheetProgram.Machine.Value ) should be true" );

            // ID field is focused
            Assert.IsTrue( cutJobs.BaseInfo.Id.IsFocused, "ID field is not focused" );

            // Sheet Program Open button is disabled
            Assert.IsFalse( cutJobs.SheetProgram.CanOpen, "Sheet Program Open button is not disabled" );

            // Sheet Program BOOST button is disabled
            Assert.IsFalse( cutJobs.SheetProgram.CanBoost, "Sheet Program BOOST button is not disabled" );

            // Order List state is MISSING
            Assert.AreEqual( missing, cutJobs.ContainedOrders.StateToolTip, "Order List state is not MISSING" );

            // Sheet Program state is MISSING
            Assert.AreEqual( missing, cutJobs.SheetProgram.StateToolTip, "Sheet Program state is not MISSING" );

            Log.Info( "Enter job name" );

            // Test step: Enter a unique job name (ID).
            cutJobs.BaseInfo.Id.Value = Name2UIT_Name( mId );

            Log.Info( "Check name in result list" );

            // The name appears in the result list.
            Assert.AreEqual( Name2UIT_Name( mId ), cutJobs.ResultColumn.SelectedItem().Id, "The name appears not in the result list." );

            Log.Info( "Check save button" );

            // Save button is enabled.
            cutJobs.Toolbar.SaveShouldBeEnabled();


            Log.Info( "Add an order that has a material and machine assigned." );

            // Test step: Add an order that has a material and machine assigned.
            var orderCount = cutJobs.ContainedOrders.PartOrdersCount;
            cutJobs.ContainedOrders.AddPartOrder( Name2UIT_Name( mId ) );
            cutJobs.WaitForDetailOverlayDisappear();

            Log.Info( "Check if the selected order appears in the 'Order List'" );
            // The selected order appears in the "Order List".
            Assert.AreEqual( orderCount + 1, cutJobs.ContainedOrders.PartOrdersCount, "The selected order appears not in the 'Order List'." );

            Log.Info( "The column 'Cutting program' contains the name of the cutting program assigned to the part order." );
            var orderRow = cutJobs.ContainedOrders.GetRow( 0 );
            Assert.AreEqual( CUTTING_PROGRAM_NAME, orderRow.CuttingProgram );

            Log.Info( "Check save button is still enabled" );
            // Save button still is enabled.
            cutJobs.Toolbar.SaveShouldBeEnabled();

            Log.Info( "Check open button is enabled" );
            // Open button is enabled.
            Wait.For( () => cutJobs.SheetProgram.CanOpen );
            Assert.IsTrue( cutJobs.SheetProgram.CanOpen, "Open button is disabled" );

            Log.Info( "Check BOOST button is disabled" );
            // "BOOST" is disabled.
            Assert.IsFalse( cutJobs.SheetProgram.CanBoost, "BOOST button is enabled" );

            Log.Info( "The part state (Order List column Status) shows the state of the cut solution?" );
            Assert.AreEqual( cuttingProgram, orderRow.PartStateComponentToolTip );

            Log.Info( "Order List state is same as the state of the single part in the list?" );
            Assert.AreEqual( orderRow.PartStateToolTip, cutJobs.ContainedOrders.StateToolTip );

            Log.Info( "'Pending' shows 0." );
            Assert.AreEqual( 0, orderRow.Pending );

            Log.Info( "'Min/Max quantity (job)' both show the target quantity of the PO." );
            Assert.AreEqual( 1, orderRow.Min, "Min quantity is not 1" );
            Assert.AreEqual( 1, orderRow.Max, "Max quantity is not 1" );


            Log.Info( "'Current' shows 0." );
            Assert.AreEqual( 0, orderRow.Current, "'Current' is not 0." );

            // "ID" and tooltip shows the ID of the Order.
            //TODO

            Log.Info( "'Customer' shows the customer of the Order." );
            Assert.IsTrue( string.IsNullOrEmpty( orderRow.Customer ) );

            Log.Info( "'Finish date' shows finish date of the Order." );
            Assert.AreEqual( null, orderRow.TargetDate );

            Log.Info( "Earliest Finish date in 'NESTING' area shows the finish date of the Order." );
            Assert.AreEqual( null, cutJobs.BaseInfo.FinishDate );

            Log.Info( "'Raw Material' in 'NESTING' area shows the data of the selected Part from the Order." );
            Assert.AreEqual( @"ST0M0200---", cutJobs.BaseInfo.RawMaterial.Value );

            Log.Info( "'Machine' in 'Sheet Program' area shows the data of the selected Part from the Order." );
            Assert.AreEqual( @"UIT_TruLaser 3030 (L20)", cutJobs.SheetProgram.Machine.Value );

            Log.Info( "State in result list is 'Order List: Incomplete'." );
            var resultListItemStates = selectedItem.GetRawStates();
            Assert.AreEqual( IncompleteState, resultListItemStates[ OrderListComponent ] );

            Log.Info( "Second state in stack is 'Sheet Program: Incomplete'." );
            Assert.AreEqual( IncompleteState, resultListItemStates[ SheetProgramComponent ] );


            Log.Info( "Saving the nesting." );
            // Test step: Save
            cutJobs.Toolbar.Save();
            cutJobs.SheetProgram.WaitForDetailOverlayAppear();
            cutJobs.SheetProgram.WaitForDetailOverlayDisappear();

            // Job saved successfully.
            Log.Info( "Check save button is now disabled" );
            cutJobs.Toolbar.SaveShouldBeDisabled();

            CleanUp();

            Log.Info( "DA7_01 finished" );

        }

        ///// <summary>
        ///// Edit quantities.
        ///// </summary>
        //[TestMethod, UniqueName( "0BCAB5A4-E734-4EFC-A4F9-33BE6E37A1B7" )]
        //[Tag( "Functional Test" )]
        //[Tag( "DA07" )]
        //public void DA7_02()
        //{
        //    var cutJobs = HomeZone.CutJobs;

        //    // Category "NESTING" is active.
        //    cutJobs.Goto();

        //    //Nesting from DA7.01 is selected.
        //    //TODO

        //}

        /// <summary>
        /// Creates the pre conditions for DA07.01:
        ///     - min 2 cut machines
        ///     - order that has a material and machine assigned
        /// </summary>
        private void CreatePreConditions()
        {
            Log.OpenFolder( "CreatePreConditions" );

            // create cut machines
            Log.Info( "Create cut machines" );
            var machines = HomeZone.Machines;

            machines.NewCutMachine( CUT_JOB1_TYPE, Name2UIT_Name( CUT_JOB1_TYPE ), @"6000" );
            machines.Toolbar.Save();
            machines.TryWaitForDetailOverlayAppear( TestSettings.SavingTimeout );
            machines.WaitForDetailOverlayDisappear( TestSettings.SavingTimeout );
            machines.NewCutMachine( CUT_JOB2_TYPE, Name2UIT_Name( CUT_JOB2_TYPE ), @"6000" );
            machines.Toolbar.Save();

            // create part and part order
            Log.Info( "Import part" );
            var parts = HomeZone.Parts;
            parts.Goto();

            parts.Toolbar.Import( PART );

            parts.WaitForDetailOverlayAppear();
            parts.WaitForDetailOverlayDisappear();
            parts.SingleDetail.WaitForNameEnabled( TimeSpan.FromSeconds( 30 ) );

            parts.SingleDetail.Name.Value = Name2UIT_Name( mId );
            parts.SingleDetail.Id = Name2UIT_Name( mId );
            parts.SingleDetailCutSolutions.New();

            Log.Info( "Create part order" );

            parts.Toolbar.CreatePartOrder();
            parts.WaitForDetailOverlayAppear();
            parts.WaitForDetailOverlayDisappear();

            var partOrders = HomeZone.PartOrders;
            partOrders.BaseInfo.ID.Value = Name2UIT_Name( mId );
            partOrders.Toolbar.Save();
            partOrders.WaitForDetailOverlayAppear();
            partOrders.WaitForDetailOverlayDisappear();

            Log.CloseFolder();
        }

        private void CleanUp()
        {
            Log.OpenFolder( "CleanUp." );

            Log.Info( "Delete cut job" );
            var cutJobs = HomeZone.CutJobs;
            cutJobs.DeleteCutJob( Name2UIT_Name( mId ) );

            Log.Info( "Delete part order" );
            var partOrders = HomeZone.PartOrders;
            partOrders.Goto();
            partOrders.DeletePartOrder( Name2UIT_Name( mId ) );

            Log.Info( "Delete part" );
            var parts = HomeZone.Parts;
            parts.Goto();
            parts.DeletePart( Name2UIT_Name( mId ) );

            Log.Info( "Delete machines" );
            var machines = HomeZone.Machines;
            machines.Goto();
            machines.DeleteMachine( Name2UIT_Name( CUT_JOB1_TYPE ) );
            machines.DeleteMachine( Name2UIT_Name( CUT_JOB2_TYPE ) );

            Log.CloseFolder();
        }

        private string Name2UIT_Name( string name )
        {
            return TestSettings.NamePrefix + name;
        }

    }
}
