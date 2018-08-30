using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.Composite
{
    public class TcResultColumn : ControlObject
    {
        public const string Uid = "List.SearchAndResult";

        protected override Search SearchPattern => Search.Any;

        private TcTextEdit SearchTextTextEdit => Find<TcTextEdit>( Search.ByUid( "List.Search.Text" ) );
        private TcTruIconButton ClearSearchTextButton => Find<TcTruIconButton>( Search.ByUid( "List.Search.Clear" ) );
        private TcTruIconButton ExecuteSearchButton => Find<TcTruIconButton>( Search.ByUid( "List.Search.Execute" ) );
        private TcListView ResultListView => Find<TcListView>( Search.ByUid( "List.ResultList" ) );

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
        public int Count => ResultListView.Count;

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
