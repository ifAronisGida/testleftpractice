using TestLeft.TestLeftBase.ControlObjects.Grid;
using SmartBear.TestLeft.TestObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobOrderRow
    {
        private readonly TcTableRow mRow;

        public TcCutJobOrderRow(TcTableRow row)
        {
            mRow = row;
        }

        public int Pending
        {
            get
            {
                var column = mRow.GetColumn(4);

                var runElement = column.Find<TcReadOnlyText>(new WPFPattern()
                {
                    ClrFullClassName = "System.Windows.Controls.TextBlock"
                }, depth: 2)
                .Find<TcReadOnlyText>(new WPFPattern()
                {
                    ClrFullClassName = "System.Windows.Documents.Run",
                    WPFControlOrdinalNo = 1
                }, depth: 1);

                return int.Parse(runElement.Text);
            }
        }

        public int Total
        {
            get
            {
                var column = mRow.GetColumn(4);

                var runElement = column.Find<TcReadOnlyText>(new WPFPattern()
                {
                    ClrFullClassName = "System.Windows.Controls.TextBlock"
                }, depth: 2)
                .Find<TcReadOnlyText>(new WPFPattern()
                {
                    ClrFullClassName = "System.Windows.Documents.Run",
                    WPFControlOrdinalNo = 5
                }, depth: 1);

                return int.Parse(runElement.Text);
            }
        }
    }
}
