using SmartBear.TestLeft.TestObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    public class TcLinkButton : TcButton
    {
        public string Label
        {
            get
            {
                var textBlock = Find<TcReadOnlyText>(new WPFPattern()
                {
                    ClrFullClassName = "System.Windows.Controls.TextBlock"
                }, depth: 1);

                return textBlock.Text;
            }
        }
    }
}
