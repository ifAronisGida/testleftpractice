using System;
using PageObjectInterfaces.NestingTemplate;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.NestingTemplate
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
