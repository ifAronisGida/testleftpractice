using SmartBear.TestLeft.TestObjects;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The TcReadOnlyText ControlObject.
    /// </summary>
    /// <seealso cref="string" />
    public class TcReadOnlyText : TcGenericControlObject, TiValueControl<string>
    {

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text => Node.GetProperty<string>( "Text" );

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        /// <exception cref="System.NotSupportedException"></exception>
        string TiValueControl<string>.Value
        {
            get => Text;
            set => throw new System.NotSupportedException();
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="TcTextEdit"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        bool TiValueControl<string>.Enabled => Node.Cast<ITextEdit>().Enabled;

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        bool TiValueControl<string>.IsReadOnly
        {
            get => Node.GetProperty<bool>( "IsReadOnly" );
        }
    }
}
