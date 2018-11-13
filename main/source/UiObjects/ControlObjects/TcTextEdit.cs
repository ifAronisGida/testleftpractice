using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;


namespace HomeZone.UiObjects.ControlObjects
{
    /// <summary>
    /// Represents a value control for text edit-like controls.
    /// </summary>
    internal class TcTextEdit : TcControl, TiValueControl<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TcTextEdit"/> class.
        /// </summary>
        /// <param name="controlObject">The control object.</param>
        public TcTextEdit( IControlObject controlObject ) : base(controlObject)
        {
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        string TiValueControl<string>.Value
        {
            get => ControlObject.Node.Cast<ITextEdit>().GetText();
            set => ControlObject.Node.Cast<ITextEdit>().SetText( value );
        }

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        bool TiValueControl<string>.IsReadOnly
        {
            get => ControlObject.Node.GetProperty<bool>( "IsReadOnly" );
        }
    }
}
