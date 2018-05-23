using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Shell;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobToolbar : PageObject, IChildOf<TcToolbars>
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Toolbar" );

        public TcTruIconButton NewCutJobButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Toolbar.New" ) );
        public TcTruIconButton CreateCutJobTemplateButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Toolbar.CreateTemplate" ) );
        public TcTruIconButton ExportButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Toolbar.Export" ) );
        public TcTruIconButton SaveButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Toolbar.Save" ) );
        public TcTruIconButton RevertButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Toolbar.Revert" ) );
        public TcTruIconButton DeleteButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Toolbar.Delete" ) );
        public TcTruIconButton MoveToArchiveButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Toolbar.MoveToArchive" ) );
        public TcTruIconButton RemoveFromArchiveButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Toolbar.RemoveFromArchive" ) );
    }
}
