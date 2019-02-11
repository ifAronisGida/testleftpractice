using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.UiObjectsTests.Shell
{
    //TEST

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
        [Tag( "Shell" )]
        public void AddAndCloseTab()
        {
            Act( () =>
                {
                    var mainTabControl = HomeZone.MainTabControl;
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
        [Tag( "Shell" )]
        public void Add10Tabs()
        {
            Act( () =>
                {
                    var mainTabControl = HomeZone.MainTabControl;
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
        [Tag( "Shell" )]
        public void Add10TabsWithPartSelected()
        {
            Act( () =>
                {
                    var mainTabControl = HomeZone.MainTabControl;
                    var initialTabCount = mainTabControl.Count();

                    for( int i = 0; i < 10; i++ )
                    {
                        mainTabControl.AddNewTab();
                        HomeZone.GotoParts();
                    }
                    Assert.AreEqual( mainTabControl.Count(), initialTabCount + 10 );
                } );
        }

        /// <summary>
        /// Closes all tabs except for the first one.
        /// </summary>
        [TestMethod, UniqueName( "8A5188D8-817A-4650-B420-B3AFE6DB55FA" )]
        [Tag( "Shell" )]
        public void CloseAllAdditionalTabs()
        {
            Act( () =>
            {
                var mainTabControl = HomeZone.MainTabControl;

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
