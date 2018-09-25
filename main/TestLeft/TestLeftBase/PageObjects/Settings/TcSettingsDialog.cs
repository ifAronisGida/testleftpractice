using System;
using PageObjectInterfaces.Controls;
using SmartBear.TestLeft.TestObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Settings
{
    /// <summary>
    /// The settings dialog.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    public class TcSettingsDialog : PageObjectBase, IChildOf<TcHomeZoneApp>
    {
        protected override Search SearchPattern => Search.ByUid( "SettingsDialog" );

        private readonly Lazy<TcBendSettings> mBendSettings;

        internal IControl BendTab => Node.Find<IControl>( Search.ByUid( "SettingsPage.Bend" ), 3 );
        internal IControl CutTab => Node.Find<IControl>( Search.ByUid( "SettingsPage.Cut" ), 3 );

        private TiButton CancelButton => Find<TiButton>( "CancelButton" );
        private TiButton SaveButton => Find<TiButton>( "SaveButton" );

        /// <summary>
        /// Initializes a new instance of the <see cref="TcSettingsDialog"/> class.
        /// </summary>
        public TcSettingsDialog()
        {
            mBendSettings = new Lazy<TcBendSettings>( On<TcBendSettings> );
        }

        /// <summary>
        /// Goto the page object, i.e. perform necessary action to make the page object visible on screen, do nothing if the page is already visible on screen.
        /// </summary>
        public override void Goto()
        {
            base.Goto();
            Goto<TcMainMenu>().OpenSettingsDialog();
            VisibleOnScreen.WaitFor();
        }

        /// <summary>
        /// Gets the bend settings PageObject.
        /// </summary>
        /// <value>
        /// The bend settings PageObject.
        /// </value>
        public TcBendSettings BendSettings => mBendSettings.Value;

        /// <summary>
        /// Saves the setings.
        /// </summary>
        public void Save()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Cancels the settings dialog.
        /// </summary>
        public void Cancel()
        {
            CancelButton.Click();
        }
    }
}
