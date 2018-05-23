using DevExpress.Xpf.Grid.LookUp;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.PageObjects.WPF;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The LookUpEdit ControlObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.WPF.ViewControlObject{DevExpress.Xpf.Grid.LookUp.LookUpEdit}" />
    public class TcLookUpEdit : ViewControlObject<LookUpEdit>
    {
        protected override Search SearchPattern => Search.Any;

        /// <summary>
        /// Gets or sets the text of the LookUpEdit.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get
            {
                return Node.Cast<IWPFTextEdit>().GetText();
            }
            set
            {
                Node.Cast<IWPFTextEdit>().SetText( value );
            }
        }
    }
}
