using System.Collections.Generic;
using SmartBear.TestLeft.TestObjects;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The LookUpEdit ControlObject.
    /// </summary>
    public class TcLookUpEdit : ControlObject
    {
        protected override Search SearchPattern => Search.Any;

        /// <summary>
        /// Gets or sets the text of the LookUpEdit.
        /// </summary>
        public string Text
        {
            get => Node.GetProperty<string>( "Text" );
            set => Node.SetProperty( "Text", value );
        }

        public void Clear()
        {
            Node.SetProperty( "SelectedItem", null );
        }

        public string GetDisplayMember()
        {
            return Node.GetProperty<string>( "DisplayMember" );
        }

        public IEnumerable<IObject> GetItemsSource()
        {
            return Node.GetProperty<IObject>( "ItemsSource" ).AsEnumerable<IObject>();
        }
    }
}
