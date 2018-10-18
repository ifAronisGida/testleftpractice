using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using FactsHub.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjectInterfaces;
using PageObjectInterfaces.Cut;
using PageObjectInterfaces.Design;
using PageObjectInterfaces.Flux;
using SmartBear.TestLeft;
using TestLeft.TestLeftBase;
using TestLeft.TestLeftBase.PageObjects.Cut;
using TestLeft.TestLeftBase.PageObjects.Design;
using TestLeft.TestLeftBase.PageObjects.Flux;
using TestLeft.TestLeftBase.Settings;
using Trumpf.AutoTest.Facts;
using Trumpf.AutoTest.Utilities;

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

        /// <summary>
        /// Initializes the <see cref="TcBaseTestClass"/> class and
        /// creates the driver object.
        /// </summary>
        public TcBaseTestClass()
        {
            mAutoFact = new AutoFact( new TcTestOptions( GetType, () => TestContext ) );

            HomeZone = new TcHomeZoneApp( TcSettings.HomeZoneProcessName, Driver );
            DesignApp = new TcDesign( Driver );
            CutApp = new TcCut( Driver );
            FluxApp = new TcFlux( Driver );
        }

        protected static IDriver Driver { get; } = new LocalDriver();

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
        public TiHomeZoneApp HomeZone { get; }

        /// <summary>
        /// Manages access to the Design application.
        /// </summary>
        /// <value>
        /// The Design application.
        /// </value>
        public TiDesign DesignApp { get; }

        /// <summary>
        /// Manages access to the Cut application.
        /// </summary>
        /// <value>
        /// The Cut application.
        /// </value>
        public TiCut CutApp { get; }


        /// <summary>
        /// Manages access to the Flux application.
        /// </summary>
        /// <value>
        /// The Flux application.
        /// </value>
        public TiFlux FluxApp { get; }


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

        public IAssetCleanerOptions AssetCleanerConfigurator( IAssetCleanerOptions assetCleanerOptions )
        {
            return assetCleanerOptions;
        }

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
