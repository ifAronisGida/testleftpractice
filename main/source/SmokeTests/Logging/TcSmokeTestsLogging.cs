using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using System.Reflection;

namespace HomeZone.SmokeTests.Logging
{
    [TestClass]
    class TcSmokeTestsLogging : TcBaseTestClass
    {
        /// <summary>
        /// Save Log File after finishing all tests in Assembly
        /// </summary>
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            string testResultPath = GetLoggingFolder(AssemblyName.GetAssemblyName( Assembly.GetExecutingAssembly().ManifestModule.Name ).Name);
            Driver.Log.Save( testResultPath, Log.Format.Html );
        }
    }
}
