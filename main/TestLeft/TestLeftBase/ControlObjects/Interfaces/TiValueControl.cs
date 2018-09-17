namespace TestLeft.TestLeftBase.ControlObjects.Interfaces
{
    /// <summary>
    /// Interface for a value control.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface TiValueControl<T>
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        T Value { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="TiValueControl{T}"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        bool Enabled { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        bool IsReadOnly { get; set; }
    }
}
