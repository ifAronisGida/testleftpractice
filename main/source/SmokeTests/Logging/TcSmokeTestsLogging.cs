using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            AssemblyCleanup( Assembly.GetExecutingAssembly() );
        }
    }
}
