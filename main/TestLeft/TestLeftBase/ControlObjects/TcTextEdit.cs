using DevExpress.Xpf.Editors;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The TextEdit ControlObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.WPF.ViewControlObject{TextEdit}" />
    public class TcTextEdit : ViewControlObject<TextEdit>
    {
        protected override Search SearchPattern => Search.Any;

        /// <summary>
        /// Gets or sets the text of the TextEdit control.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get => Node.GetProperty<string>( "Text" );
            set => Node.SetProperty( "Text", value );
        }
    }
}
