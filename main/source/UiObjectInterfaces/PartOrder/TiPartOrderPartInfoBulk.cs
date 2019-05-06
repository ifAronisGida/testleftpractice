using HomeZone.UiObjectInterfaces.Part;

namespace HomeZone.UiObjectInterfaces.PartOrder
{
    public interface TiPartOrderPartInfoBulk
    {
        TiPartBulkDetailDesign Design { get; }
        TiPartOrderBulkPartBend Bend { get; }
    }
}
