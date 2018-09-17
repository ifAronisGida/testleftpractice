using System.Windows.Controls;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    public class TcLinkButton : TcButton
    {
        public string Label => TcControlMapper.Map<TcReadOnlyText>( this.FindGeneric( Search.By<TextBlock>(), depth: 1 ) ).Text;
    }
}
