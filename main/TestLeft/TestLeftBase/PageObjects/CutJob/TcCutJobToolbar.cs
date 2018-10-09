using PageObjectInterfaces.Controls;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;
using PageObjectInterfaces.CutJob;
using TestLeft.TestLeftBase.PageObjects.Dialogs;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobToolbar : TcPageObjectBase, IChildOf<TcToolbars>, TiCutJobToolbar
    {
        public bool CanSave => SaveButton.Enabled;
        public bool CanDelete => DeleteButton.Enabled;
        public bool CanRevert => RevertButton.Enabled;

        protected override Search SearchPattern => Search.ByUid( "CutJob.Toolbar" );

        private TiButton NewCutJobButton => Find<TiButton>( "CutJob.Toolbar.New" );
        private TiButton SaveButton => Find<TiButton>( "CutJob.Toolbar.Save" );
        private TiButton DeleteButton => Find<TiButton>( "CutJob.Toolbar.Delete" );
        private TiButton RevertButton => Find<TiButton>( "CutJob.Toolbar.Revert" );

        public void New()
        {
            NewCutJobButton.Click();
        }

        public void Save()
        {
            SaveButton.Click();
        }

        public void Delete()
        {
            DeleteButton.Click();

            var dialog = On<TcMessageBox>();
            if( dialog.MessageBoxExists() )
            {
                dialog.Yes();
            }

        }

        public void Revert()
        {
            RevertButton.Click();
        }

        //public TiButton CreateCutJobTemplateButton => Find<TiButton>( "CutJob.Toolbar.CreateTemplate" );
        //public TiButton ExportButton => Find<TiButton>( "CutJob.Toolbar.Export" );
        //public TiButton MoveToArchiveButton => Find<TiButton>( "CutJob.Toolbar.MoveToArchive" );
        //public TiButton RemoveFromArchiveButton => Find<TiButton>( "CutJob.Toolbar.RemoveFromArchive" );
    }
}
