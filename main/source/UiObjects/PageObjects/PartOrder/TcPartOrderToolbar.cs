using System;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.PartOrder;
using HomeZone.UiObjects.PageObjects.Dialogs;

namespace HomeZone.UiObjects.PageObjects.PartOrder
{
    public class TcPartOrderToolbar : TcToolbar, TiPartOrderToolbar
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrder.Toolbar" );

        private TiButton NewPartOrderButton => Find<TiButton>( "PartOrder.Toolbar.New" );
        private TiButton ImportButton => Find<TiButton>( "PartOrder.Toolbar.Import" );
        //private TiButton DuplicateButton => Find<TiButton>( "PartOrder.Toolbar.Duplicate" );
        //private TiButton BoostButton => Find<TiButton>("PartOrder.Toolbar.Calculate" );
        //private TiButton CreateCutJobButton => Find<TiButton>( "PartOrder.Toolbar.CreateCutJob" );
        //private TiButton MoveToArchiveButton => Find<TiButton>( "PartOrder.Toolbar.MoveToArchive" );
        //private TiButton RemoveFromArchiveButton => Find<TiButton>( "PartOrder.Toolbar.RemoveFromArchive" );

        public TcPartOrderToolbar()
        {
            SaveButton = new Lazy<TiButton>( () => Find<TiButton>( "PartOrder.Toolbar.Save" ) );
            RevertButton = new Lazy<TiButton>( () => Find<TiButton>( "PartOrder.Toolbar.Revert" ) );
            DeleteButton = new Lazy<TiButton>( () => Find<TiButton>( "PartOrder.Toolbar.Delete" ) );
        }

        public void New()
        {
            NewPartOrderButton.Click();
        }

        public void Import( string fileName )
        {
            ImportButton.Click();

            On<TcOpenFileDialog>().SetFilename( fileName );
        }
    }
}
