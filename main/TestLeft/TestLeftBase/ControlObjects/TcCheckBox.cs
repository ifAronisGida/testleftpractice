using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The CheckBox ControlObject for the built-in CheckBox and DevExpress' CheckEdit.
    /// </summary>
    internal class TcCheckBox : TcControl, TiValueControl<bool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TcCheckBox"/> class.
        /// </summary>
        /// <param name="controlObject">The control object.</param>
        public TcCheckBox( IControlObject controlObject ) : base(controlObject)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TcCheckBox"/> is checked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if checked; otherwise <c>false</c>.
        /// </value>
        public bool Value
        {
            get => ControlObject.Node.GetProperty<bool>( "IsChecked" );
            set
            {
                if( value != Value )
                {
                    ControlObject.Click();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        public bool IsReadOnly
        {
            get => ControlObject.Node.GetProperty<bool>( "IsReadOnly" );
        }
    }
}
