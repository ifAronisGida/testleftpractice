using PageObjectInterfaces.Controls;
using PageObjectInterfaces.Dialogs;
using PageObjectInterfaces.Part;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// The part toolbar.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcToolbars}" />
    public class TcPartToolbar : TcPageObjectBase, IChildOf<TcToolbars>, TiPartToolbar
    {
        public bool CanSave => SaveButton.Enabled;
        public bool CanDelete => DeleteButton.Enabled;
        public bool CanRevert => RevertButton.Enabled;
        public bool CanBoost => BoostButton.Enabled;

        protected override Search SearchPattern => Search.ByUid( "Part.Toolbar" );

        private TiButton NewPartButton => Find<TiButton>( "Part.Toolbar.New" );
        private TiButton DuplicateButton => Find<TiButton>( "Part.Toolbar.Duplicate" );
        private TiButton ImportButton => Find<TiButton>( "Part.Toolbar.Import" );
        private TiButton ExportButton => Find<TiButton>( "Part.Toolbar.Export" );
        private TiButton BoostButton => Find<TiButton>( "Part.Toolbar.CalculateAll" );
        private TiButton CreatePartOrderButton => Find<TiButton>( "Part.Toolbar.CreatePartOrder" );
        private TiButton CreateCutJobButton => Find<TiButton>( "Part.Toolbar.CreateCutJob" );
        private TiButton SaveButton => Find<TiButton>( "Part.Toolbar.Save" );
        private TiButton RevertButton => Find<TiButton>( "Part.Toolbar.Revert" );
        private TiButton DeleteButton => Find<TiButton>( "Part.Toolbar.Delete" );
        private TiButton MoveToArchiveButton => Find<TiButton>( "Part.Toolbar.MoveToArchive" );
        private TiButton RemoveFromArchiveButton => Find<TiButton>( "Part.Toolbar.RemoveFromArchive" );
        private TiButton LockPartButton => Find<TiButton>( "Part.Toolbar.LockPart" );
        private TiButton UnlockPartButton => Find<TiButton>( "Part.Toolbar.UnlockPart" );

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

            var openDlg = On<TiOpenFileDialog, TcOpenFileDialog>();
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
        /// Saves the part.
        /// </summary>
        public void Save()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Reverts the part.
        /// </summary>
        public void Revert()
        {
            RevertButton.Click();
        }

        /// <summary>
        /// Deletes the part.
        /// </summary>
        public void Delete()
        {
            DeleteButton.Click();

            var dialog = On<TiMessageBox, TcMessageBox>();
            if( dialog.MessageBoxExists() )
            {
                dialog.Yes();
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
    }
}
