using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Dialogs;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Shell;
using TcTruIconButton = Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects.TcTruIconButton;


namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobContainedOrders : PageObject, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail.ContainedOrders" );

        internal TcTruIconButton SelectButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.ContainedOrders.Select" ) );

        internal TcTruIconButton RemoveButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.ContainedOrders.Remove" ) );

        internal TcGridControl PartOrdersGrid => Find<TcGridControl>( Search.ByUid( "CutJob.Detail.ContainedOrders.PartOrders" ) );

        public int PartOrdersCount
        {
            get
            {
                return PartOrdersGrid.RowCount;
            }
        }

        public void UnSelectAllPartOrders()
        {
            PartOrdersGrid.UnselectAll();
        }

        public void SelectPartOrder( int index )
        {
            PartOrdersGrid.SelectItem( index );
        }

        public void AddPartOrder()
        {
            SelectButton.Click();
        }

        public void RemovePartOrder()
        {
            if( RemoveButton.Enabled )
            {
                RemoveButton.Click();

                var dialog = On<TcMessageBox>();
                if( dialog.MessageBoxExists() )
                {
                    dialog.Yes();
                }
            }
        }
        
    }
}
