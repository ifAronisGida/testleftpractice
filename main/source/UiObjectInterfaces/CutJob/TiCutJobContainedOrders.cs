namespace HomeZone.UiObjectInterfaces.CutJob
{
    public interface TiCutJobContainedOrders
    {
        int PartOrdersCount { get; }
        string StateToolTip { get; }

        void AddPartOrder( string orderId );
        TiCutJobOrderRow GetRow( int index );
        void RemovePartOrder();
        void SelectPartOrder( int index );
        void UnSelectAllPartOrders();
    }
}
