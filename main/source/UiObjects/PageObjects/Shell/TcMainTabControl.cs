using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Shell;


namespace UiObjects.PageObjects.Shell
{
    /// <summary>
    /// The PageObject for the main tab control.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcMainWindow}" />
    public class TcMainTabControl : PageObject, IChildOf<TcMainWindow>, TiMainTabControl
    {
        protected override Search SearchPattern => Search.ByUid( "MainTabControl" );

        internal IControlObject AddControlObject => Find<IControlObject>( Search.ByUid( "MainTabControl.Add" ), null, 20 );

        /// <summary>
        /// Gets or sets the index of the selected tab.
        /// </summary>
        /// <value>
        /// The index of the selected tab.
        /// </value>
        public int SelectedIndex
        {
            get { return Node.GetProperty<int>( "SelectedIndex" ); }
            set { Node.SetProperty( "SelectedIndex", value ); }
        }

        /// <summary>
        /// Returns the current amount of tabs.
        /// </summary>
        /// <returns>The current amount of tabs.</returns>
        public int Count()
        {
            return Node.GetProperty<int>( "Items.Count" );
        }

        /// <summary>
        /// Adds a new tab.
        /// </summary>
        /// <returns></returns>
        public int AddNewTab()
        {
            AddControlObject.Click();

            return SelectedIndex;
        }

        /// <summary>
        /// Closes the current tab.
        /// </summary>
        public void CloseCurrentTab()
        {
            var closeButton = Node.GetProperty<IObject>( "CloseButton" );
            closeButton.CallMethod( "OnClick" );
        }
    }
}
