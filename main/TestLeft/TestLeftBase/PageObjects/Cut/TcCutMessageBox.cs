using System;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.Qt;
using Trumpf.PageObjects;

namespace TestLeft.TestLeftBase.PageObjects.Cut
{
    public class TcCutMessageBox : RepeaterObject, IChildOf<TcCutApp>
    {
        private ITopLevelWindow mMessageBox;

        internal ITopLevelWindow MessageBox
        {
            get
            {
                if( mMessageBox == null )
                {
                    Parent.Node.TryFind( new QtPattern() { objectName = "TcMessageBox" }, out mMessageBox, 1 );
                }

                return mMessageBox;
            }
        }

        private readonly Lazy<IControl> mFrameButtons;

        public TcCutMessageBox()
        {
            mFrameButtons = new Lazy<IControl>( () => MessageBox.Find<IControl>( new QtPattern()
            {
                objectName = "container"
            } ).Find<IControl>( new QtPattern()
            {
                objectName = "frame"
            } ).Find<IControl>( new QtPattern()
            {
                objectName = "content"
            } ).Find<IControl>( new QtPattern()
            {
                objectName = "frameButtons"
            } ) );
        }

        private IControl YesButton => mFrameButtons.Value.Find<IButton>( new QtPattern()
        {
            objectName = "yesButton"
        } );

        private IControl NoButton => mFrameButtons.Value.Find<IButton>( new QtPattern()
        {
            objectName = "noButton"
        } );

        private IControl CancelButton => mFrameButtons.Value.Find<IButton>( new QtPattern()
        {
            objectName = "cancelButton"
        } );

        /// <summary>
        /// Returns true if a message box exists.
        /// </summary>
        /// <returns>True if a message box exists, otherwise false.</returns>
        public bool MessageBoxExists()
        {
            return MessageBox != null;
        }

        /// <summary>
        /// Clicks the yes button.
        /// </summary>
        public void Yes()
        {
            YesButton.Click();
        }

        /// <summary>
        /// Clicks the no button.
        /// </summary>
        public void No()
        {
            NoButton.Click();
        }

        /// <summary>
        /// Clicks the cancel button.
        /// </summary>
        public void Cancel()
        {
            CancelButton.Click();
        }
    }
}
