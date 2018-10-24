using System;
using PageObjectInterfaces.Controls;

namespace PageObjectInterfaces.CutJob
{
    public interface TiCutJobBaseInfo
    {
        TiValueControl<string> Id { get; }
        TiValueControl<DateTime?> FinishDate { get; }
        TiValueControl<string> RawMaterial { get; }
    }
}
