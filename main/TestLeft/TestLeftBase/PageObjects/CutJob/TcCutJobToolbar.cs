using PageObjectInterfaces.Controls;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobToolbar : TcPageObjectBase, IChildOf<TcToolbars>
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Toolbar" );

        public TiButton NewCutJobButton => Find<TiButton>( "CutJob.Toolbar.New" );
        public TiButton CreateCutJobTemplateButton => Find<TiButton>( "CutJob.Toolbar.CreateTemplate" );
        public TiButton ExportButton => Find<TiButton>( "CutJob.Toolbar.Export" );
        public TiButton SaveButton => Find<TiButton>( "CutJob.Toolbar.Save" );
        public TiButton RevertButton => Find<TiButton>("CutJob.Toolbar.Revert" );
        public TiButton DeleteButton => Find<TiButton>( "CutJob.Toolbar.Delete" );
        public TiButton MoveToArchiveButton => Find<TiButton>( "CutJob.Toolbar.MoveToArchive" );
        public TiButton RemoveFromArchiveButton => Find<TiButton>( "CutJob.Toolbar.RemoveFromArchive" );
    }
}
