using DevExpress.Xpf.Editors;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The TextEdit ControlObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.WPF.ViewControlObject{TextEdit}" />
    public class TcTextEdit : ViewControlObject<TextEdit>, TiSimpleValue<string>
    {
        protected override Search SearchPattern => Search.Any;

        /// <summary>
        /// Gets or sets the text of the TextEdit control.
        /// </summary>
        public string Text
        {
            get => Node.GetProperty<string>( "Text" );
            set => Node.SetProperty( "Text", value );
        }

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        public bool IsReadOnly
        {
            get => Node.GetProperty<bool>( "IsReadOnly" );
        }

        string TiSimpleValue<string>.Value
        {
            get => this.Text;
            set => this.Text = value;
        }
    }
}
