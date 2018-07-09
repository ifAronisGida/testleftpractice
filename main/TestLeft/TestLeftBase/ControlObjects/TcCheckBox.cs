using System.Windows.Controls;
using DevExpress.Xpf.Editors;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The CheckBox ControlObject for the built-in CheckBox and DevExpress' CheckEdit.
    /// </summary>
    public class TcCheckBox : ControlObject
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
            get
            {
                return Node.GetProperty<bool>("IsChecked");
            }
            set
            {
                if( value != Checked )
                {
                    Click();
                }
            }
        }
    }
}
