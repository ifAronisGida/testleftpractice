using System.Windows.Controls;
using DevExpress.Xpf.Editors;
using PageObjectInterfaces.Controls;
using PageObjectInterfaces.NestingTemplate;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.NestingTemplate
{
    internal class TcNestingTemplatePartRow : TiNestingTemplatePart
    {
        private readonly TcTableRow mRow;

        public TcNestingTemplatePartRow(TcTableRow row)
        {
            mRow = row;
        }

        public TiButton PartLink => mRow.GetCell( 1 ).FindMapped<TiButton>( Search.By<Button>(), depth: 2 );

        public int Quantity
        {
            get
            {
                var text = mRow.GetCell( 2 )
                    .Find<TcReadOnlyText>( Search.By<TextBlock>() )
                    .Text;

                return int.Parse( text );
            }
        }

        public string CuttingProgram
        {
            get
            {
                return mRow.GetCell( 3 ).Find<TcReadOnlyText>( Search.By<TextEdit>() ).Text;
            }
        }
    }
}
