using UiObjectInterfaces.Common;


namespace UiObjectInterfaces.PartOrder
{
    public interface TiPartOrders : TiDomain
    {
        TiPartOrderToolbar Toolbar { get; }
        TiPartOrderBaseInfo BaseInfo { get; }
        TiPartOrderPartInfo PartInfo { get; }
    }
}
