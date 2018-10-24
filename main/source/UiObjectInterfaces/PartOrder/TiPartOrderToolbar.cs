using UiObjectInterfaces.Common;


namespace UiObjectInterfaces.PartOrder
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
