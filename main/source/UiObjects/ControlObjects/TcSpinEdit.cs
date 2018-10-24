using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;


namespace UiObjects.ControlObjects
{
    internal class TcSpinEdit : TcControl, TiValueControl<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TcSpinEdit"/> class.
        /// </summary>
        /// <param name="controlObject">The control object.</param>
        public TcSpinEdit( IControlObject controlObject ) : base(controlObject)
        {
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value
        {
            get => ControlObject.Node.GetProperty<int>( "Value" );
            set => ControlObject.Node.SetProperty( "Value", value );
        }

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        bool TiValueControl<int>.IsReadOnly
        {
            get => ControlObject.Node.GetProperty<bool>( "IsReadOnly" );
        }
    }
}
