using System;
using PageObjectInterfaces.Common;

namespace PageObjectInterfaces.Part
{
    public interface TiParts : TiDomain
    {
        /// <summary>
        /// Gets the toolbar.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        TiPartToolbar Toolbar { get; }

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
        /// Waits for detail overlay appear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        bool WaitForDetailOverlayAppear( TimeSpan timeout );

        /// <summary>
        /// Waits for detail overlay disappear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        bool WaitForDetailOverlayDisappear( TimeSpan timeout );

        /// <summary>
        /// Deletes the given part.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if successful</returns>
        bool DeletePart( string id );
    }
}
