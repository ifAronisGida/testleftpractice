using System;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Common;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjects.Utilities;

namespace HomeZone.UiObjects.ControlObjects.Composite
{
    /// <summary>
    /// The result column containing the search area with search text, clear and search buttons and the result list.
    /// </summary>
    internal class TcResultColumn : TiResultColumn
    {
        private readonly IControlObject mResultColumn;

        public TcResultColumn( IControlObject resultColumn )
        {
            mResultColumn = resultColumn;
        }

        /// <summary>
        /// Gets the search text control.
        /// </summary>
        /// <value>
        /// The search text control.
        /// </value>
        public TiValueControl<string> SearchText => mResultColumn.FindMapped<TiValueControl<string>>( "List.Search.Text" );

        protected TcListView ResultListView => mResultColumn.Find<TcListView>( Search.ByUid( "List.ResultList" ) );

        private TiButton ClearSearchTextButton => mResultColumn.FindMapped<TiButton>( "List.Search.Clear" );
        private TiButton ExecuteSearchButton => mResultColumn.FindMapped<TiButton>( "List.Search.Execute" );
        private TcOverlay Overlay => mResultColumn.Find<TcOverlay>( Search.ByUid( "ResultList.Overlay" ) );

        /// <summary>
        /// Gets the amount of items in the result list.
        /// </summary>
        /// <value>
        /// The amount of items in the result list.
        /// </value>
        public int Count => ResultListView.Count;

        /// <summary>
        /// Gets the amount of selected items.
        /// </summary>
        /// <value>
        /// The amount of selected items.
        /// </value>
        public int SelectedItemsCount => ResultListView.SelectedItemsCount;

        /// <summary>
        /// Clears the search text if it is not empty.
        /// </summary>
        public void ClearSearch()
        {
            if( ClearSearchTextButton.Visible )
            {
                ClearSearchTextButton.Enabled.WaitFor( TimeSpan.FromSeconds( 15 ) );
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
            Overlay.Visible.TryWaitForFalse();
        }

        /// <summary>
        /// Selects the item with the given id or name.
        /// </summary>
        /// <param name="name">The identifier.</param>
        /// <returns>true if item found, else false</returns>
        public bool SelectItem( string name, bool useId = true )
        {
            SearchText.Enabled.WaitFor( TimeSpan.FromSeconds( 15 ) );
            SearchText.Value = !useId || name.StartsWith( "id:" ) ? name : $"id:{name}";

            DoSearch();
            if( ResultListView.Count == 0 )
            {
                return false;
            }
            ResultListView.SelectedIndex = 0;
            return true;
        }

        /// <summary>
        /// Selects all items suitable for the given search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <returns>The amount of selected entries.</returns>
        public int SelectItems( string searchText )
        {
            SearchText.Enabled.WaitFor( TimeSpan.FromSeconds( 15 ) );
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
