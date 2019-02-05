using System;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Material;

namespace HomeZone.UiObjects.PageObjects.Material
{
    /// <summary>
    /// The material toolbar.
    /// </summary>
    public class TcMaterialToolbar : TcToolbar, TiMaterialToolbar
    {
        protected override Search SearchPattern => Search.ByUid( "Material.Toolbar" );

        private TiButton NewButton => Find<TiButton>( "Material.Toolbar.New" );
        private TiButton DuplicateButton => Find<TiButton>( "Material.Toolbar.Duplicate" );
        private TiButton LockMaterialButton => Find<TiButton>( "Material.Toolbar.LockMaterial" );
        private TiButton UnlockMaterialButton => Find<TiButton>( "Material.Toolbar.UnlockMaterial" );

        public TcMaterialToolbar()
        {
            SaveButton = new Lazy<TiButton>( () => Find<TiButton>( "Material.Toolbar.Save" ) );
            RevertButton = new Lazy<TiButton>( () => Find<TiButton>( "Material.Toolbar.Revert" ) );
            DeleteButton = new Lazy<TiButton>( () => Find<TiButton>( "Material.Toolbar.Delete" ) );
        }

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
    }
}
