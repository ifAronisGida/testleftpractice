namespace UiObjectInterfaces.Common
{
    public interface TiDomain : TiVisibility
    {
        /// <summary>
        /// Gets the result column.
        /// </summary>
        /// <value>
        /// The result column.
        /// </value>
        TiResultColumn ResultColumn { get; }

        void Goto();
    }
}
