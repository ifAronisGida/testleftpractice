using SmartBear.TestLeft.TestObjects;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The CheckBox ControlObject for the built-in CheckBox and DevExpress' CheckEdit.
    /// </summary>
    public class TcCheckBox : TiValueControl<bool>
    {
        private readonly IControlObject mControlObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcCheckBox"/> class.
        /// </summary>
        /// <param name="controlObject">The control object.</param>
        public TcCheckBox( IControlObject controlObject )
        {
            mControlObject = controlObject;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TcCheckBox"/> is checked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if checked; otherwise <c>false</c>.
        /// </value>
        public bool Checked
        {
            get => mControlObject.Node.GetProperty<bool>( "IsChecked" );
            set
            {
                if( value != Checked )
                {
                    mControlObject.Click();
                }
            }
        }

        bool TiValueControl<bool>.Value
        {
            get => Checked;
            set => Checked = value;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="TcCheckBox"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        bool TiValueControl<bool>.Enabled => mControlObject.Node.Cast<ITextEdit>().Enabled;

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        bool TiValueControl<bool>.IsReadOnly
        {
            get => mControlObject.Node.GetProperty<bool>( "IsReadOnly" );
        }
    }
}
