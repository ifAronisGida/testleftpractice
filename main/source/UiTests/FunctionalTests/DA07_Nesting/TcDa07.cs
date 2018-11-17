using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using HomeZone.UiTests.Base;

namespace HomeZone.UiTests.FunctionalTests.DA07_Nesting
{
    /// <summary>
    /// DA07 Nesting functional tests
    /// </summary>
    /// <seealso cref="UiTests.Base.TcBaseTestClass" />
    [TestClass]
    public class TcDa07 : TcBaseTestClass
    {
        /// <summary>
        /// Create a new job.
        /// </summary>
        [TestMethod, UniqueName( "B918A345-6CAC-47A8-BB2E-6AD370131D21" )]
        [Tag( "Functional Test" )]
        [Tag( "DA07" )]
        public void DA7_01()
        {
            var cutJobs = HomeZone.CutJobs;

            // Category "Nesting" is active.
            cutJobs.Goto();

            // Test step: create a new Nesting via toolbar "New Nesting".
            var cutJobCount = cutJobs.ResultColumn.Count;
            cutJobs.Toolbar.New();

            // Expected results:

            // An empty entry appears at the top of the result list.
            Assert.AreEqual( cutJobCount + 1, cutJobs.ResultColumn.Count );
            var selectedItem = cutJobs.ResultColumn.SelectedItem();
            Assert.AreNotEqual( null, selectedItem );
            Assert.IsTrue( string.IsNullOrEmpty( selectedItem.Id ) );
            Assert.IsTrue( string.IsNullOrEmpty( selectedItem.FinishDate ) );

            // An empty Job appears in the detail area.
            Assert.IsTrue( string.IsNullOrEmpty( cutJobs.BaseInfo.Id.Value ) );
            Assert.AreEqual( null, cutJobs.BaseInfo.FinishDate.Value );

            // Save button is enabled.
            Assert.IsTrue( cutJobs.Toolbar.CanSave );

            // There are no contained orders.
            Assert.AreEqual( 0, cutJobs.ContainedOrders.PartOrdersCount );

            // All Sheet Program fields are empty except Nesting Mode
            //TODO
            //cutJobs.SheetProgram.

            // No machine is selected ( except if there is only 1 machine available, then this should be selected V2.0X)
            //TODO

            // ID field is focused
            //TODO
            //Assert.IsTrue( cutJobs.BaseInfo.Id.IsFocused );

            // Sheet Program Open button is disabled
            Assert.IsFalse( cutJobs.SheetProgram.CanOpen );

            // Sheet Program BOOST button is disabled
            Assert.IsFalse( cutJobs.SheetProgram.CanBoost );

            // Order List state is MISSING
            //TODO

            // Sheet Program state is MISSING
            //TODO


            // Test step: Enter a unique job name (ID).
            //TODO


            // The name appears in the result list.
            //TODO


            // Save button is enabled.
            Assert.IsTrue( cutJobs.Toolbar.CanSave );


            // Test step: Add an order that has a material and machine assigned.
            //TODO



            // The selected order appears in the "Order List".
            //TODO

            // Column "Cutting program" contains the name of the cutting program assigned to the part order.
            //TODO

            // Save button still is enabled.
            Assert.IsTrue( cutJobs.Toolbar.CanSave );

            // Open button is enabled.
            Assert.IsTrue( cutJobs.SheetProgram.CanOpen );

            // "BOOST" is disabled.
            Assert.IsFalse( cutJobs.SheetProgram.CanBoost );

            // The part state (Order List column Status) shows the state of the cut solution

            // Order List state is same as the state of the single part in the list

            // "Pending" shows 0/n.

            // "Min/Max quantity (job)"  both show the target quantity of the PO.

            // "Current" shows 0.

            // "ID" and tooltip shows the ID of the Order.

            // "Customer" shows the customer of the Order.

            // "Finish date" shows finish date of the Order.

            // Earliest Finish date in "NESTING"  area shows the Finish date of the Order.

            // "Raw Material" in "NESTING" area shows the data of the selected Part from the Order.

            // "Machine" in "Sheet Program" area shows the data of the selected Part from the Order.

            // State in result list is "Order List: Incomplete".

            // Second state in stack is "Sheet Program: Incomplete".


            // Test step: Save
            cutJobs.Toolbar.Save();

            // Job saved successfully.
            Assert.IsFalse( cutJobs.Toolbar.CanSave );
        }

        /// <summary>
        /// Edit quantities.
        /// </summary>
        [TestMethod, UniqueName( "0BCAB5A4-E734-4EFC-A4F9-33BE6E37A1B7" )]
        [Tag( "Functional Test" )]
        [Tag( "DA07" )]
        public void DA7_02()
        {
            var cutJobs = HomeZone.CutJobs;

            // Category "NESTING" is active.
            cutJobs.Goto();

            //Nesting from DA7.01 is selected.
            //TODO

        }
    }
}
