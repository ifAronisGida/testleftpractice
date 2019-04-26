using System;

namespace HomeZone.UiObjectInterfaces.Shell
{
    public interface TiMainTabControl
    {
        /// <summary>
        /// Gets or sets the index of the selected tab.
        /// </summary>
        /// <value>
        /// The index of the selected tab.
        /// </value>
        int SelectedIndex { get; set; }

        /// <summary>
        /// Returns the current amount of tabs.
        /// </summary>
        /// <returns>The current amount of tabs.</returns>
        int Count();

        /// <summary>
        /// Adds a new tab.
        /// </summary>
        /// <returns></returns>
        int AddNewTab();

        /// <summary>
        /// Closes the current tab.
        /// </summary>
        void CloseCurrentTab();

        /// <summary>
        /// Waits for tab overlay disappear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        void WaitForTabOverlayDisappear( TimeSpan? timeout = null );
    }
}
