using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.UI_Tests.Base;

namespace TestLeft.UI_Tests.Shell
{
    /// <summary>
    /// Test class for common shell tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcShellTest : TcBaseTestClass
    {
        #region Class initializers
        [ClassInitialize]
        public static void ClassInitialize( TestContext context )
        {
            InitializeClass( context );
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            FinalizeClass();
        }
        #endregion

        /// <summary>
        /// Adds a single tab. Nothing else.
        /// </summary>
        [TestMethod]
        public void AddTab()
        {
            var mainTabControl = HomeZoneApp.On<TcMainTabControl>();

            mainTabControl.AddNewTab();
        }

        /// <summary>
        /// Adds 10 tabs in a loop.
        /// </summary>
        [TestMethod]
        public void Add10Tabs()
        {
            var mainTabControl = HomeZoneApp.On<TcMainTabControl>();

            for( int i = 0; i < 10; i++ )
            {
                mainTabControl.AddNewTab();
            }
        }

        /// <summary>
        /// Closes the current tab.
        /// </summary>
        [TestMethod]
        public void CloseTab()
        {
            var mainTabControl = HomeZoneApp.On<TcMainTabControl>();

            mainTabControl.CloseCurrentTab();
        }

        /// <summary>
        /// Closes all tabs except for the first one.
        /// </summary>
        [TestMethod]
        public void CloseAllAdditionalTabs()
        {
            var mainTabControl = HomeZoneApp.On<TcMainTabControl>();

            var count = mainTabControl.Count();

            for( int i = 2; i < count; i++ )
            {
                mainTabControl.CloseCurrentTab();
            }
        }

        /// <summary>
        /// Adds a tab and switches to the part category.
        /// This is done 10 times.
        /// </summary>
        [TestMethod]
        public void Add10TabsWithPartSelected()
        {
            var mainTabControl = HomeZoneApp.On<TcMainTabControl>();
            var parts = HomeZoneApp.On<TcParts>();

            for( int i = 0; i < 10; i++ )
            {
                mainTabControl.AddNewTab();
                parts.Goto();
            }
        }
    }
}
