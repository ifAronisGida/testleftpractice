using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using FactsHub.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using TestLeft.TestLeftBase;
using TestLeft.TestLeftBase.Settings;
using Trumpf.AutoTest.Facts;
using Trumpf.AutoTest.Utilities;
using Trumpf.PageObjects;


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
        private readonly AutoFact mAutoFact;

        public TcBaseTestClass()
            => mAutoFact = new AutoFact( new TcTestOptions( GetType, () => TestContext ) );

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

        protected void Act( Action action, string caption = null )
            => mAutoFact.Act( action, caption );
    }

    /// <summary>
    /// Defining the test options.
    /// </summary>
    /// <seealso cref="Trumpf.AutoTest.Facts.IAutoFactOptions" />
    public class TcTestOptions : IAutoFactOptions
    {
        private readonly Func<Type> mGetTestClass;
        private readonly Func<TestContext> mTestContext;
        private readonly Func<IDoSequence, IDoSequence> mDoSequenceConfiguration;
        public TcTestOptions( Func<Type> getTestClass, Func<TestContext> testContext, Func<IDoSequence, IDoSequence> doSequenceConfiguration = null )
        {
            mGetTestClass = getTestClass;
            mDoSequenceConfiguration = doSequenceConfiguration ?? ( e => e );
            mTestContext = testContext;
        }

        public string Remarks
            => "no remarks";

        public string[] TagsExtractor
            => TestMethod.GetCustomAttributes<TagAttribute>().Select( e => e.Name ).ToArray();

        public MethodInfo TestMethod
            => mGetTestClass().Assembly.GetTypes().FirstOrDefault( f => f.FullName == mTestContext().FullyQualifiedTestClassName )?.GetMethod( mTestContext().TestName );

        public void AddAssetAction( string path )
            => mTestContext().AddResultFile( path );

        public IClaim ClaimConfiguration( IClaim claim )
        {
            claim.Product = @"HomeZone";
            claim.Version = "8.0.0";  //TODO
            claim.Context = "LAP013742";  //TODO
            claim.Process = "Developer test";  //TODO
            return claim;
        }

        public ICollectorsOptions CollectorsConfigurator( ICollectorsOptions collectors )
            => collectors
                .ScreenRecorder.Disable();

        public IExceptionActionMap ExceptionActionMap( IRunningAutoFact runningAutoFact, IExceptionActionMap exceptionActionMap )
            => exceptionActionMap;

        public IExceptionActionMap ExceptionActionMapConfigurator( IExceptionActionMap exceptionActionMap )
            => exceptionActionMap;

        public void Log( string line )
           => Trace.WriteLine( line );

        public ISendToFactsHubOptions SendToFactsHubConfigurator( ISendToFactsHubOptions options )
            =>
            options
                .Enable( new Uri( "http://LAP013742:5000" ) )       //TODO
                .ThrowOnErrors.Disable();

        public IDoSequence TestEnvironmentConfiguration( IDoSequence doSequence )
            => mDoSequenceConfiguration( doSequence );
    }
}
