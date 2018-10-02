namespace PageObjectInterfaces.PartOrder
{
    public interface TiPartOrderToolbar
    {
        bool CanSave { get; }
        bool CanDelete { get; }

        void New();
        void Delete();
    }
}
