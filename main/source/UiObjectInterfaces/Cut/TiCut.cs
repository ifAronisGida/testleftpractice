namespace UiObjectInterfaces.Cut
{
    public interface TiCut : TiApp
    {
        /// <summary>
        /// Gets the technology table selection dialog.
        /// </summary>
        /// <value>
        /// The technology table selection dialog.
        /// </value>
        TiTTSelectionDialog TechnologyTableSelectionDialog { get; }
    }
}
