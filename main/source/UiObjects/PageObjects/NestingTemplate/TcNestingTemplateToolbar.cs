using System;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.NestingTemplate;
using HomeZone.UiObjects.PageObjects.Dialogs;

namespace HomeZone.UiObjects.PageObjects.NestingTemplate
{
    internal class TcNestingTemplateToolbar : TcToolbar, TiNestingTemplateToolbar
    {
        protected override Search SearchPattern => Search.ByUid( "CutJobTemplate.Toolbar" );

        private TiButton ImportButton => Find<TiButton>( "CutJobTemplate.Toolbar.Import" );

        public TcNestingTemplateToolbar()
        {
            SaveButton = new Lazy<TiButton>( () => Find<TiButton>( "CutJobTemplate.Toolbar.Save" ) );
            RevertButton = new Lazy<TiButton>( () => Find<TiButton>( "CutJobTemplate.Toolbar.Revert" ) );
            DeleteButton = new Lazy<TiButton>( () => Find<TiButton>( "CutJobTemplate.Toolbar.Delete" ) );
        }

        public void Import( string file )
        {
            ImportButton.Click();
            On<TcOpenFileDialog>().SetFilename( file );
        }
    }
}
