using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeZone.UiObjectsTests.Logging
{
    [TestClass]
    public sealed class TcUiObjectsTestsLogging : TcBaseTestClass
    {
        /// <summary>
        /// Save Log File after finishing all tests in Assembly
        /// </summary>
        [AssemblyCleanup]
        public new static void AssemblyCleanup()
        {
            TcBaseTestClass.AssemblyCleanup();
        }
    }
}
