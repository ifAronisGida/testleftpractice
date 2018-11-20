using System;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.CutJob;

namespace HomeZone.UiObjects.PageObjects.CutJob
{
    public class TcCutJobToolbar : TcToolbar, TiCutJobToolbar
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Toolbar" );

        private TiButton NewCutJobButton => Find<TiButton>( "CutJob.Toolbar.New" );

        public TcCutJobToolbar()
        {
            SaveButton = new Lazy<TiButton>( () => Find<TiButton>( "CutJob.Toolbar.Save" ) );
            RevertButton = new Lazy<TiButton>( () => Find<TiButton>( "CutJob.Toolbar.Revert" ) );
            DeleteButton = new Lazy<TiButton>( () => Find<TiButton>( "CutJob.Toolbar.Delete" ) );
        }

        public void New()
        {
            NewCutJobButton.Click();
        }

        //public TiButton CreateCutJobTemplateButton => Find<TiButton>( "CutJob.Toolbar.CreateTemplate" );
        //public TiButton ExportButton => Find<TiButton>( "CutJob.Toolbar.Export" );
        //public TiButton MoveToArchiveButton => Find<TiButton>( "CutJob.Toolbar.MoveToArchive" );
        //public TiButton RemoveFromArchiveButton => Find<TiButton>( "CutJob.Toolbar.RemoveFromArchive" );
    }
}
