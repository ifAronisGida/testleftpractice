using System;
using HomeZone.UiObjectInterfaces.Controls;

namespace HomeZone.UiObjectInterfaces.PartOrder
{
    public interface TiPartOrderBaseInfo
    {
        TiValueControl<string> Customer { get; }
        TiValueControl<DateTime?> FinishDate { get; }
        TiValueControl<string> ID { get; }
        TiValueControl<int> Quantity { get; }

        // expand on access:
        TiValueControl<string> CustomerOrderNumber { get; }
        TiValueControl<string> ExternalAssembly { get; }
        TiValueControl<bool> IsArchivable { get; }
        TiValueControl<bool> IsFiller { get; }
        TiValueControl<string> OrderCategory { get; }
        TiValueControl<string> RawMaterial { get; }
    }
}