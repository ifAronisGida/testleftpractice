using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using TestLeft.TestLeftBase;
using TestLeft.TestLeftBase.Settings;

namespace TestLeft.UI_Tests.Base
{
    /// <summary>
    /// Base class for all test classes.
    /// This class contains the connection to TestLeft via the Driver property,
    /// the TestContext, access to the HomeZone process via HomeZoneApp and
    /// basic class and test initialization and clean up.
    /// </summary>
    [TestClass]
    public class TcBaseTestClass
    {
        private static TestContext mTestContext;

        /// <summary>
        /// Initializes the <see cref="TcBaseTestClass"/> class and
        /// creates the driver object.
        /// </summary>
        static TcBaseTestClass()
        {
            //Create a local Driver object
            Driver = new LocalDriver();

            //Use line below instead of the above to create a remote Driver
            //_driver = new RemoteDriver("myhost", "userName", "password");

            //Uncomment the line below to perform additional checks during code execution
            //_driver.Options.Debug.RuntimeChecks = SmartBear.TestLeft.Options.RuntimeChecks.All;
        }

        /// <summary>
        /// Interface to the TestLeft engine.
        /// </summary>
        protected static IDriver Driver { get; }

        /// <summary>
        /// The test context.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return mTestContext;
            }

            set
            {
                mTestContext = value;
            }
        }

        /// <summary>
        /// Gets the HomeZone ProcessObject.
        /// </summary>
        /// <value>
        /// The HomeZone ProcessObject.
        /// </value>
        public static TcHomeZoneApp HomeZoneApp { get; private set; }

        /// <summary>
        /// Initializes the class, stores the test context.
        /// </summary>
        /// <param name="context">The context.</param>
        [ClassInitialize]
        public static void InitializeClass( TestContext context )
        {
            mTestContext = context;
        }

        /// <summary>
        /// Finalizes the class, saves the test result.
        /// </summary>
        [ClassCleanup]
        public static void FinalizeClass()
        {
            Driver.Log.Save( mTestContext.ResultsDirectory + @"\UI_Tests TestResults", Log.Format.Html );
        }

        /// <summary>
        /// Initializes the test.
        /// The folder for the test result is created and the HomeZone will be started if it is not already running.
        /// </summary>
        /// <exception cref="Exception">Path not found to start process!</exception>
        [TestInitialize()]
        public void Initialize()
        {
            Driver.Log.OpenFolder( mTestContext.FullyQualifiedTestClassName + "." + mTestContext.TestName );

            // check if HomeZone is already running
            var runningHomeZone = Process.GetProcessesByName( TcSettings.ProcessName );

            if( runningHomeZone.Length == 0 )               // not running => start HomeZone
            {
                if( !Directory.Exists( TcSettings.ProgramPath ) )
                {
                    throw new Exception( "Path not found to start process!" );
                }

                var filename = Path.Combine( TcSettings.ProgramPath, TcSettings.ProcessName + ".exe" );
                var startInfo = new ProcessStartInfo
                {
                    FileName = filename,
                    WorkingDirectory = TcSettings.ProgramPath
                };
                var process = Process.Start( startInfo );

                Thread.Sleep( TimeSpan.FromSeconds( 30 ) );     // wait for startup, SpaceClaim, FluxAdapter...
            }

            // connect to HomeZone process and wait until visible
            HomeZoneApp = new TcHomeZoneApp( TcSettings.ProcessName );
       }

        /// <summary>
        /// Cleaning up after the test run.
        /// If the test did not pass, the result file is written.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            if( mTestContext.CurrentTestOutcome != UnitTestOutcome.Passed )
            {
                Driver.Log.Error( "The test failed. See information on errors in the MSTest log." );
                mTestContext.AddResultFile( mTestContext.ResultsDirectory + @"\UI_Tests TestResults\index.htm" );
            }

            Driver.Log.CloseFolder();
        }
    }
}
