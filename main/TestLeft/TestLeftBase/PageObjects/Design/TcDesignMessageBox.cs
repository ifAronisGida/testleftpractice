using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects;

namespace TestLeft.TestLeftBase.PageObjects.Design
{
    public class TcDesignMessageBox : RepeaterObject, IChildOf<TcDesignApp>
    {
        private ITopLevelWindow mMessageBox;

        internal ITopLevelWindow MessageBox
        {
            get
            {
                if( mMessageBox == null )
                {
                    Parent.Node.TryFind( new WindowPattern() { WndClass = "#32770" }, out mMessageBox, 1 );
                }

                return mMessageBox;
            }
        }

        internal IButton YesButton => MessageBox.Find<IButton>( new WindowPattern() { WndClass = "Button", WndCaption = "&Ja" } );
        internal IButton NoButton => MessageBox.Find<IButton>( new WindowPattern() { WndClass = "Button", WndCaption = "&Nein" } );

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
    }
}
