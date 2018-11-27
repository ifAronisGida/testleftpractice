using System;
using HomeZone.UiObjectInterfaces.Controls;

namespace HomeZone.UiObjectInterfaces.CutJob
{
    public interface TiCutJobOrderRow
    {
        string AngularPositions { get; }
        string Customer { get; }
        string CuttingProgram { get; }
        string DistanceMode { get; }
        TiButton DrawingButton { get; }
        TiValueControl<bool> IgnoreProcessings { get; }
        int NestingPriority { get; }
        string Note { get; }
        TiButton OrderLink { get; }
        TiButton PartLink { get; }
        int Pending { get; }
        int SamplePartsCount { get; }
        DateTime? TargetDate { get; }
        int Total { get; }
        //string Min { get; }
        //string Current { get; }
        //string Max { get; }

    }
}
