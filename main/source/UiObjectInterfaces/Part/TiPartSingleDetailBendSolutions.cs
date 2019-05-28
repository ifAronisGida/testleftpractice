namespace HomeZone.UiObjectInterfaces.Part
{
    public interface TiPartSingleDetailBendSolutions
    {
        /// <summary>
        /// Creates a new bend solution.
        /// </summary>
        void New();

        void OpenBendSolution( string name );

        /// <summary>
        /// Boosts the solution.
        /// </summary>
        /// <param name="name">The name.</param>
        void BoostSolution( string name );

        /// <summary>
        /// Opens the solution detail.
        /// </summary>
        /// <param name="name">The name.</param>
        void OpenSolutionDetail( string name );

        /// <summary>
        /// Nc button visible.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>bool</returns>
        bool NcButtonVisible( string name );

        /// <summary>
        /// Setups plan button visible.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>bool</returns>
        bool SetupPlanButtonVisible( string name );

        /// <summary>
        /// Open release button visible.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>bool</returns>
        bool OpenReleaseButtonVisible( string name );

        /// <summary>
        /// Toggles the OpenRelease button.
        /// </summary>
        void ToggleOpenReleaseButton( string name );

        /// <summary>
        /// Toggles the unrelease button.
        /// </summary>
        void ToggleUnreleaseButton( string name );

        /// <summary>
        /// Toggles the release button.
        /// </summary>
        void ToggleReleaseButton( string name );

        /// <summary>
        /// Determines whether part is manually changed
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns> true if manually changed </returns>
        bool IsManuallyChanged( string name );

        /// <summary>
        /// Tool Tip of a bend solution
        /// </summary>
        /// <param name="bendSolutionName">bend solution name</param>
        /// <returns></returns>
        string SingleBendSolutionStateToolTip( string bendSolutionName );
    }
}
