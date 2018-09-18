using System.Windows.Controls;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcRawSheet : ControlObject
    {
        protected override Search SearchPattern => Search.By<ContentPresenter>();

        public TcLookUpEdit RawSheet => TcControlMapper.Map<TcLookUpEdit>( this.FindGeneric( Search.ByControlName( "rawsheetComboBox" ) ) );
        public TcSpinEdit Quantity => this.FindGeneric<TcSpinEdit>( "CutJob.Detail.JobSolution.MaxQuantity" );
        private TcTruIconButton DeleteButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.RemovePresetRawSheet" ) );

        public void Delete()
        {
            DeleteButton.Click();
        }
    }
}
