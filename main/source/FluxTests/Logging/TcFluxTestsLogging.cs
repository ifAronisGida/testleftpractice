using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using System.Reflection;

namespace HomeZone.FluxTests.Logging
{
    [TestClass]
    class TcFluxTestsLogging : TcBaseTestClass
    {
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            string testResultPath = GetLoggingFolder(AssemblyName.GetAssemblyName( Assembly.GetExecutingAssembly().ManifestModule.Name ).Name);
            Driver.Log.Save( testResultPath, Log.Format.Html );
        }
    }
}
