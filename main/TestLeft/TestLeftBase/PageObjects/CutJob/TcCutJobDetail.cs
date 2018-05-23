using System;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.Win;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TcTruIconButton = TestLeft.TestLeftBase.ControlObjects.TcTruIconButton;


namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobDetail : PageObject, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail" );

        internal TcGroupPanel mDetailGroupPanel => Find<TcGroupPanel>( Search.ByUid( "CutJob.Detail.Base" ) );

        internal TcTextEdit mDateTextEdit => Find<TcTextEdit>( Search.ByUid( "CutJob.Detail.Base.FinishDate" ) );
        
        internal TcTextEdit mIdTextEdit => Find<TcTextEdit>( Search.ByUid( "CutJob.Detail.Base.Name" ) );

        internal TcComboBox RawMaterialComboBox => Find<TcComboBox>( Search.ByUid( "CutJob.Detail.Base.RawMaterial.ComboBoxEdit" ) );

        internal TcTruIconButton mOpenRawMaterialSelectionDlg => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.Base.RawMaterial.OpenSelectionDialog" ) );


        public string FinishDate
        {
            get { return mDateTextEdit.Text; }
        }

        public string Id
        {
            set { mIdTextEdit.Text = value; }
            get { return mIdTextEdit.Text; }
        }

        public void SelectRawMaterial( int index )
        {
            RawMaterialComboBox.ClickItem( index );
        }

        public string GetRawMaterial()
        {
            return RawMaterialComboBox.GetText();
        }


    }
}
