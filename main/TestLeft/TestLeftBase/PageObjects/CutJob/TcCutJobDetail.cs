using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobDetail : PageObject, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail" );

        private TcReadOnlyText DateText => Find<TcReadOnlyText>( Search.ByUid( "CutJob.Detail.Base.FinishDate" ) );
        private TcTextEdit IdTextEdit => Find<TcTextEdit>( Search.ByUid( "CutJob.Detail.Base.Name" ) );
        private TcComboBox RawMaterialComboBox => Find<TcComboBox>( Search.ByUid( "CutJob.Detail.Base.RawMaterial.ComboBoxEdit" ) );
        private TcTruIconButton OpenRawMaterialSelectionDlg => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.Base.RawMaterial.OpenSelectionDialog" ) );

        public DateTime? FinishDate
        {
            get
            {
                if( string.IsNullOrEmpty( DateText.Text ) )
                {
                    return null;
                }

                return DateTime.Parse( DateText.Text );
            }
        }

        public string RawMaterial => RawMaterialComboBox.GetText();

        public string Id
        {
            get => IdTextEdit.Text;
            set => IdTextEdit.Text = value;
        }

        public void SelectRawMaterial( int index )
        {
            RawMaterialComboBox.ClickItem( index );
        }

        public void SelectRawMaterial( string name )
        {
            RawMaterialComboBox.ClickItem( name );
        }

        public void ClearRawMaterial()
        {
            RawMaterialComboBox.Clear();
        }
    }
}
