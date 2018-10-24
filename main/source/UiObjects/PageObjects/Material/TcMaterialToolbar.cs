using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;
using UiObjectInterfaces.Material;
using UiObjects.PageObjects.Dialogs;
using UiObjects.PageObjects.Shell;


namespace UiObjects.PageObjects.Material
{
    /// <summary>
    /// The material toolbar.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcToolbars}" />
    public class TcMaterialToolbar : TcPageObjectBase, IChildOf<TcToolbars>, TiMaterialToolbar
    {
        public bool CanSave => SaveButton.Enabled;
        public bool CanDelete => DeleteButton.Enabled;
        public bool CanRevert => RevertButton.Enabled;


        protected override Search SearchPattern => Search.ByUid( "Material.Toolbar" );

        private TiButton NewButton => Find<TiButton>( "Material.Toolbar.New" );
        private TiButton DuplicateButton => Find<TiButton>( "Material.Toolbar.Duplicate" );
        private TiButton SaveButton => Find<TiButton>( "Material.Toolbar.Save" );
        private TiButton RevertButton => Find<TiButton>( "Material.Toolbar.Revert" );
        private TiButton DeleteButton => Find<TiButton>( "Material.Toolbar.Delete" );
        private TiButton LockMaterialButton => Find<TiButton>( "Material.Toolbar.LockMaterial" );
        private TiButton UnlockMaterialButton => Find<TiButton>( "Material.Toolbar.UnlockMaterial" );

        /// <summary>
        /// Creates a new material.
        /// </summary>
        public void New()
        {
            NewButton.Click();
        }

        /// <summary>
        /// Duplicates the current material.
        /// </summary>
        public void Duplicate()
        {
            DuplicateButton.Enabled.WaitFor();
            DuplicateButton.Click();
        }

        /// <summary>
        /// Saves the current material.
        /// </summary>
        public void Save()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Deletes the current material.
        /// </summary>
        /// <returns>true if successful</returns>
        public void Delete()
        {
            DeleteButton.Click();

            var dialog = On<TcMessageBox>();
            if( dialog.MessageBoxExists() )
            {
                dialog.Yes();
            }
        }
    }
}
