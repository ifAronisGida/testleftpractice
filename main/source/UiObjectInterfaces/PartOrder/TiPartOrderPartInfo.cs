using HomeZone.UiObjectInterfaces.Part;

namespace HomeZone.UiObjectInterfaces.PartOrder
{
    public interface TiPartOrderPartInfo
    {
        TiPartSingleDetailDesign Design { get; }

        void SelectPart( string partId );
    }
}
