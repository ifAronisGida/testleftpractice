using HomeZone.UiObjects.ControlObjects.Grid;

namespace HomeZone.UiObjects.PageObjects.Customer
{
    public class TcCustomerRow
    {
        private readonly TcOptimizedTableRow mRow;

        public TcCustomerRow( TcOptimizedTableRow row )
        {
            mRow = row;
        }

        public string Name => mRow.GetContent( 0 );
        public string ID => mRow.GetContent( 1 );
        public string Street => mRow.GetContent( 2 );
        public string PostalCode => mRow.GetContent( 3 );
        public string City => mRow.GetContent( 4 );
        public string Country => mRow.GetContent( 5 );
        public string Note => mRow.GetContent( 6 );
    }
}
