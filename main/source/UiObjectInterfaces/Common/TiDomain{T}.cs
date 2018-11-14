namespace HomeZone.UiObjectInterfaces.Common
{
    public interface TiDomain<TResultColumnItem> : TiVisibility, TiGoto where TResultColumnItem : class
    {
        /// <summary>
        /// Gets the result column.
        /// </summary>
        /// <value>
        /// The result column.
        /// </value>
        TiResultColumn<TResultColumnItem> ResultColumn { get; }
    }
}
