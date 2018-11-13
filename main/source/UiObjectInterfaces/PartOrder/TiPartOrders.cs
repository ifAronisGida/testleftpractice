using HomeZone.UiObjectInterfaces.Common;


namespace HomeZone.UiObjectInterfaces.PartOrder
{
    public interface TiPartOrders : TiDomain
    {
        TiPartOrderToolbar Toolbar { get; }
        TiPartOrderBaseInfo BaseInfo { get; }
        TiPartOrderPartInfo PartInfo { get; }
    }
}
