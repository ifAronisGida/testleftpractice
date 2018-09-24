using System.Windows.Controls;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcRawSheet : ControlObject
    {
        protected override Search SearchPattern => Search.By<ContentPresenter>();

        public TiValueControl<string> RawSheet => TcControlMapper.Map<TiValueControl<string>>( this.FindGeneric( Search.ByControlName( "rawsheetComboBox" ) ) );
        public TiValueControl<int> Quantity => this.FindGeneric<TiValueControl<int>>( "CutJob.Detail.JobSolution.MaxQuantity" );

        private TiButton DeleteButton => this.FindGeneric<TiButton>( "CutJob.Detail.JobSolution.RemovePresetRawSheet" );

        public void Delete()
        {
            DeleteButton.Click();
        }
    }
}
