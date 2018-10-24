using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;
using UiObjectInterfaces.NestingTemplate;
using UiObjects.PageObjects.Dialogs;
using UiObjects.PageObjects.Shell;


namespace UiObjects.PageObjects.NestingTemplate
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
