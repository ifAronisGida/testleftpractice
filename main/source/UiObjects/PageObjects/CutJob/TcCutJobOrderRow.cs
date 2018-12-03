using System;
using System.Windows.Documents;
using DevExpress.Xpf.Editors;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.CutJob;
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.ControlObjects.Grid;
using HomeZone.UiObjects.Utilities;

namespace HomeZone.UiObjects.PageObjects.CutJob
{
    public class TcCutJobOrderRow : TiCutJobOrderRow
    {
        private readonly TcTableRow mRow;

        public TcCutJobOrderRow( TcTableRow row )
        {
            mRow = row;
        }

        public TiButton DrawingButton => mRow.FindMapped<TiButton>( "ImageLinkButton" );

        public TiButton PartLink => mRow.FindMapped<TiButton>( "PartLinkButton" );

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

        public int Min => int.Parse( mRow.GetCell( 5 ).Find<TcReadOnlyText>( Search.By<SpinEdit>(), depth: 1 ).Node.GetProperty<string>( "DisplayText" ) );
        //int.Parse( mRow
        //.Find<TcReadOnlyText>( Search.ByUid( "TargetQuantityMinDisplay" ) )
        //.Text );

        public int Current => int.Parse( mRow
            .Find<TcReadOnlyText>( Search.ByUid( "ActualQuantity" ) )
            .Text );

        public int Max => int.Parse( mRow.GetCell( 7 ).Find<TcReadOnlyText>( Search.By<TextEdit>(), depth: 1 ).Node.GetProperty<string>( "DisplayText" ) );
        //int.Parse( mRow
        //    .Find<TcReadOnlyText>( Search.ByUid( "TargetQuantityMaxDisplay" ) )
        //    .Text );

        public TiButton OrderLink => mRow.FindMapped<TiButton>( "PartOrderLinkButton" );

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

                return textBlock.Node.GetDataContextProperty<DateTime>( "Value" );
            }
        }

        public string CuttingProgram => mRow
            .Find<TcReadOnlyText>( Search.ByUid( "CuttingProgram" ) )
            .Text;

        // maybe do something about the degree symbol?
        public string AngularPositions => mRow
            .Find<TcReadOnlyText>( Search.ByUid( "PermittedNestingOrientations" ) )
            .Text;

        public string DistanceMode => mRow
            .Find<TcReadOnlyText>( Search.ByUid( "PartDistanceMode" ) )
            .Text;

        public TiValueControl<bool> IgnoreProcessings => mRow.FindMapped<TiValueControl<bool>>( "IgnoreProcessings" );

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
