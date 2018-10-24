using PageObjectInterfaces.Common;

namespace PageObjectInterfaces.PartOrder
{
    public interface TiPartOrders : TiDomain
    {
        TiPartOrderToolbar Toolbar { get; }
        TiPartOrderBaseInfo BaseInfo { get; }
        TiPartOrderPartInfo PartInfo { get; }
    }
}
