using System;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using SmartBear.TestLeft.TestObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobOrderRow
    {
        private readonly TcTableRow mRow;

        public TcCutJobOrderRow(TcTableRow row)
        {
            mRow = row;
        }

        public TcButton DrawingButton
        {
            get
            {
                return mRow.GetColumn(1).Find<TcButton>(depth: 2);
            }
        }

        public TcLinkButton PartLink
        {
            get
            {
                return mRow.GetColumn(2).Find<TcLinkButton>(depth: 2);
            }
        }

        public int Pending
        {
            get
            {
                var runElement = mRow.GetColumn(4)
                    .Find<TcReadOnlyText>(GetTextBlockPattern(), depth: 2)
                    .Find<TcReadOnlyText>(GetRunPattern(1), depth: 1);

                return int.Parse(runElement.Text);
            }
        }

        public int Total
        {
            get
            {
                var runElement = mRow.GetColumn(4)
                    .Find<TcReadOnlyText>(GetTextBlockPattern(), depth: 2)
                    .Find<TcReadOnlyText>(GetRunPattern(5), depth: 1);

                return int.Parse(runElement.Text);
            }
        }

        public TcLinkButton OrderLink
        {
            get
            {
                return mRow.GetColumn(9).Find<TcLinkButton>(depth: 2);
            }
        }

        public string Customer
        {
            get
            {
                return mRow.GetColumn(10)
                    .Find<TcReadOnlyText>(GetTextBlockPattern(), depth: 1)
                    .Text;
            }
        }

        public DateTime? TargetDate
        {
            get
            {
                var textBlock = mRow.GetColumn(11)
                    .Find<TcReadOnlyText>(GetTextBlockPattern(), depth: 1);

                if (string.IsNullOrEmpty(textBlock.Text))
                {
                    return null;
                }

                return DateTime.Parse(textBlock.Text);
            }
        }

        public TcTextEdit CuttingProgram
        {
            get
            {
                return mRow.GetColumn(12).Find<TcTextEdit>(depth: 1);
            }
        }

        public string AngularPositions
        {
            get
            {
                // should maybe do something about the degree symbol
                return mRow.GetColumn(13).Find<TcReadOnlyText>(depth: 1).Text;
            }
        }

        public string DistanceMode
        {
            get
            {
                return mRow.GetColumn(14).Find<TcReadOnlyText>(depth: 1).Text;
            }
        }

        public TcCheckBox IgnoreProcessings
        {
            get
            {
                return mRow.GetColumn(15).Find<TcCheckBox>(depth: 1);
            }
        }

        public string Note
        {
            get
            {
                return mRow.GetColumn(18).Find<TcReadOnlyText>(GetTextBlockPattern(), depth: 2).Text;
            }
        }

        private WPFPattern GetTextBlockPattern() => new WPFPattern()
        {
            ClrFullClassName = "System.Windows.Controls.TextBlock"
        };

        private WPFPattern GetRunPattern(int ordinalNo) => new WPFPattern()
        {
            ClrFullClassName = "System.Windows.Documents.Run",
            WPFControlOrdinalNo = ordinalNo
        };
    }
}
