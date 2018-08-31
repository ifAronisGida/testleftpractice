using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.Composite
{ 
    /// <summary>
    /// The result column containing the search area with search text, clear and search buttons and the result list.
    /// </summary>
    public class TcResultColumn : ControlObject
    {
        public const string Uid = "List.SearchAndResult";

        protected override Search SearchPattern => Search.Any;

        private TcTextEdit SearchTextTextEdit => Find<TcTextEdit>( Search.ByUid( "List.Search.Text" ) );
        private TcTruIconButton ClearSearchTextButton => Find<TcTruIconButton>( Search.ByUid( "List.Search.Clear" ) );
        private TcTruIconButton ExecuteSearchButton => Find<TcTruIconButton>( Search.ByUid( "List.Search.Execute" ) );
        private TcListView ResultListView => Find<TcListView>( Search.ByUid( "List.ResultList" ) );
        private TcOverlay Overlay => Find<TcOverlay>( Search.ByUid( "ResultList.Overlay" ) );

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
        /// Clears the search text if it is not empty.
        /// </summary>
        public void ClearSearch()
        {
            if (ClearSearchTextButton.Visible)
            {
                ClearSearchTextButton.Click();
                Overlay.Visible.WaitForFalse();
            }
        }

        /// <summary>
        /// Executes the search.
        /// </summary>
        public void DoSearch()
        {
            ExecuteSearchButton.Click();
            Overlay.Visible.WaitForFalse();
        }

        /// <summary>
        /// Selects the item with the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void SelectItem( string id )
        {
            SearchText = id.StartsWith( "id:" ) ? id : $"id:{id}";

            DoSearch();
            ResultListView.SelectedIndex = 0;
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
            ClearSearch();
            return ResultListView.SelectAll();
        }
    }
}
