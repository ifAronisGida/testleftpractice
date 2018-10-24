using System;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;
using UiObjectInterfaces.Settings;
using UiObjects.PageObjects.Shell;


namespace UiObjects.PageObjects.Settings
{
    /// <summary>
    /// The settings dialog.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    public class TcSettingsDialog : TcPageObjectBase, IChildOf<TcHomeZoneApp>, TiSettingsDialog
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
            if( VisibleOnScreen )
            {
                return;
            }

            base.Goto();
            Goto<TcMainMenu>().OpenSettingsDialog();
        }

        /// <summary>
        /// Gets the bend settings PageObject.
        /// </summary>
        /// <value>
        /// The bend settings PageObject.
        /// </value>
        public TiBendSettings BendSettings => mBendSettings.Value;

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
