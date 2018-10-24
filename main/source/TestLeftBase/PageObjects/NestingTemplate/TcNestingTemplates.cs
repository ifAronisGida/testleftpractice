using System;
using PageObjectInterfaces.NestingTemplate;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace TestLeft.TestLeftBase.PageObjects.NestingTemplate
{
    internal class TcNestingTemplates : TcDomain<TiNestingTemplateToolbar>, IChildOf<TcMainTabControl>, TiNestingTemplates
    {
        public override TiNestingTemplateToolbar Toolbar => On<TcNestingTemplateToolbar>( cache: true );
        public TiNestingTemplateBaseInfo BaseInfo => On<TcNestingTemplateBaseInfo>( cache: true );
        public TiNestingTemplatePartList PartList => On<TcNestingTemplatePartList>( cache: true );

        private TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );

        public void WaitForOverlayDisappear( TimeSpan timeout )
        {
            DetailOverlay.Visible.WaitForFalse( timeout );
        }

        protected override void DoGoto()
        {
            Goto<TcDomainsMore>().GotoCutJobTemplate();
        }
    }
}
