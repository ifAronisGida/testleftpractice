namespace HomeZone.UiObjectInterfaces.Common
{
    public interface TiDomain<TResultColumnItem> : TiDomain where TResultColumnItem : class
    {
        /// <summary>
        /// Gets the result column.
        /// </summary>
        /// <value>
        /// The result column.
        /// </value>
        new TiResultColumn<TResultColumnItem> ResultColumn { get; }
    }
}
