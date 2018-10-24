using PageObjectInterfaces.Dialogs;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;

namespace TestLeft.TestLeftBase.PageObjects.Dialogs
{
    /// <summary>
    /// TcOpenFileDialog handles open file dialogs.
    /// </summary>
    /// <seealso cref="RepeaterObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    public class TcOpenFileDialog : RepeaterObject, IChildOf<TcHomeZoneApp>, TiOpenFileDialog
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
