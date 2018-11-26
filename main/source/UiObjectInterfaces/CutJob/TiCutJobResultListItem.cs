using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.CutJob
{
    public interface TiCutJobResultListItem : TiHasStateStack
    {
        string Id { get; }

        string RawMaterialMachine { get; }

        string FinishDate { get; }

        bool IsArchived { get; }
    }
}
