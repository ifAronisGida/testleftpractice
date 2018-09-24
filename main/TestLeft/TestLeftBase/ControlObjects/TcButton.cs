using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    internal class TcButton : TcControl, TiButton
    {
        public TcButton( IControlObject controlObject ) : base(controlObject)
        {
        }

        public string Label
        {
            get
            {
                var label = ControlObject.Node.GetWpfControlText();

                if( string.IsNullOrEmpty( label ) )
                {
                    // if the button is a link, extract the text from the contained TextBlock
                    label = ControlObject.Node.GetProperty<string>( "Content.WPFControlText" );
                }

                return label;
            }
        }

        public void Click()
        {
            ControlObject.Click();
        }
    }
}
