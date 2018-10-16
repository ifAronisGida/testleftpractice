using System;
using PageObjectInterfaces.NestingTemplate;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.NestingTemplate
{
    internal class TcNestingTemplates : TcDomain, IChildOf<TcMainTabControl>, TiNestingTemplates
    {
        public TiNestingTemplateToolbar Toolbar => On<TcNestingTemplateToolbar>(cache: true);
        public TiNestingTemplateBaseInfo BaseInfo => On<TcNestingTemplateBaseInfo>(cache: true);

        private TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );

        public override void Goto()
        {
            if( Toolbar.IsVisible )
            {
                return;
            }

            Goto<TcDomainsMore>().GotoCutJobTemplate();
        }

        public void WaitForOverlayDisappear( TimeSpan timeout )
        {
            DetailOverlay.Visible.WaitForFalse( timeout );
        }
    }
}
