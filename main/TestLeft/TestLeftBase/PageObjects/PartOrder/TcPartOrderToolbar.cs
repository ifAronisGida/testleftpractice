using PageObjectInterfaces.Controls;
using PageObjectInterfaces.Dialogs;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;
using PageObjectInterfaces.PartOrder;
using TestLeft.TestLeftBase.PageObjects.Dialogs;

namespace TestLeft.TestLeftBase.PageObjects.PartOrder
{
    public class TcPartOrderToolbar : TcPageObjectBase, IChildOf<TcToolbars>, TiPartOrderToolbar
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrder.Toolbar" );

        private TiButton NewPartOrderButton => Find<TiButton>( "PartOrder.Toolbar.New" );
        private TiButton DeleteButton => Find<TiButton>( "PartOrder.Toolbar.Delete" );
        private TiButton SaveButton => Find<TiButton>( "PartOrder.Toolbar.Save" );
        //private TiButton ImportButton => Find<TiButton>( "PartOrder.Toolbar.Import" );
        //private TiButton DuplicateButton => Find<TiButton>( "PartOrder.Toolbar.Duplicate" );
        //private TiButton BoostButton => Find<TiButton>("PartOrder.Toolbar.Calculate" );
        //private TiButton CreateCutJobButton => Find<TiButton>( "PartOrder.Toolbar.CreateCutJob" );
        //private TiButton RevertButton => Find<TiButton>( "PartOrder.Toolbar.Revert" );
        //private TiButton MoveToArchiveButton => Find<TiButton>( "PartOrder.Toolbar.MoveToArchive" );
        //private TiButton RemoveFromArchiveButton => Find<TiButton>( "PartOrder.Toolbar.RemoveFromArchive" );

        public bool CanSave => SaveButton.Enabled;

        public bool CanDelete => DeleteButton.Enabled;

        public void New()
        {
            NewPartOrderButton.Click();
        }

        public void Save()
        {
            SaveButton.Click();
        }

        public void Delete()
        {
            DeleteButton.Click();

            var dialog = On<TiMessageBox, TcMessageBox>();
            if( dialog.MessageBoxExists() )
            {
                dialog.Yes();
            }
        }
    }
}
