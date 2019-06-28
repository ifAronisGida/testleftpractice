using System;
using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.Part
{
    public interface TiParts : TiDomain<TiPartToolbar>
    {
        /// <summary>
        /// Gets the single detail.
        /// </summary>
        /// <value>
        /// The single detail.
        /// </value>
        TiPartSingleDetail SingleDetail { get; }

        /// <summary>
        /// Gets the single detail design.
        /// </summary>
        /// <value>
        /// The single detail design.
        /// </value>
        TiPartSingleDetailDesign SingleDetailDesign { get; }

        /// <summary>
        /// Gets the single detail bend solutions.
        /// </summary>
        /// <value>
        /// The single detail bend solutions.
        /// </value>
        TiPartSingleDetailBendSolutions SingleDetailBendSolutions { get; }

        /// <summary>
        /// Gets the single detail cut solutions.
        /// </summary>
        /// <value>
        /// The single detail cut solutions.
        /// </value>
        TiPartSingleDetailCutSolutions SingleDetailCutSolutions { get; }

        /// <summary>
        /// Deletes the given part.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if successful</returns>
        bool DeletePart( string id );
    }
}
