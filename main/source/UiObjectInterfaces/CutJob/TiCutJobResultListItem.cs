namespace HomeZone.UiObjectInterfaces.CutJob
{
    public interface TiCutJobResultListItem
    {
        string Id { get; }

        string RawMaterialMachine { get; }

        string FinishDate { get; }

        bool IsArchived { get; }
    }
}
