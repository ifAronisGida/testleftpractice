using System;
using UiObjectInterfaces.Controls;


namespace UiObjectInterfaces.CutJob
{
    public interface TiCutJobBaseInfo
    {
        TiValueControl<string> Id { get; }
        TiValueControl<DateTime?> FinishDate { get; }
        TiValueControl<string> RawMaterial { get; }
    }
}
