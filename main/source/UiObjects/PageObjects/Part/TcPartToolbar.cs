using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Dialogs;
using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjects.PageObjects.Dialogs;
using System;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.Part
{
    /// <summary>
    /// The part toolbar.
    /// </summary>
    public class TcPartToolbar : TcToolbar, TiPartToolbar
    {
        public bool CanBoost => BoostButton.Enabled;

        protected override Search SearchPattern => Search.ByUid( "Part.Toolbar" );

        private TiButton NewPartButton => Find<TiButton>( "Part.Toolbar.New" );
        private TiButton DuplicateButton => Find<TiButton>( "Part.Toolbar.Duplicate" );
        private TiButton ImportButton => Find<TiButton>( "Part.Toolbar.Import" );
        private TiButton ExportButton => Find<TiButton>( "Part.Toolbar.Export" );
        private TiButton BoostButton => Find<TiButton>( "Part.Toolbar.CalculateAll" );
        private TiButton CreatePartOrderButton => Find<TiButton>( "Part.Toolbar.CreatePartOrder" );
        private TiButton CreateCutJobButton => Find<TiButton>( "Part.Toolbar.CreateCutJob" );
        private TiButton MoveToArchiveButton => Find<TiButton>( "Part.Toolbar.MoveToArchive" );
        private TiButton RemoveFromArchiveButton => Find<TiButton>( "Part.Toolbar.RemoveFromArchive" );
        private TiButton LockPartButton => Find<TiButton>( "Part.Toolbar.LockPart" );
        private TiButton UnlockPartButton => Find<TiButton>( "Part.Toolbar.UnlockPart" );

        public TcPartToolbar()
        {
            SaveButton = new Lazy<TiButton>( () => Find<TiButton>( "Part.Toolbar.Save" ) );
            RevertButton = new Lazy<TiButton>( () => Find<TiButton>( "Part.Toolbar.Revert" ) );
            DeleteButton = new Lazy<TiButton>( () => Find<TiButton>( "Part.Toolbar.Delete" ) );
        }

        /// <summary>
        /// Creates a new part.
        /// </summary>
        public void New()
        {
            NewPartButton.Click();
        }

        /// <summary>
        /// Imports the specified part from the given filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>true if successful; otherwise false</returns>
        public bool Import( string filename )
        {
            ImportButton.Click();

            var openDlg = On<TiOpenFileDialog, TcOpenFileDialog<TcHomeZoneApp>>();
            return openDlg.SetFilename( filename );
        }

        /// <summary>
        /// Boosts the part via toolbar.
        /// </summary>
        public void Boost()
        {
            BoostButton.Click();

            var dialog = On<TiPartComputeAllConfirmation, TcPartComputeAllConfirmation>();
            if( dialog.DialogBoxExists() )
            {
                dialog.Ok();
            }
        }

        /// <summary>
        /// Creates the part order.
        /// </summary>
        public void CreatePartOrder()
        {
            CreatePartOrderButton.Click();
        }

        /// <summary>
        /// Creates the cut job.
        /// </summary>
        public void CreateCutJob()
        {
            CreateCutJobButton.Click();
        }

        /// <summary>
        /// Wait until Boost Button is Enabled
        /// </summary>
        /// <param name="timeout">timeout</param>
        /// <returns>true</returns>
        public bool WaitForBoostButtonEnabled( TimeSpan? timeout = null )
        {
            return BoostButton.Enabled.TryWaitFor( timeout ?? TcPageObjectSettings.Instance.PartSelectAllTimeout );
        }
    }
}
