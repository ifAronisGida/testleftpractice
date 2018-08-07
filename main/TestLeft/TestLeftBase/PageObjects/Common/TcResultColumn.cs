using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Common
{
    /// <summary>
    /// The result column containing the search area with search text, clear and search buttons and the result list.
    /// Because this PageObject is also used in some dialogs, it is placed in Common and not in the Shell folder.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcMainTabControl}" />
    public class TcResultColumn : PageObject, IChildOf<TcMainTabControl>
    {
        protected override Search SearchPattern => Search.ByUid( "List.SearchAndResult" );

        internal TcTextEdit SearchTextTextEdit => Find<TcTextEdit>( Search.ByUid( "List.Search.Text" ) );
        internal TcTruIconButton ClearSearchTextButton => Find<TcTruIconButton>( Search.ByUid( "List.Search.Clear" ) );
        internal TcTruIconButton ExecuteSearchButton => Find<TcTruIconButton>( Search.ByUid( "List.Search.Execute" ) );
        internal TcListView ResultListView => Find<TcListView>( Search.ByUid( "List.ResultList" ) );

        /// <summary>
        /// Gets or sets the search text.
        /// </summary>
        /// <value>
        /// The search text.
        /// </value>
        public string SearchText
        {
            get { return SearchTextTextEdit.Text; }
            set { SearchTextTextEdit.Text = value; }
        }

        /// <summary>
        /// Gets the amount of items in the result list.
        /// </summary>
        /// <value>
        /// The amount of items in the result list.
        /// </value>
        public int Count => ResultListView.Node.GetProperty<int>( "Items.Count" );

        /// <summary>
        /// Clears the search text.
        /// </summary>
        public void ClearSearch()
        {
            ClearSearchTextButton.Click();
        }

        /// <summary>
        /// Executes the search.
        /// </summary>
        public void DoSearch()
        {
            ExecuteSearchButton.Click();
        }

        /// <summary>
        /// Selects the item with the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void SelectItem( string id )
        {
            if( id.Contains( "id:" ) )
            {
                SearchText = id;
            }
            else
            {
                SearchText = @"id:" + id;
            }

            DoSearch();
            ResultListView.SelectedIndex = 0;
            ClearSearch();
        }

        /// <summary>
        /// Selects all items suitable for the given search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <returns>The amount of selected entries.</returns>
        public int SelectItems( string searchText )
        {
            SearchText = searchText;
            DoSearch();
            return ResultListView.SelectAll();
        }

        /// <summary>
        /// Selects all items.
        /// </summary>
        /// <returns>The amount of selected entries.</returns>
        public int SelectAll()
        {
            return ResultListView.SelectAll();
        }
    }
}
