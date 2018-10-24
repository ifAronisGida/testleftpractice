using UiObjectInterfaces.Common;


namespace UiObjectInterfaces.CutJob
{
    public interface TiCutJobToolbar : TiVisibility
    {
        bool CanSave { get; }
        bool CanDelete { get; }
        bool CanRevert { get; }

        void New();
        void Save();
        void Delete();
        void Revert();
    }
}
