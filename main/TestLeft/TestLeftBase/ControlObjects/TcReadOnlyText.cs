using System.Windows.Controls;
using System.Windows.Documents;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    public class TcReadOnlyText : ControlObject
    {
        protected override Search SearchPattern => Search.By<TextBlock>().OrBy<Run>();

        public string Text => Node.GetProperty<string>("Text");
    }
}
