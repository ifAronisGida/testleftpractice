using SmartBear.TestLeft.TestObjects;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The TcTextEdit ControlObject.
    /// </summary>
    public class TcTextEdit : TiValueControl<string>
    {
        private readonly IControlObject mControlObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcTextEdit"/> class.
        /// </summary>
        /// <param name="controlObject">The control object.</param>
        public TcTextEdit( IControlObject controlObject )
        {
            mControlObject = controlObject;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        string TiValueControl<string>.Value
        {
            get => mControlObject.Node.Cast<ITextEdit>().GetText();
            set => mControlObject.Node.Cast<ITextEdit>().SetText( value );
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
        }
    }
}
