namespace HomeZone.UiObjectInterfaces.Common
{
    public interface TiDomain<TToolbar, TResultColumnItem> : TiDomain<TToolbar>
        where TToolbar : TiToolbar
        where TResultColumnItem : class
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
