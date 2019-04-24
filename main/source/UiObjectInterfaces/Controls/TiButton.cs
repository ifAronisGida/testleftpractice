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
    }
}
