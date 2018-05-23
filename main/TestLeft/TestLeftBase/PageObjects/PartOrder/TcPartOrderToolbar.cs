using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrderToolbar : PageObject, IChildOf<TcToolbars>
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrder.Toolbar" );

        public TcTruIconButton NewPartOrderButton => Find<TcTruIconButton>( Search.ByUid( "PartOrder.Toolbar.New" ) );
        public TcTruIconButton DuplicateButton => Find<TcTruIconButton>( Search.ByUid( "PartOrder.Toolbar.Duplicate" ) );
        public TcTruIconButton ImportButton => Find<TcTruIconButton>( Search.ByUid( "PartOrder.Toolbar.Import" ) );
        public TcTruIconButton BoostButton => Find<TcTruIconButton>( Search.ByUid( "PartOrder.Toolbar.Calculate" ) );
        public TcTruIconButton CreateCutJobButton => Find<TcTruIconButton>( Search.ByUid( "PartOrder.Toolbar.CreateCutJob" ) );
        public TcTruIconButton SaveButton => Find<TcTruIconButton>( Search.ByUid( "PartOrder.Toolbar.Save" ) );
        public TcTruIconButton RevertButton => Find<TcTruIconButton>( Search.ByUid( "PartOrder.Toolbar.Revert" ) );
        public TcTruIconButton DeleteButton => Find<TcTruIconButton>( Search.ByUid( "PartOrder.Toolbar.Delete" ) );
        public TcTruIconButton MoveToArchiveButton => Find<TcTruIconButton>( Search.ByUid( "PartOrder.Toolbar.MoveToArchive" ) );
        public TcTruIconButton RemoveFromArchiveButton => Find<TcTruIconButton>( Search.ByUid( "PartOrder.Toolbar.RemoveFromArchive" ) );
    }
}
