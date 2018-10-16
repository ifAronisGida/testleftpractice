using PageObjectInterfaces.Controls;
using PageObjectInterfaces.NestingTemplate;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.NestingTemplate
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
