using System.Windows.Controls;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    public class TcLinkButton : TcButton
    {
        public string Label
        {
            get
            {
                return Find<TcReadOnlyText>( Search.By<TextBlock>(), depth: 1 ).Text;
            }
        }
    }
}
