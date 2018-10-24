using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;
using UiObjectInterfaces.CutJob;
using UiObjects.Utilities;


namespace UiObjects.PageObjects.CutJob
{
    public class TcRawSheet : TiRawSheet
    {
        private readonly IControlObject mRoot;

        internal TcRawSheet( IControlObject root )
        {
            mRoot = root;
        }

        public TiValueControl<string> RawSheet => mRoot.FindMapped<TiValueControl<string>>( Search.ByControlName( "rawsheetComboBox" ) );
        public TiValueControl<int> Quantity => mRoot.FindMapped<TiValueControl<int>>( "CutJob.Detail.JobSolution.MaxQuantity" );

        private TiButton DeleteButton => mRoot.FindMapped<TiButton>( "CutJob.Detail.JobSolution.RemovePresetRawSheet" );

        public void Delete()
        {
            DeleteButton.Click();
        }
    }
}