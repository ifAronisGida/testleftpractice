using HomeZone.UiObjectInterfaces.Common;


namespace HomeZone.UiObjectInterfaces.Shell
{
    public interface TiWelcomeScreen : TiVisibility
    {
        /// <summary>
        /// Gets or sets a value indicating whether welcome screen is shown.
        /// </summary>
        /// <value>
        ///   <c>true</c> if welcome screen is shown; otherwise, <c>false</c>.
        /// </value>
        bool ShowWelcomeScreen { get; set; }
    }
}
