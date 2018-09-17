using SmartBear.TestLeft.TestObjects;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    public class TcSpinEdit : TiValueControl<int>
    {
        private readonly IControlObject mControlObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcSpinEdit"/> class.
        /// </summary>
        /// <param name="controlObject">The control object.</param>
        public TcSpinEdit( IControlObject controlObject )
        {
            mControlObject = controlObject;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value
        {
            get => mControlObject.Node.GetProperty<int>( "Value" );
            set => mControlObject.Node.SetProperty( "Value", value );
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="TcTextEdit"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        bool TiValueControl<int>.Enabled => mControlObject.Node.Cast<ITextEdit>().Enabled;

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        bool TiValueControl<int>.IsReadOnly
        {
            get => mControlObject.Node.GetProperty<bool>( "IsReadOnly" );
            set => mControlObject.Node.SetProperty( "IsReadOnly", value );
        }
    }
}
