using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using Trumpf.AutoTest.Facts;
using UiObjectInterfaces;
using UiObjectInterfaces.Cut;
using UiObjectInterfaces.Design;
using UiObjectInterfaces.Flux;
using UiObjects;
using UiObjects.PageObjects.Cut;
using UiObjects.PageObjects.Design;
using UiObjects.PageObjects.Flux;
using UiObjects.TestSettings;

namespace UiTests.Base
{
    /// <summary>
    /// Base class for all test classes.
    /// This class contains the connection to TestLeft via the Driver property,
    /// the TestContext, access to the HomeZone, Design, Cut and Flux process via properties and
    /// basic class and test initialization and clean up.
    /// </summary>
    [TestClass]
    public class TcBaseTestClass
    {
        private  AutoFact mAutoFact;

        protected static IDriver Driver { get; } = new LocalDriver();

        [TestInitialize]
        public void Init()
        {
            TestSettings = new TcTestSettings( TestContext );
            mAutoFact = new AutoFact( new TcTestOptions( GetType(), TestContext, TestSettings ) );

            HomeZone = new TcHomeZoneApp( TestSettings.TestedAppName, Driver );
            DesignApp = new TcDesign( Driver );
            CutApp = new TcCut( Driver );
            FluxApp = new TcFlux( TestSettings.FluxProcessName, Driver );
        }

        /// <summary>
        /// The test context.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// The test settings.
        /// </summary>
        public static TcTestSettings TestSettings { get; private set; }

        /// <summary>
        /// Gets the HomeZone ProcessObject.
        /// </summary>
        /// <value>
        /// The HomeZone ProcessObject.
        /// </value>
        public static TiHomeZoneApp HomeZone { get;private set; }

        /// <summary>
        /// Manages access to the Design application.
        /// </summary>
        /// <value>
        /// The Design application.
        /// </value>
        public static TiDesign DesignApp { get; private set; }

        /// <summary>
        /// Manages access to the Cut application.
        /// </summary>
        /// <value>
        /// The Cut application.
        /// </value>
        public static TiCut CutApp { get; private set; }


        /// <summary>
        /// Manages access to the Flux application.
        /// </summary>
        /// <value>
        /// The Flux application.
        /// </value>
        public static TiFlux FluxApp { get; private set; }

        protected void Act( Action action, string caption = null )
            => mAutoFact.Act( action, caption );
    }
}
