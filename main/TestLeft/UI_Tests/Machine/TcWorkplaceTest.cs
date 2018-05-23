using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Machine;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.Settings;
using Trumpf.TruTops.Control.TestLeft.UI_Tests.Base;

namespace Trumpf.TruTops.Control.TestLeft.UI_Tests.Machine
{
    /// <summary>
    /// This test class contains workplace specific tests.
    /// These test methods are mainly used for module and PageObject tests.
    /// It is not secured that the methods are cleaning up at the end.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcWorkplaceTest : TcBaseTestClass
    {
        #region Class initializers
        [ClassInitialize]
        public static void ClassInitialize( TestContext context )
        {
            TcBaseTestClass.InitializeClass( context );
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            TcBaseTestClass.FinalizeClass();
        }
        #endregion

        /// <summary>
        /// Creates a new cut machine.
        /// </summary>
        [TestMethod]
        public void NewCutMachineTest()
        {
            var machines = HomeZoneApp.On<TcMachines>();

            machines.Goto();

            machines.NewCutMachine( "TruLaser 3030 (L20)", TcSettings.NamePrefix + Guid.NewGuid(), "6000" );
            
            machines.SaveMachine();
        }

        /// <summary>
        /// Creates a new bend machine.
        /// </summary>
        [TestMethod]
        public void NewBendMachineTest()
        {
            var machines = HomeZoneApp.On<TcMachines>();

            machines.Goto();

            machines.NewBendMachine( "TruBend 5320 (6-axes) B23", TcSettings.NamePrefix + Guid.NewGuid() );
            machines.Detail.TransferDirectory = @"\\LAPxxxxxx\mmc\Arbeitsplatz 1";
            machines.Detail.CreateSubDirectory = true;

            machines.SaveMachine();
        }

        /// <summary>
        /// Creates and then deletes a bend machine.
        /// </summary>
        [TestMethod]
        public void DeleteBendMachineTest()
        {
            var machines = HomeZoneApp.On<TcMachines>();

            machines.Goto();

            machines.NewBendMachine( "TruBend 5320 (6-axes) B23", TcSettings.NamePrefix + Guid.NewGuid() );

            machines.SaveMachine();

            machines.DeleteMachine();
        }
    }
}
