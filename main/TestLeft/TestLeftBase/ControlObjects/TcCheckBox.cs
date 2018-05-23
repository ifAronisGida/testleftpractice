using DevExpress.Xpf.Editors;
using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects.WPF;


namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The CheckBox ControlObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.WPF.ViewControlObject{DevExpress.Xpf.Editors.CheckEdit}" />
    public class TcCheckBox : ViewControlObject<CheckEdit>
    {
        protected override Search SearchPattern => Search.Any;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TcCheckBox"/> is checked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if checked; otherwise, <c>false</c>.
        /// </value>
        public bool Checked
        {
            get
            {
                return Node.Cast<ICheckBox>().wState == CheckState.Checked;
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
