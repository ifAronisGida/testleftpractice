using System;
using System.Collections.Generic;
using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.PartOrder
{
    public interface TiPartOrders : TiDomain
    {
        TiPartOrderToolbar Toolbar { get; }
        TiPartOrderBaseInfo BaseInfo { get; }
        TiPartOrderPartInfo PartInfo { get; }

        /// <summary>
        /// Waits for detail overlay appear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        bool WaitForDetailOverlayAppear( TimeSpan? timeout = null );

        /// <summary>
        /// Waits for detail overlay disappear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        bool WaitForDetailOverlayDisappear( TimeSpan? timeout = null );

        /// <summary>
        /// Deletes the given part order. The part order should not be used in nestings.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if deleted</returns>
        bool DeletePartOrder( string id );

        void Import( IEnumerable<string> files );
        void Import( params string[] files );
    }
}
