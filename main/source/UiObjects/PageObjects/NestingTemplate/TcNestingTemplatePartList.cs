using System;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.NestingTemplate;
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.ControlObjects.Grid;

namespace HomeZone.UiObjects.PageObjects.NestingTemplate
{
    internal class TcNestingTemplatePartList : TcPageObjectBase, TiNestingTemplatePartList
    {
        private readonly Lazy<TcRegularTableView<TcNestingTemplatePartRow>> mTableView;

        public TcNestingTemplatePartList()
        {
            mTableView = new Lazy<TcRegularTableView<TcNestingTemplatePartRow>>( () => PartsGrid.GetTableView( r => new TcNestingTemplatePartRow( r ) ) );
        }

        public int PartCount => PartsGrid.RowCount;

        protected override Search SearchPattern => Search.ByUid( "CutJobTemplate.Detail.ContainedOrders" );

        private TcGridControl PartsGrid => Find<TcGridControl>( Search.ByControlName( "OrderedPartview" ) );

        public TiNestingTemplatePart GetRow( int index )
        {
            return mTableView.Value.GetRow( index );
        }
    }
}
