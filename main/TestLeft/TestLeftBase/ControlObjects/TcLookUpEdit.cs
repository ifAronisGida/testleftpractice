using System.Collections.Generic;
using DevExpress.Xpf.Grid.LookUp;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The LookUpEdit ControlObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.WPF.ViewControlObject{DevExpress.Xpf.Grid.LookUp.LookUpEdit}" />
    public class TcLookUpEdit : ViewControlObject<LookUpEdit>
    {
        /// <summary>
        /// Gets or sets the text of the LookUpEdit.
        /// </summary>
        public string Text
        {
            get
            {
                return Node.Cast<IWPFTextEdit>().wText;
            }
            set
            {
                Node.Cast<IWPFTextEdit>().SetText( value );
            }
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
