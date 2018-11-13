using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using UiTests.Base;

namespace UiTests.FunctionalTests.DA07_Nesting
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
            //TODO
            Assert.AreEqual( cutJobCount + 1, cutJobs.ResultColumn.Count );

            // An empty Job appears in the detail area.
            //TODO

            // Save button is enabled.
            Assert.IsTrue( cutJobs.Toolbar.CanSave );

            // There are no contained orders.
            Assert.AreEqual( 0, cutJobs.ContainedOrders.PartOrdersCount );

            // All Sheet Program fields are empty except Nesting Mode
            //TODO

            // No machine is selected ( except if there is only 1 machine available, then this should be selected V2.0X)
            //TODO

            // ID field is focused
            //TODO
            //Assert.IsTrue( cutJobs.BaseInfo.Id.IsFocused );

            // Sheet Program Open button is disabled
            //TODO
            //Assert.IsFalse( cutJobs.SheetProgram.CanOpen );

            // Sheet Program BOOST button is disabled
            Assert.IsFalse( cutJobs.SheetProgram.CanBoost );

            // Order List state is MISSING
            //TODO

            // Sheet Program state is MISSING
            //TODO


        }
    }
}
