using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using TestLeft.TestLeftBase;
using TestLeft.TestLeftBase.Settings;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Base
{
    /// <summary>
    /// Base class for all test classes.
    /// This class contains the connection to TestLeft via the Driver property,
    /// the TestContext, access to the HomeZone process via HomeZoneApp and
    /// basic class and test initialization and clean up.
    /// </summary>
    [TestClass]
    public class TcBaseTestClass : AutoTestWithFactsBase
    {
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
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Gets the HomeZone ProcessObject.
        /// </summary>
        /// <value>
        /// The HomeZone ProcessObject.
        /// </value>
        public static TcHomeZoneApp HomeZoneApp { get; } = new TcHomeZoneApp( TcSettings.HomeZoneProcessName )
        {
            Driver = Driver
        };

        ///// <summary>
        ///// Initializes the test.
        ///// The folder for the test result is created and the HomeZone will be started if it is not already running.
        ///// </summary>
        ///// <exception cref="Exception">Path not found to start process!</exception>
        //[ TestInitialize()]
        //public void Initialize()
        //{
        //    Driver.Log.OpenFolder( TestContext.FullyQualifiedTestClassName + "." + TestContext.TestName );

        //    // check if HomeZone is already running
        //    var runningHomeZone = System.Diagnostics.Process.GetProcessesByName( TcSettings.HomeZoneProcessName );

        //    if( runningHomeZone.Length == 0 )               // not running => start HomeZone
        //    {
        //        if( !Directory.Exists( TcSettings.ProgramPath ) )
        //        {
        //            throw new Exception( "Path not found to start process!" );
        //        }

        //        var filename = Path.Combine( TcSettings.ProgramPath, TcSettings.HomeZoneProcessName + ".exe" );
        //        var startInfo = new System.Diagnostics.ProcessStartInfo
        //        {
        //            FileName = filename,
        //            WorkingDirectory = TcSettings.ProgramPath
        //        };
        //        var process = System.Diagnostics.Process.Start( startInfo );
        //    }

        //    var mainWindow = HomeZoneApp.On<TcMainWindow>();
        //    mainWindow.Exists.WaitFor(TimeSpan.FromSeconds(60));
        // }

        ///// <summary>
        ///// Cleaning up after the test run.
        ///// If the test did not pass, the result file is written.
        ///// </summary>
        //[TestCleanup]
        //public void TestCleanup()
        //{
        //    if( TestContext.CurrentTestOutcome != UnitTestOutcome.Passed )
        //    {
        //        Driver.Log.Error( "The test failed. See information on errors in the MSTest log." );
        //        TestContext.AddResultFile( TestContext.ResultsDirectory + @"\UI_Tests TestResults\index.htm" );
        //    }

        //    Driver.Log.CloseFolder();
        //}

        protected override MethodInfo TestMethod => GetType().Assembly.GetTypes().FirstOrDefault( f => f.FullName == TestContext.FullyQualifiedTestClassName )?.GetMethod( TestContext.TestName );
        protected override Uri FactsHubServiceUri => new Uri( "http://LAP013742:5000" );    //TODO use settings
        public override string Product => @"HomeZone";
        public override string Version => "8.0.0";  //TODO
        public override string Context => "LAP013742";  //TODO
        public override string Process => "Developer test";  //TODO

#if DEBUG
        protected override bool EnableSoftResetter => false;
        protected override bool EnableSystemLocker => false;

        //protected override bool SendResultsIntoTheCloud => false;     // uncomment later
#endif


    }
}
