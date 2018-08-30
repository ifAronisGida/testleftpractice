using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The ControlObject for list views.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.WPF.ControlObject" />
    public class TcListView : ControlObject
    {
        protected override Search SearchPattern => Search.Any;

        public int Count => Node.GetProperty<int>( "Items.Count" );

        /// <summary>
        /// Gets or sets the index of the selected item.
        /// </summary>
        /// <value>
        /// The index of the selected item.
        /// </value>
        public int SelectedIndex
        {
            get { return Node.GetProperty<int>( "SelectedIndex" ); }
            set { Node.SetProperty( "SelectedIndex", value ); }
        }

        /// <summary>
        /// Selects all items.
        /// </summary>
        /// <returns>The amount of selected items.</returns>
        public int SelectAll()
        {
            Node.CallMethod( "SelectAll" );
            return Count;
        }
    }
}
