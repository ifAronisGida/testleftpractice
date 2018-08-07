using System.Windows.Controls;
using TestLeft.TestLeftBase.ControlObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcRawSheet : ControlObject
    {
        protected override Search SearchPattern => Search.By<ContentPresenter>();

        public TcLookUpEdit RawSheet => Find<TcLookUpEdit>( Search.ByControlName( "rawsheetComboBox" ) );
        public TcSpinEdit Quantity => Find<TcSpinEdit>( Search.ByUid( "CutJob.Detail.JobSolution.MaxQuantity" ) );
        private TcTruIconButton DeleteButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.RemovePresetRawSheet" ) );

        public void Delete()
        {
            DeleteButton.Click();
        }
    }
}
