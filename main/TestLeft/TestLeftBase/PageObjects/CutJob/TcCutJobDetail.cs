using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.Utilities;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobDetail : PageObject, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail" );

        private TcReadOnlyText DateText => TcControlMapper.Map<TcReadOnlyText>( this.FindGeneric( Search.ByUid( "CutJob.Detail.Base.FinishDate" ) ) );
        public TiValueControl<string> Id => this.FindGeneric<TiValueControl<string>>( "CutJob.Detail.Base.Name" );
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
