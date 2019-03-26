using HomeZone.UiObjectInterfaces.Controls;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;


namespace HomeZone.UiObjects.PageObjects.Shell
{
    /// <summary>
    /// The main window PageObject. The root of nearly all HomeZone PageObjects.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    public class TcMainWindow : TcPageObjectBase, IChildOf<TcHomeZoneApp>
    {

        public void Maximize()
        {
            if( MaximizeButton.Visible )
            {
                MaximizeButton.Click();
            }
        }

        protected override Search SearchPattern => Search.ByControlName( "WindowRoot" );

        private TiButton MaximizeButton => FindByControlName<TiButton>( "WindowButtonMaximize" );
    }
}
