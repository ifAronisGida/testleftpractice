using HomeZone.UiObjectInterfaces.Common;


namespace HomeZone.UiObjectInterfaces.PartOrder
{
    public interface TiPartOrderToolbar : TiVisibility
    {
        bool CanSave { get; }
        bool CanDelete { get; }

        void New();
        void Save();
        void Delete();
    }
}
