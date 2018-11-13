using System;
using HomeZone.UiObjectInterfaces.Controls;

namespace HomeZone.UiObjectInterfaces.CutJob
{
    public interface TiCutJobBaseInfo
    {
        TiValueControl<string> Id { get; }
        TiValueControl<DateTime?> FinishDate { get; }
        TiValueControl<string> RawMaterial { get; }
    }
}
