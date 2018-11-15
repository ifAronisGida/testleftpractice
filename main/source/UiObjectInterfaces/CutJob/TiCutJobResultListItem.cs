using System;

namespace HomeZone.UiObjectInterfaces.CutJob
{
    public interface TiCutJobResultListItem
    {
        string Id { get; }

        string RawMaterialMachine { get; }

        DateTime? FinishDate { get; }
    }
}
