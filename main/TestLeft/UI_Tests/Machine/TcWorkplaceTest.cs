using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Machine;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
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
                    var machines = HomeZoneApp.On<TcMachines>();

                    machines.Goto();

                    machines.NewCutMachine( "TruLaser 3030 (L20)", TcSettings.NamePrefix + Guid.NewGuid(), "6000" );

                    Assert.IsTrue( machines.Toolbar.SaveButton.Enabled );
                    machines.SaveMachine();
                    Assert.IsFalse( machines.Toolbar.SaveButton.Enabled );

                    machines.WaitForDetailOverlayAppear( TcSettings.MachineSaveOverlayAppearTimeout );
                    machines.WaitForDetailOverlayDisappear( TcSettings.MachineSaveOverlayDisappearTimeout );

                    Assert.IsTrue( machines.Toolbar.DeleteButton.Enabled );
                    machines.DeleteMachine();
                    Assert.IsFalse( machines.Toolbar.DeleteButton.Enabled );
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
                    var machines = HomeZoneApp.On<TcMachines>();

                    machines.Goto();

                    machines.NewBendMachine( "TruBend 5320 (6-axes) B23", TcSettings.NamePrefix + Guid.NewGuid() );
                    machines.Detail.TransferDirectory = @"\\LAPxxxxxx\mmc\Arbeitsplatz 1";
                    machines.Detail.CreateSubDirectory = true;

                    Assert.IsTrue( machines.Toolbar.SaveButton.Enabled );
                    machines.SaveMachine();
                    Assert.IsFalse( machines.Toolbar.SaveButton.Enabled );

                    machines.WaitForDetailOverlayAppear( TcSettings.MachineSaveOverlayAppearTimeout );
                    machines.WaitForDetailOverlayDisappear( TcSettings.MachineSaveOverlayDisappearTimeout );

                    Assert.IsTrue( machines.Toolbar.DeleteButton.Enabled );
                    machines.DeleteMachine();
                    Assert.IsFalse( machines.Toolbar.DeleteButton.Enabled );
                } );
        }
    }
}
