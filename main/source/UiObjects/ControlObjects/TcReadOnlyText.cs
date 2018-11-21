using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.ControlObjects
{
    /// <summary>
    /// The TcReadOnlyText ControlObject.
    /// </summary>
    /// <seealso cref="string" />
    internal class TcReadOnlyText : ControlObject
    {
        protected override Search SearchPattern => Search.Any;

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <remarks>
        /// It's necessary to use GetWpfControlText() in some cases. TcReadOnlyText mainly wraps a TextBlock,
        /// but a TextBlock may have a child Run element that actually contains the text in which case TextBlock.Text is empty.
        /// By using GetWpfControlText() it doesn't matter if it's directly the TextBlock or a child Run element that contains the text.
        /// The method will return the "correct" thing as far as I could see.
        /// </remarks>
        /// <value>
        /// The text.
        /// </value>
        public string Text => Node.GetWpfControlText();
    }
}
