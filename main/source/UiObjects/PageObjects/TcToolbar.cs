using System;
using HomeZone.UiObjectInterfaces.Common;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjects.PageObjects.Dialogs;
using HomeZone.UiObjects.PageObjects.Shell;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.Waiting;

namespace HomeZone.UiObjects.PageObjects
{
    public abstract class TcToolbar : TcPageObjectBase, IChildOf<TcToolbars>, TiToolbar
    {
        public bool CanSave => SaveButton.Value.Enabled;
        public bool CanDelete => DeleteButton.Value.Enabled;
        public bool CanRevert => RevertButton.Value.Enabled;

        protected Lazy<TiButton> SaveButton;
        protected Lazy<TiButton> RevertButton;
        protected Lazy<TiButton> DeleteButton;

        /// <summary>
        /// Saves the item.
        /// </summary>
        public void Save()
        {
            SaveButton.Value.Click();
        }

        /// <summary>
        /// Reverts the item.
        /// </summary>
        public void Revert()
        {
            RevertButton.Value.Click();
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        public void Delete()
        {
            DeleteButton.Value.Click();

            var dialog = On<TcMessageBox>();

            Wait.For( dialog.MessageBoxExists, TimeSpan.FromSeconds( 5 ) );
            dialog.Yes();
        }
    }
}
