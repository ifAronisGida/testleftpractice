using System;
using HomeZone.UiObjectInterfaces.Controls;

namespace HomeZone.UiObjectInterfaces.PartOrder
{
    public interface TiPartOrderBaseInfoBulk
    {
        TiValueControl<string> ID { get; }
        TiValueControl<DateTime?> FinishDate { get; }
        TiValueControl<int> QuantityValue { get; }
        TiValueControl<int> QuantityFactor { get; }
        TiValueControl<string> Customer { get; }
    }
}
