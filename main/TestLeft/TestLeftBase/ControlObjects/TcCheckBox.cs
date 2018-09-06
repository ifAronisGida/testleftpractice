using System.Windows.Controls;
using DevExpress.Xpf.Editors;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The CheckBox ControlObject for the built-in CheckBox and DevExpress' CheckEdit.
    /// </summary>
    public class TcCheckBox : ControlObject, TiSimpleValue<bool>
    {
        protected override Search SearchPattern =>
            Search.By<CheckBox>().OrBy<CheckEdit>();

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TcCheckBox"/> is checked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if checked; otherwise <c>false</c>.
        /// </value>
        public bool Checked
        {
            get => Node.GetProperty<bool>("IsChecked");
            set
            {
                if( value != Checked )
                {
                    Click();
                }
            }
        }

        bool TiSimpleValue<bool>.Value
        {
            get => this.Checked;
            set => this.Checked = value;
        }
    }
}
