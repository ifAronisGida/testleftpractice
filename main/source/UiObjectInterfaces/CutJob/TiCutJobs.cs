using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.CutJob
{
    public interface TiCutJobs : TiDomain
    {
        TiCutJobToolbar Toolbar { get; }
        TiCutJobBaseInfo BaseInfo { get; }
        TiCutJobContainedOrders ContainedOrders { get; }
        TiCutJobSolution SheetProgram { get; }
    }
}
