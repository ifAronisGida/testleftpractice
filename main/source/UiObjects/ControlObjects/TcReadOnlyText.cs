using Trumpf.Coparoo.Desktop.WPF;


namespace UiObjects.ControlObjects
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
        /// <value>
        /// The text.
        /// </value>
        public string Text => Node.GetProperty<string>( "Text" );
    }
}
