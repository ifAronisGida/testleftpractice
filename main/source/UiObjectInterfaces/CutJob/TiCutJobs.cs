using UiObjectInterfaces.Common;


namespace UiObjectInterfaces.CutJob
{
    public interface TiCutJobs : TiDomain
    {
        TiCutJobToolbar Toolbar { get; }
        TiCutJobBaseInfo BaseInfo { get; }
        TiCutJobContainedOrders ContainedOrders { get; }
        TiCutJobSheetProgram SheetProgram { get; }
    }
}
