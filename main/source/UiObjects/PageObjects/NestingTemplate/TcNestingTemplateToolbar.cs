using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.NestingTemplate;
using HomeZone.UiObjects.PageObjects.Dialogs;
using HomeZone.UiObjects.PageObjects.Shell;

namespace HomeZone.UiObjects.PageObjects.NestingTemplate
{
    internal class TcNestingTemplateToolbar : TcPageObjectBase, IChildOf<TcToolbars>, TiNestingTemplateToolbar
    {
        protected override Search SearchPattern => Search.ByUid( "CutJobTemplate.Toolbar" );

        private TiButton ImportButton => Find<TiButton>( "CutJobTemplate.Toolbar.Import" );

        public void Import( string file )
        {
            ImportButton.Click();
            On<TcOpenFileDialog>().SetFilename( file );
        }
    }
}
