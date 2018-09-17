using System.Collections.Generic;
using SmartBear.TestLeft.TestObjects;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The LookUpEdit ControlObject.
    /// </summary>
    public class TcLookUpEdit : TiValueControl<string>
    {
        private readonly IControlObject mControlObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcLookUpEdit" /> class.
        /// </summary>
        /// <param name="controlObject">The control object.</param>
        public TcLookUpEdit( IControlObject controlObject )
        {
            mControlObject = controlObject;
        }

        /// <summary>
        /// Gets or sets the text of the LookUpEdit.
        /// </summary>
        public string Text
        {
            get => mControlObject.Node.GetProperty<string>( "Text" );
            set => mControlObject.Node.SetProperty( "Text", value );
        }

        /// <summary>
        /// Clears the selected item.
        /// </summary>
        public void Clear()
        {
            mControlObject.Node.SetProperty( "SelectedItem", null );
        }

        /// <summary>
        /// Gets the display member.
        /// </summary>
        /// <returns></returns>
        public string GetDisplayMember()
        {
            return mControlObject.Node.GetProperty<string>( "DisplayMember" );
        }

        public IEnumerable<IObject> GetItemsSource()
        {
            return mControlObject.Node.GetProperty<IObject>( "ItemsSource" ).AsEnumerable<IObject>();
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        string TiValueControl<string>.Value
        {
            get => Text;
            set => Text = value;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="TcTextEdit"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        bool TiValueControl<string>.Enabled => mControlObject.Node.Cast<ITextEdit>().Enabled;

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        bool TiValueControl<string>.IsReadOnly
        {
            get => mControlObject.Node.GetProperty<bool>( "IsReadOnly" );
            set => mControlObject.Node.SetProperty( "IsReadOnly", value );
        }
    }
}
