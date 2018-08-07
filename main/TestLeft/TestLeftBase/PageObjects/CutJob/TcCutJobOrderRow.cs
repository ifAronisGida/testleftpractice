using System;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using SmartBear.TestLeft.TestObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using Trumpf.PageObjects.WPF;
using System.Windows.Documents;
using DevExpress.Xpf.Editors;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobOrderRow
    {
        private readonly TcTableRow mRow;

        public TcCutJobOrderRow( TcTableRow row )
        {
            mRow = row;
        }

        public TcButton DrawingButton => mRow.Find<TcButton>( Search.ByUid( "ImageLinkButton" ) );

        public TcLinkButton PartLink => mRow.Find<TcLinkButton>( Search.ByUid( "PartLinkButton" ) );

        public int Pending
        {
            get
            {
                var runElement = mRow
                    .Find<TcReadOnlyText>( Search.ByUid( "Pending" ) )
                    .Find<TcReadOnlyText>( Search.By<Run>().AndByIndex( 0 ), depth: 1 );

                return int.Parse( runElement.Text );
            }
        }

        public int Total
        {
            get
            {
                var runElement = mRow
                    .Find<TcReadOnlyText>( Search.ByUid( "Pending" ) )
                    .Find<TcReadOnlyText>( Search.By<Run>().AndByIndex( 4 ), depth: 1 );

                return int.Parse( runElement.Text );
            }
        }

        public TcLinkButton OrderLink => mRow.Find<TcLinkButton>( Search.ByUid( "PartOrderLinkButton" ) );

        public string Customer => mRow
            .Find<TcReadOnlyText>( Search.ByUid( "CustomerName" ) )
            .Text;

        public DateTime? TargetDate
        {
            get
            {
                var textBlock = mRow.Find<TcReadOnlyText>( Search.ByUid( "FinishDate" ) );

                if( string.IsNullOrEmpty( textBlock.Text ) )
                {
                    return null;
                }

                return DateTime.Parse( textBlock.Text );
            }
        }

        public string CuttingProgram => mRow.GetColumn( 12 )
                    .Find<TcReadOnlyText>( Search.By<TextEdit>(), depth: 1 )
                    .Text;

        // maybe do something about the degree symbol?
        public string AngularPositions => mRow
            .Find<TcReadOnlyText>( Search.ByUid( "PermittedNestingOrientations" ) )
            .Text;

        public string DistanceMode => mRow
            .Find<TcReadOnlyText>( Search.ByUid( "PartDistanceMode" ) )
            .Text;

        public TcCheckBox IgnoreProcessings => mRow.GetColumn( 15 )
            .Find<TcCheckBox>( depth: 1 );

        // TODO: do something about the editability of these cells
        public int NestingPriority
        {
            get
            {
                var fakeTextEdit = mRow.GetColumn( 16 ).Find<TcReadOnlyText>( Search.By<TextEdit>(), depth: 1 );

                return int.Parse(fakeTextEdit.Text);
            }
        }

        public int SamplePartsCount
        {
            get
            {
                var fakeTextEdit = mRow.GetColumn( 17 ).Find<TcReadOnlyText>( Search.By<TextEdit>(), depth: 1 );

                return int.Parse( fakeTextEdit.Text );

            }
        }

        public string Note => mRow
            .Find<TcReadOnlyText>( Search.ByUid( "Comment" ) )
            .Text;
    }
}
