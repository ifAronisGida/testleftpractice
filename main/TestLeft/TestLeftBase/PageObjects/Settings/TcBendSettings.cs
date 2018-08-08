using TestLeft.TestLeftBase.ControlObjects;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Settings
{
    /// <summary>
    /// PageObject for the bend settings..
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="IChildOf{TcSettingsDialog}" />
    public class TcBendSettings : PageObject, IChildOf<TcSettingsDialog>
    {
        protected override Search SearchPattern => Search.ByUid( "Settings.Bend" );

        private TcTruIconButton ToolsOpenButton => Find<TcTruIconButton>( Search.ByUid( "Settings.Bend.Tools.Open" ) );
        private TcTruIconButton ToolListsOpenButton => Find<TcTruIconButton>( Search.ByUid( "Settings.Bend.ToolLists.Open" ) );
        private TcTruIconButton BendDeductionOpenButton => Find<TcTruIconButton>( Search.ByUid( "Settings.Bend.BendDeduction.Open" ) );
        private TcTruIconButton AppSettingsOpenButton => Find<TcTruIconButton>( Search.ByUid( "Settings.Bend.AppSettings.Open" ) );
        private TcTruIconButton DataManagerBendOpenButton => Find<TcTruIconButton>( Search.ByUid( "Settings.Bend.DataManagerBend.Open" ) );

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
