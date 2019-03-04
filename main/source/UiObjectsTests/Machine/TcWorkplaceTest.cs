using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.UiObjectsTests.Machine
{
    /// <summary>
    /// This test class contains workplace specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcWorkplaceTest : TcBaseTestClass
    {
        /// <summary>
        /// Creates a new cut machine, saves and then deletes it.
        /// </summary>
        [TestMethod, UniqueName( "5AB063F6-E0E2-4E79-BD0C-2D276CFFB742" )]
        [Tag( "Machine" )]
        public void NewCutMachineAndDeleteTest()
        {
            Act( () =>
            {
                var testMachineName = TestSettings.NamePrefix + Guid.NewGuid();
                var machines = HomeZone.GotoMachines();

                var machineCount = machines.ResultColumn.Count;

                machines.NewCutMachine( "TruLaser 3030 (L20)", testMachineName, "6000" );

                Assert.IsTrue( machines.Toolbar.CanSave );
                machines.Toolbar.Save();
                Assert.IsFalse( machines.Toolbar.CanSave );
                Assert.AreEqual( machineCount + 1, machines.ResultColumn.Count );

                machines.WaitForDetailOverlayAppear( TestSettings.MachineOverlayAppearTimeout );
                machines.WaitForDetailOverlayDisappear( TestSettings.MachineOverlayDisappearTimeout );

                machines.ResultColumn.SelectItem( testMachineName );

                Assert.IsTrue( machines.Toolbar.CanDelete );
                machines.Toolbar.Delete();

                machines.WaitForDetailOverlayAppear( TestSettings.MachineOverlayAppearTimeout );
                machines.WaitForDetailOverlayDisappear( TestSettings.MachineOverlayDisappearTimeout );

                Assert.IsFalse( machines.Toolbar.CanDelete );

                machines.ResultColumn.ClearSearch();
                Assert.AreEqual( machineCount, machines.ResultColumn.Count );
            } );
        }

        [TestMethod, UniqueName( "831D7DCB-90EE-4A57-BE22-B9DE1EA45B85" )]
        [Tag( "Machine" )]
        public void NewPunchMachineAndDeleteTest()
        {
            Act( () =>
            {
                var testMachineName = TestSettings.NamePrefix + Guid.NewGuid();
                var machines = HomeZone.GotoMachines();

                machines.NewCutMachine( "TruPunch 1000 (S05)", testMachineName );

                Assert.IsTrue( machines.Toolbar.CanSave );
                machines.Toolbar.Save();
                Assert.IsFalse( machines.Toolbar.CanSave );

                machines.WaitForDetailOverlayAppear( TestSettings.MachineOverlayAppearTimeout );
                machines.WaitForDetailOverlayDisappear( TestSettings.MachineOverlayDisappearTimeout );

                machines.ResultColumn.SelectItem( testMachineName );

                Assert.IsTrue( machines.Toolbar.CanDelete );
                machines.Toolbar.Delete();

                machines.WaitForDetailOverlayAppear( TestSettings.MachineOverlayAppearTimeout );
                machines.WaitForDetailOverlayDisappear( TestSettings.MachineOverlayDisappearTimeout );

                Assert.IsFalse( machines.Toolbar.CanDelete );
            } );
        }

        /// <summary>
        /// Creates a new bend machine, saves and then deletes it.
        /// </summary>
        [TestMethod, UniqueName( "5E83ACD3-80E9-497E-AF94-B4F67B8B17B7" )]
        [Tag( "Machine" )]
        public void NewBendMachineAndDeleteTest()
        {
            Act( () =>
            {
                var testMachineName = TestSettings.NamePrefix + Guid.NewGuid();
                var machines = HomeZone.GotoMachines();

                var machineCount = machines.ResultColumn.Count;

                machines.NewBendMachine( "TruBend 5320 (6-axes) B23", testMachineName );
                machines.Detail.TransferDirectory.Value = @"\\LAPxxxxxx\mmc\Arbeitsplatz 1";
                machines.Detail.CreateSubDirectory.Value = true;

                Assert.IsTrue( machines.Toolbar.CanSave );
                machines.Toolbar.Save();
                Assert.IsFalse( machines.Toolbar.CanSave );
                Assert.AreEqual( machineCount + 1, machines.ResultColumn.Count );

                machines.WaitForDetailOverlayAppear( TestSettings.MachineOverlayAppearTimeout );
                machines.WaitForDetailOverlayDisappear( TestSettings.MachineOverlayDisappearTimeout );

                machines.ResultColumn.SelectItem( testMachineName );

                Assert.IsTrue( machines.Toolbar.CanDelete );
                machines.Toolbar.Delete();
                Assert.IsFalse( machines.Toolbar.CanDelete );
                Assert.AreEqual( machineCount, machines.ResultColumn.Count );
            } );
        }

        [TestMethod]
        public void GetAvailableBendMachinesTest()
        {
            var machines = HomeZone.Machines.Detail.GetAvailableBendMachineTemplates();

            Assert.AreNotEqual( 0, machines.Count );
        }
    }
}
