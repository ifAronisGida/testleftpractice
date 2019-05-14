namespace HomeZone.UiObjectInterfaces.Common
{
    public interface TiDomain : TiVisibility, TiGoto, TiHasDetailOverlay
    {
        /// <summary>
        /// Gets the result column.
        /// </summary>
        /// <value>
        /// The result column.
        /// </value>
        TiResultColumn ResultColumn { get; }
    }
}
