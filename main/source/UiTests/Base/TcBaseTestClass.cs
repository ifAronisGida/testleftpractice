using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using Trumpf.AutoTest.Facts;
using HomeZone.UiObjectInterfaces;
using HomeZone.UiObjectInterfaces.Cut;
using HomeZone.UiObjectInterfaces.Design;
using HomeZone.UiObjectInterfaces.Flux;
using HomeZone.UiObjects;
using HomeZone.UiObjects.PageObjects.Cut;
using HomeZone.UiObjects.PageObjects.Design;
using HomeZone.UiObjects.PageObjects.Flux;
using HomeZone.UiObjects.PageObjects.Shell;
using HomeZone.UiObjects.TestSettings;

namespace HomeZone.UiTests.Base
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

            DesignApp = new TcDesign( Driver );
            CutApp = new TcCut( Driver );
            FluxApp = new TcFlux( TestSettings.FluxProcessName, Driver );

            TcAppLangDependentStrings.CurrentLanguage = TestSettings.ApplicationLanguage;

            // check if HomeZone is already running
            var runningHomeZone = Process.GetProcessesByName( TestSettings.TestedAppName );

            if( runningHomeZone.Length == 0 )               // not running => start HomeZone
            {
                if( !Directory.Exists( TestSettings.TestedAppPath ) )
                {
                    throw new Exception( "Path not found to start process!" );
                }

                var filename = Path.Combine( TestSettings.TestedAppPath, TestSettings.TestedAppName + ".exe" );
                var startInfo = new ProcessStartInfo
                {
                    FileName = filename,
                    WorkingDirectory = TestSettings.TestedAppPath
                };
                var process = Process.Start( startInfo );
            }

            // connect to HomeZone process and wait until visible
            HomeZone = new TcHomeZoneApp( TestSettings.TestedAppName, Driver );

            HomeZone.MainWindowExists.WaitFor( TimeSpan.FromSeconds( 60 ) );

            //TODO wait for machine templates
            //var machines = HomeZone.Machines;
            //machines.Goto();
            //var rc = machines.Toolbar.IsNewBendMachineEnabled;
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
        public static TiHomeZoneApp HomeZone { get; private set; }

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
