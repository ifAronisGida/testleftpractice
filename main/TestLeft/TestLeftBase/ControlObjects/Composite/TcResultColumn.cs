using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.Composite
{
    /// <summary>
    /// The result column containing the search area with search text, clear and search buttons and the result list.
    /// </summary>
    public class TcResultColumn : TcGenericControlObject
    {
        public const string Uid = "List.SearchAndResult";

        private TiValueControl<string> SearchText => TcControlMapper.Map<TiValueControl<string>>( this.FindGeneric( Search.ByUid( "List.Search.Text" ) ) );
        private TcTruIconButton ClearSearchTextButton => Find<TcTruIconButton>( Search.ByUid( "List.Search.Clear" ) );
        private TcTruIconButton ExecuteSearchButton => Find<TcTruIconButton>( Search.ByUid( "List.Search.Execute" ) );
        private TcListView ResultListView => Find<TcListView>( Search.ByUid( "List.ResultList" ) );
        private TcOverlay Overlay => Find<TcOverlay>( Search.ByUid( "ResultList.Overlay" ) );

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
            if( ClearSearchTextButton.Visible )
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
            SearchText.Value = id.StartsWith( "id:" ) ? id : $"id:{id}";

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
            SearchText.Value = searchText;
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
