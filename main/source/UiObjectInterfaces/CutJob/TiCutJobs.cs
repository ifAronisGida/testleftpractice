using System;
using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.CutJob
{
    public interface TiCutJobs : TiDomain<TiCutJobToolbar, TiCutJobResultListItem>
    {
        TiCutJobBaseInfo BaseInfo { get; }
        TiCutJobContainedOrders ContainedOrders { get; }
        TiCutJobSolution SheetProgram { get; }

        /// <summary>
        /// Deletes the given cut job.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if deleted</returns>
        bool DeleteCutJob( string id );
    }
}
