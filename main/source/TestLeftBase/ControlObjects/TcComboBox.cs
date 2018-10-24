using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The ComboBox ControlObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.WPF.ControlObject" />
    public class TcComboBox : ControlObject
    {
        protected override Search SearchPattern => Search.Any;

        /// <summary>
        /// Opens the drop down (ClickItem can be called directly without calling DropDown first).
        /// </summary>
        public void DropDown()
        {
            Node.Cast<IComboBox>().DropDown();
        }

        /// <summary>
        /// Clicks the item with the given index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        public void ClickItem( int itemIndex )
        {
            Node.SetProperty( "SelectedIndex", itemIndex );
        }

        /// <summary>
        /// Clicks the item with the given caption.
        /// </summary>
        /// <param name="itemText">The item text.</param>
        public void ClickItem( string itemText )
        {
            Node.SetProperty( "Text", itemText );
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <returns>The text inside of the ComboBox.</returns>
        public string GetText()
        {
            return Node.GetProperty<string>( "Text" );
        }

        /// <summary>
        /// Clears the combo box.
        /// </summary>
        public void Clear()
        {
            Node.SetProperty( "SelectedItem", null );
        }
    }
}
