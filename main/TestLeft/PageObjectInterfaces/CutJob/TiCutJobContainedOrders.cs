namespace PageObjectInterfaces.CutJob
{
    public interface TiCutJobContainedOrders
    {
        int PartOrdersCount { get; }

        void AddPartOrder();
        TiCutJobOrderRow GetRow( int index );
        void RemovePartOrder();
        void SelectPartOrder( int index );
        void UnSelectAllPartOrders();
    }
}
