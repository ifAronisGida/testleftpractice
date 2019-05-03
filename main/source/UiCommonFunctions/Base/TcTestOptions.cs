using FactsHub.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using HomeZone.UiCommonFunctions.TestSettings;
using Trumpf.AutoTest.Facts;
using Trumpf.AutoTest.Utilities;

namespace HomeZone.UiCommonFunctions.Base
{
    /// <summary>
    /// Defining the test options.
    /// </summary>
    /// <seealso cref="Trumpf.AutoTest.Facts.IAutoFactOptions" />
    public class TcTestOptions : IAutoFactOptions
    {
        private readonly Type mGetTestClass;
        private readonly TestContext mTestContext;
        private readonly TcTestSettings mSettings;
        private readonly Func<IDoSequence, IDoSequence> mDoSequenceConfiguration;

        public TcTestOptions( Type getTestClass, TestContext testContext, TcTestSettings settings, Func<IDoSequence, IDoSequence> doSequenceConfiguration = null )
        {
            mGetTestClass = getTestClass;
            mDoSequenceConfiguration = doSequenceConfiguration ?? ( e => e );
            mTestContext = testContext;
            mSettings = settings;
        }

        public string Remarks => mSettings.Remarks;

        public string[] TagsExtractor
            => TestMethod.GetCustomAttributes<TagAttribute>().Select( e => e.Name ).ToArray();

        public IAssetCleanerOptions AssetCleanerConfigurator( IAssetCleanerOptions assetCleanerOptions )
        {
            return assetCleanerOptions;
        }

        public MethodInfo TestMethod
            => mGetTestClass.Assembly.GetTypes().FirstOrDefault( f => f.FullName == mTestContext.FullyQualifiedTestClassName )?.GetMethod( mTestContext.TestName );

        public void AddAssetAction( string path )
            => mTestContext.AddResultFile( path );

        public IClaim ClaimConfiguration( IClaim claim )
        {
            claim.Product = mSettings.Product;
            claim.Version = mSettings.Version;
            claim.Context = mSettings.Context;
            claim.Process = mSettings.Process;
            return claim;
        }

        public ICollectorsOptions CollectorsConfigurator( ICollectorsOptions collectors )
            => mSettings.ScreenRecorderEnabled
                ? collectors.ScreenRecorder.Enable()
                : collectors.ScreenRecorder.Disable();

        public IExceptionActionMap ExceptionActionMap( IRunningAutoFact runningAutoFact, IExceptionActionMap exceptionActionMap )
            => exceptionActionMap;

        public IExceptionActionMap ExceptionActionMapConfigurator( IExceptionActionMap exceptionActionMap )
            => exceptionActionMap;

        public void Log( string line )
           => Trace.WriteLine( line );

        public ISendToFactsHubOptions SendToFactsHubConfigurator( ISendToFactsHubOptions options )
        {
            var o = options.ThrowOnErrors.Disable();
            return mSettings.FactsHubEnabled
                ? o.Enable( new Uri( mSettings.FactsHubAddress ) )
                : o.Disable();
        }

        public IDoSequence TestEnvironmentConfiguration( IDoSequence doSequence )
            => mDoSequenceConfiguration( doSequence );
    }
}
