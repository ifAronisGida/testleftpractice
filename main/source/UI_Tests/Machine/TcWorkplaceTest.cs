﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
using TestLeft.UI_Tests.Utilities;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Machine
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
                    Assert.AreEqual( machineCount, machines.ResultColumn.Count );
                } );
        }

        /// <summary>
        /// Creates a new bend machine, saves and then deletes it.
        /// </summary>
        [TestMethod, UniqueName( "5E83ACD3-80E9-497E-AF94-B4F67B8B17B7" )]
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
    }
}