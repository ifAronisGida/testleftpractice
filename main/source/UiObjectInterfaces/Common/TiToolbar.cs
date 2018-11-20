namespace HomeZone.UiObjectInterfaces.Common
{
    public interface TiToolbar: TiVisibility
    {
        bool CanSave { get; }
        bool CanDelete { get; }
        bool CanRevert { get; }

        void Save();
        void Delete();
        void Revert();
    }
}
