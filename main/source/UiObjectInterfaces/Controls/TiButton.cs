namespace HomeZone.UiObjectInterfaces.Controls
{
    public interface TiButton : TiControl
    {
        /// <summary>
        /// Gets the label of the button.
        /// </summary>
        /// <value>
        /// The label of the button.
        /// </value>
        string Label { get; }

        /// <summary>
        /// Checks if the button is enabled and clicks the button.
        /// </summary>
        void Click();

        /// <summary>
        /// Asserts that the button is enabled.
        /// </summary>
        void ShouldBeEnabled();

        /// <summary>
        /// Asserts that the button is disabled.
        /// </summary>
        void ShouldBeDisabled();
    }
}
