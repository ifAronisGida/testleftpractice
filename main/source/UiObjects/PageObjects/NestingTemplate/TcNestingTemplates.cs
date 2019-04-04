using System;
using Trumpf.Coparoo.Desktop;
using HomeZone.UiObjectInterfaces.NestingTemplate;
using HomeZone.UiObjects.PageObjects.Shell;

namespace HomeZone.UiObjects.PageObjects.NestingTemplate
{
    internal class TcNestingTemplates : TcDomain<TiNestingTemplateToolbar>, IChildOf<TcMainTabControl>, TiNestingTemplates
    {
        public override TiNestingTemplateToolbar Toolbar => On<TcNestingTemplateToolbar>( cache: true );
        public TiNestingTemplateBaseInfo BaseInfo => On<TcNestingTemplateBaseInfo>( cache: true );
        public TiNestingTemplatePartList PartList => On<TcNestingTemplatePartList>( cache: true );

        public void WaitForOverlayAppear( TimeSpan? timeout = null )
        {
            DetailOverlay.Visible.WaitFor( timeout ?? TcPageObjectSettings.Instance.NestingTemplateOverlayAppearTimeout );
        }

        public void WaitForOverlayDisappear( TimeSpan? timeout = null )
        {
            DetailOverlay.Visible.WaitForFalse( timeout ?? TcPageObjectSettings.Instance.NestingTemplateOverlayDisappearTimeout );
        }

        /// <summary>
        /// Deletes the given nesting template.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if successful</returns>
        public bool DeleteNestingTemplate( string id )
        {
            if( !ResultColumn.SelectItem( id ) )
            {
                ResultColumn.ClearSearch();
                return false;
            }

            Toolbar.Delete();
            ResultColumn.ClearSearch();
            return true;
        }

        protected override void DoGoto()
        {
            Goto<TcDomainsMore>().GotoCutJobTemplate();
        }
    }
}
