using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Settings;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;


namespace HomeZone.UiObjects.PageObjects.Settings
{
    /// <summary>
    /// PageObject for the bend settings..
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="IChildOf{TcSettingsDialog}" />
    public class TcBendSettings : TcPageObjectBase, IChildOf<TcSettingsDialog>, TiBendSettings
    {
        protected override Search SearchPattern => Search.ByUid( "Settings.Bend" );

        private TiButton ToolsOpenButton => Find<TiButton>( "Settings.Bend.Tools.Open" );
        private TiButton BendDeductionOpenButton => Find<TiButton>( "Settings.Bend.BendDeduction.Open" );
        private TiButton AppSettingsOpenButton => Find<TiButton>( "Settings.Bend.AppSettings.Open" );
        private TiButton DataManagerBendOpenButton => Find<TiButton>( "Settings.Bend.DataManagerBend.Open" );
        private TiButton NewLocalDefaultBendProgram => Find<TiButton>( "Settings.Bend.User.BendSolutions.Solutions.AddSolution" );
        private TiButton DeleteLocalDefaultBendProgram => Find<TiButton>( "Settings.Bend.User.BendSolutions.List.Bend1.DeleteSolution" );

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

        /// <summary>
        /// Add a default Bend Program (take first which appears in dropdown)
        /// </summary>
        public void AddDefaultBendProgram()
        {
            NewLocalDefaultBendProgram.Click();
        }

        /// <summary>
        /// Delete the first default Bend Program
        /// </summary>
        public void DeleteDefaultBendProgram()
        {
            DeleteLocalDefaultBendProgram.Click();
        }
    }
}
