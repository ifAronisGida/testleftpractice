using PageObjectInterfaces.Controls;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrderToolbar : PageObjectBase, IChildOf<TcToolbars>
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrder.Toolbar" );

        public TiButton NewPartOrderButton => Find<TiButton>( "PartOrder.Toolbar.New" );
        public TiButton DuplicateButton => Find<TiButton>( "PartOrder.Toolbar.Duplicate" );
        public TiButton ImportButton => Find<TiButton>( "PartOrder.Toolbar.Import" );
        public TiButton BoostButton => Find<TiButton>("PartOrder.Toolbar.Calculate" );
        public TiButton CreateCutJobButton => Find<TiButton>( "PartOrder.Toolbar.CreateCutJob" );
        public TiButton SaveButton => Find<TiButton>( "PartOrder.Toolbar.Save" );
        public TiButton RevertButton => Find<TiButton>( "PartOrder.Toolbar.Revert" );
        public TiButton DeleteButton => Find<TiButton>( "PartOrder.Toolbar.Delete" );
        public TiButton MoveToArchiveButton => Find<TiButton>( "PartOrder.Toolbar.MoveToArchive" );
        public TiButton RemoveFromArchiveButton => Find<TiButton>( "PartOrder.Toolbar.RemoveFromArchive" );
    }
}
