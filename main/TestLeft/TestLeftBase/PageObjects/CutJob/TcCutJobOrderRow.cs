using System;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using TestLeft.TestLeftBase.ControlObjects;
using Trumpf.PageObjects.WPF;
using System.Windows.Documents;
using DevExpress.Xpf.Editors;
using TestLeft.TestLeftBase.Utilities;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobOrderRow
    {
        private readonly TcTableRow mRow;

        public TcCutJobOrderRow( TcTableRow row )
        {
            mRow = row;
        }

        public TiButton DrawingButton => mRow.FindGeneric<TiButton>( "ImageLinkButton" );

        public TiButton PartLink => mRow.FindGeneric<TiButton>( "PartLinkButton" );

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

        public TiButton OrderLink => mRow.FindGeneric<TiButton>( "PartOrderLinkButton" );

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

        public string CuttingProgram => mRow.GetCell( 12 )
                    .Find<TcReadOnlyText>( Search.By<TextEdit>(), depth: 1 )
                    .Text;

        // maybe do something about the degree symbol?
        public string AngularPositions => mRow
            .Find<TcReadOnlyText>( Search.ByUid( "PermittedNestingOrientations" ) )
            .Text;

        public string DistanceMode => mRow
            .Find<TcReadOnlyText>( Search.ByUid( "PartDistanceMode" ) )
            .Text;

        public TiValueControl<bool> IgnoreProcessings =>
             TcControlMapper.Map<TiValueControl<bool>>( mRow.GetCell( 15 ).FindGeneric( Search.Any, depth: 1 ) );

        // TODO: do something about the editability of these cells
        public int NestingPriority
        {
            get
            {
                var fakeTextEdit = mRow.GetCell( 16 ).Find<TcReadOnlyText>( Search.By<TextEdit>(), depth: 1 );

                return int.Parse( fakeTextEdit.Text );
            }
        }

        public int SamplePartsCount
        {
            get
            {
                var fakeTextEdit = mRow.GetCell( 17 ).Find<TcReadOnlyText>( Search.By<TextEdit>(), depth: 1 );

                return int.Parse( fakeTextEdit.Text );

            }
        }

        public string Note => mRow
            .Find<TcReadOnlyText>( Search.ByUid( "Comment" ) )
            .Text;
    }
}
