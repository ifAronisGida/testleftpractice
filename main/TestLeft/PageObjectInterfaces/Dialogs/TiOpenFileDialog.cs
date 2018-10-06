namespace PageObjectInterfaces.Dialogs
{
    public interface TiOpenFileDialog
    {
        /// <summary>
        /// Enters the given filename and clicks the open button.
        /// </summary>
        /// <param name="filename">The filename to enter.</param>
        /// <returns></returns>
        bool SetFilename( string filename );
    }
}
