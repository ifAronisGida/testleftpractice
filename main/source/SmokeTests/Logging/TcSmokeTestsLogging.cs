using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeZone.SmokeTests.Logging
{
    [TestClass]
    class TcSmokeTestsLogging : TcBaseTestClass
    {
        /// <summary>
        /// Save Log File after finishing all tests in Assembly
        /// </summary>
        [AssemblyCleanup]
        public static new void AssemblyCleanup()
        {
            TcBaseTestClass.AssemblyCleanup();
        }
    }
}
