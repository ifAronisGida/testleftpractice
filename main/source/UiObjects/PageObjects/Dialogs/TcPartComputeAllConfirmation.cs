using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Dialogs;


namespace UiObjects.PageObjects.Dialogs
{
    /// <summary>
    /// This class handles the PartComputeAllConfirmation dialog box.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    internal class TcPartComputeAllConfirmation : TcPageObjectBase, IChildOf<TcHomeZoneApp>, TiPartComputeAllConfirmation
    {
        protected override Search SearchPattern => Search.Any;

        private IControl mDialogBox;

        internal IControl DialogBox
        {
            get
            {
                if( mDialogBox == null )
                {
                    mDialogBox = Parent.Node.Find<IControl>( new WPFPattern { Uid = "Part.ComputeAllConfirmation" }, 2 );
                }

                return mDialogBox;
            }
        }

        internal IRadioButton ComputeAllButton => DialogBox.Find<IRadioButton>( new WPFPattern { Uid = "ComputeAll" }, 3 );
        internal IRadioButton ComputeIncompleteButton => DialogBox.Find<IRadioButton>( new WPFPattern { Uid = "ComputeIncomplete" }, 3 );
        internal IRadioButton RefreshAllButton => DialogBox.Find<IRadioButton>( new WPFPattern { Uid = "RefreshAll" }, 3 );

        internal IButton OkButton => DialogBox.Find<IButton>( new WPFPattern { Uid = "Ok" }, 3 );
        internal IButton CancelButton => DialogBox.Find<IButton>( new WPFPattern { Uid = "Cancel" }, 3 );

        /// <summary>
        /// Returns true if the dialog box exists.
        /// </summary>
        /// <returns>True if the dialog box exists, otherwise false.</returns>
        public bool DialogBoxExists()
        {
            return Parent.Node.TryFind<IControl>( new WPFPattern { Uid = "Part.ComputeAllConfirmation" }, out mDialogBox, 2 );
        }

        /// <summary>
        /// Clicks the ComputeAll button.
        /// </summary>
        public void ComputeAll()
        {
            ComputeAllButton.Click();
        }

        /// <summary>
        /// Clicks the ComputeIncomplete button.
        /// </summary>
        public void ComputeIncompleteAll()
        {
            ComputeIncompleteButton.Click();
        }

        /// <summary>
        /// Clicks the RefreshAll button.
        /// </summary>
        public void RefreshAll()
        {
            RefreshAllButton.Click();
        }

        /// <summary>
        /// Clicks the Ok button.
        /// </summary>
        public void Ok()
        {
            OkButton.Click();
        }
    }
}
