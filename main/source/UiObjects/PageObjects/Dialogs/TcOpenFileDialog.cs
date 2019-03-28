using HomeZone.UiObjectInterfaces.Dialogs;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;


namespace HomeZone.UiObjects.PageObjects.Dialogs
{
    /// <summary>
    /// TcOpenFileDialog handles open file dialogs.
    /// </summary>
    /// <seealso cref="RepeaterObject" />
    public class TcOpenFileDialog<T> : RepeaterObject, IChildOf<T>, TiOpenFileDialog where T : IPageObject
    {
        /// <summary>
        /// Enters the given filename and clicks the open button.
        /// </summary>
        /// <param name="filename">The filename to enter.</param>
        /// <returns></returns>
        public bool SetFilename( string filename )
        {
            var dlg = Parent.Node.Find<IWindow>( new WindowPattern { WndClass = "#32770" }, 1 );

            dlg.Cast<IOpenFileDialog>().OpenFile( filename );

            return true;
        }
    }
}
