using System;
using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.PartOrder
{
    public interface TiPartOrders : TiDomain
    {
        TiPartOrderToolbar Toolbar { get; }
        TiPartOrderBaseInfo BaseInfo { get; }
        TiPartOrderPartInfo PartInfo { get; }
        TiPartOrderBaseInfoBulk BaseInfoBulk { get; }
        TiPartOrderPartInfoBulk PartInfoBulk { get; }

        /// <summary>
        /// Deletes the given part order. The part order should not be used in nestings.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if deleted</returns>
        bool DeletePartOrder( string id );

        void ImportDirectory( string directory );
    }
}
