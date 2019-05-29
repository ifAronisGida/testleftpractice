using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.PageObjects.Shell;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.Part
{
    /// <summary>
    /// The bend solutions area of the part category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcPartSingleDetailBendSolutions : TcPageObjectBase, IChildOf<TcDetailContent>, TiPartSingleDetailBendSolutions
    {
        protected override Search SearchPattern => Search.ByUid( "Part.Detail.BendSolutions" );

        private IListBox BendSolutionList => Node.Find<IListBox>( Search.ByUid( "Part.Detail.BendSolutions.List" ) );
        private TiButton NewButton => Find<TiButton>( "Part.Detail.BendSolutions.AddSolution" );
        private TcTooltipAccessor BendSolutionState => Find<TcTooltipAccessor>( "Part.Detail.BendSolutions.State" );
        private TcTooltipAccessor SingleBendSolutionState( string bendSolutionName )
        {
            return Find<TcTooltipAccessor>( Search.ByUid( string.Format( "Part.Detail.BendSolutions.List.{0}.State", bendSolutionName ) ) );
        }

        /// <summary>
        /// Creates a new bend solution.
        /// </summary>
        public void New()
        {
            NewButton.Click();
        }

        public int Count => BendSolutionList.wItemCount;

        public void OpenBendSolution( string name )
        {
            var openButton = BendSolutionList.Find<IButton>( Search.ByUid( "Part.Detail.BendSolutions.List." + name + ".Detail.OpenSolution" ), 5 );
            if( openButton.VisibleOnScreen )
            {
                openButton.Click();
            }
        }

        /// <summary>
        /// Boosts the solution.
        /// </summary>
        /// <param name="name">The name.</param>
        public void BoostSolution( string name )
        {
            var boostButton = BendSolutionList.Find<IButton>( Search.ByUid( "Part.Detail.BendSolutions.List." + name + ".Detail.CalculateSolution" ), 4 );
            if( boostButton.VisibleOnScreen )
            {
                boostButton.Click();
            }
        }

        /// <summary>
        /// Opens the solution detail.
        /// </summary>
        /// <param name="name">The name.</param>
        public void OpenSolutionDetail( string name )
        {
            IControl detail = BendSolutionList.Find<IControl>( Search.ByUid( "Part.Detail.BendSolutions.List." + name ), 2 );
            if( detail.VisibleOnScreen )
            {
                detail.Click();
            }
        }

        /// <summary>
        /// Nc button visible.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>bool</returns>
        public bool NcButtonVisible( string name )
        {
            var button = BendSolutionList.Find<IControl>( Search.ByUid( "Part.Detail.BendSolutions.List." + name + ".Detail.OpenNcFile" ), 6 );
            return button.VisibleOnScreen && button.Enabled;
        }

        /// <summary>
        /// Setups plan button visible.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>bool</returns>
        public bool SetupPlanButtonVisible( string name )
        {
            var button = BendSolutionList.Find<IControl>( Search.ByUid( "Part.Detail.BendSolutions.List." + name + ".Detail.OpenSetupReport" ), 6 );
            return button.VisibleOnScreen && button.Enabled;
        }

        /// <summary>
        /// Open release button visible.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>bool</returns>
        public bool OpenReleaseButtonVisible( string name )
        {
            var button = BendSolutionList.Find<IControl>( Search.ByUid( "Part.Detail.BendSolutions.List." + name + ".Detail.OpenReleaseFolder" ), 6 );
            return button.VisibleOnScreen && button.Enabled;
        }

        /// <summary>
        /// Toggles the OpenRelease button.
        /// </summary>
        public void ToggleOpenReleaseButton( string name )
        {
            var button = BendSolutionList.Find<IControl>( Search.ByUid( "Part.Detail.BendSolutions.List." + name + ".Detail.OpenReleaseFolder" ), 6 );
            button.Click();
        }

        /// <summary>
        /// Toggles the release button.
        /// </summary>
        public void ToggleReleaseButton( string name )
        {
            var button = BendSolutionList.Find<IButton>( Search.ByUid( "Part.Detail.BendSolutions.List." + name + ".Detail.ReleaseSolution" ), 8 );
            button.Click();
        }

        /// <summary>
        /// Toggles the unrelease button.
        /// </summary>
        public void ToggleUnreleaseButton( string name )
        {
            var button = BendSolutionList.Find<IButton>( Search.ByUid( "Part.Detail.BendSolutions.List." + name + ".Detail.UnreleaseSolution" ), 8 );
            button.Click();
        }

        /// <summary>
        /// Determines whether part is manually changed
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns> true if manually changed </returns>
        public bool IsManuallyChanged( string name )
        {
            var homunculus = BendSolutionList.Find<IControl>( Search.ByUid( "Part.Detail.BendSolutions.List." + name + ".ManuallyChanged" ), 3 );
            return homunculus.VisibleOnScreen;
        }

        /// <summary>
        /// Tool Tip of a bend solution
        /// </summary>
        /// <param name="bendSolutionName">bend solution name</param>
        /// <returns></returns>
        public string SingleBendSolutionStateToolTip( string bendSolutionName )
        {
            return SingleBendSolutionState( bendSolutionName ).ToolTip;
        }
    }
}
