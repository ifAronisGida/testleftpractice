using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.ControlObjects.Grid;

namespace TestLeft.TestLeftBase.PageObjects.Customer
{
    public class TcCustomerRow
    {
        private readonly TcTableRow mRow;

        public TcCustomerRow( TcTableRow row )
        {
            mRow = row;
        }

        public string Name => mRow.GetColumn( 0 )
            .Find<TcReadOnlyText>( depth: 1 )
            .Text;

        public string ID => mRow.GetColumn( 1 )
            .Find<TcReadOnlyText>( depth: 1 )
            .Text;

        public string Street => mRow.GetColumn( 2 )
            .Find<TcReadOnlyText>( depth: 1 )
            .Text;

        public string PostalCode => mRow.GetColumn( 3 )
            .Find<TcReadOnlyText>( depth: 1 )
            .Text;

        public string City => mRow.GetColumn( 4 )
            .Find<TcReadOnlyText>( depth: 1 )
            .Text;

        public string Country => mRow.GetColumn( 5 )
            .Find<TcReadOnlyText>( depth: 1 )
            .Text;

        public string Note => mRow.GetColumn( 6 )
            .Find<TcReadOnlyText>( depth: 1 )
            .Text;
    }
}
