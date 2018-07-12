using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Part;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Shell
{
    /// <summary>
    /// Test class for common shell tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcShellTest : TcBaseTestClass
    {
        /// <summary>
        /// Adds a single tab and closes it. Nothing else.
        /// </summary>
        [TestMethod, UniqueName( "E87747D2-4659-40D5-9D99-1058E925C933" )]
        public void AddTab()
        {
            Act( () =>
                {
                    var mainTabControl = HomeZoneApp.On<TcMainTabControl>();
                    var initialTabCount = mainTabControl.Count();

                    mainTabControl.AddNewTab();
                    Assert.AreEqual( mainTabControl.Count(), initialTabCount + 1 );

                    mainTabControl.CloseCurrentTab();
                    Assert.AreEqual( mainTabControl.Count(), initialTabCount );
                } );
        }

        /// <summary>
        /// Adds 10 tabs in a loop.
        /// </summary>
        [TestMethod, UniqueName( "BC7A4769-4C91-47A9-A6AD-2E14D997EEC2" )]
        public void Add10Tabs()
        {
            Act( () =>
                {
                    var mainTabControl = HomeZoneApp.On<TcMainTabControl>();
                    var initialTabCount = mainTabControl.Count();

                    for( int i = 0; i < 10; i++ )
                    {
                        mainTabControl.AddNewTab();
                    }
                    Assert.AreEqual( mainTabControl.Count(), initialTabCount + 10 );
                } );
        }

        /// <summary>
        /// Adds a tab and switches to the part category.
        /// This is done 10 times.
        /// </summary>
        [TestMethod, UniqueName( "D9D5367A-1F0B-4E04-849C-EDD975C1CCEC" )]
        public void Add10TabsWithPartSelected()
        {
            Act( () =>
                {
                    var mainTabControl = HomeZoneApp.On<TcMainTabControl>();
                    var initialTabCount = mainTabControl.Count();
                    var parts = HomeZoneApp.On<TcParts>();

                    for( int i = 0; i < 10; i++ )
                    {
                        mainTabControl.AddNewTab();
                        parts.Goto();
                    }
                    Assert.AreEqual( mainTabControl.Count(), initialTabCount + 10 );
                } );
        }

        /// <summary>
        /// Closes all tabs except for the first one.
        /// </summary>
        [TestMethod, UniqueName( "8A5188D8-817A-4650-B420-B3AFE6DB55FA" )]
        public void CloseAllAdditionalTabs()
        {
            Act( () =>
            {
                var mainTabControl = HomeZoneApp.On<TcMainTabControl>();

                var count = mainTabControl.Count();

                for( int i = 2; i < count; i++ )
                {
                    mainTabControl.CloseCurrentTab();
                }
                Assert.AreEqual( mainTabControl.Count(), 2 );
            } );
        }
    }
}
