using DevExpress.Xpf.Editors;
using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The TextEdit ControlObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.WPF.ViewControlObject{DevExpress.Xpf.Editors.TextEdit}" />
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
            get
            {
                return Node.Cast<ITextEdit>().GetText();
            }
            set
            {
                Node.Cast<ITextEdit>().SetText( value );
            }
        }
    }
}
