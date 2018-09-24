using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Settings
{
    /// <summary>
    /// PageObject for the bend settings..
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="IChildOf{TcSettingsDialog}" />
    public class TcBendSettings : PageObjectBase, IChildOf<TcSettingsDialog>
    {
        protected override Search SearchPattern => Search.ByUid( "Settings.Bend" );

        private TiButton ToolsOpenButton => Find<TiButton>( "Settings.Bend.Tools.Open" );
        private TiButton ToolListsOpenButton => Find<TiButton>( "Settings.Bend.ToolLists.Open" );
        private TiButton BendDeductionOpenButton => Find<TiButton>( "Settings.Bend.BendDeduction.Open" );
        private TiButton AppSettingsOpenButton => Find<TiButton>( "Settings.Bend.AppSettings.Open" );
        private TiButton DataManagerBendOpenButton => Find<TiButton>( "Settings.Bend.DataManagerBend.Open" );

        /// <summary>
        /// Goto the page object, i.e. perform necessary action to make the page object visible on screen, do nothing if the page is already visible on screen.
        /// </summary>
        public override void Goto()
        {
            if( !IsVisibleOnScreen )
            {
                Parent.Goto();
                ( ( TcSettingsDialog )Parent ).BendTab.Click();
            }
        }

        /// <summary>
        /// Opens the Flux tools configuration dialog.
        /// </summary>
        public void OpenToolsConfiguration()
        {
            ToolsOpenButton.Click();
        }

        /// <summary>
        /// Opens the Flux tool lists configuration dialog.
        /// </summary>
        public void OpenToolListsConfiguration()
        {
            ToolListsOpenButton.Click();
        }

        /// <summary>
        /// Opens the Flux vebd deduction configuration dialog.
        /// </summary>
        public void OpenBendDeductionConfiguration()
        {
            BendDeductionOpenButton.Click();
        }

        /// <summary>
        /// Opens the Flux app settings configuration dialog.
        /// </summary>
        public void OpenAppSettingsConfiguration()
        {
            AppSettingsOpenButton.Click();
        }

        /// <summary>
        /// Opens the data manager bend.
        /// </summary>
        public void OpenDataManagerBend()
        {
            DataManagerBendOpenButton.Click();
        }
    }
}
