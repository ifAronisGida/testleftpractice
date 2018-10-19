using PageObjectInterfaces.Controls;
using PageObjectInterfaces.Dialogs;
using PageObjectInterfaces.Part;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using TestLeft.TestLeftBase.PageObjects.Dialogs;

namespace TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// The design detail area of the part category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcPartSingleDetailDesign : TcPageObjectBase, IChildOf<TcPartSingleDetail>, TiPartSingleDetailDesign
    {
        protected override Search SearchPattern => Search.ByUid( "Part.Detail.Design" );

        private TiButton ImportButton => Find<TiButton>( "Part.Detail.Design.Import" );
        private TiButton OpenButton => Find<TiButton>( "Part.Detail.Design.Open" );

        /// <summary>
        /// Imports the specified design from the given filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public bool Import( string filename )
        {
            ImportButton.Click();

            var openDlg = On<TiOpenFileDialog, TcOpenFileDialog>();
            return openDlg.SetFilename( filename );
        }

        /// <summary>
        /// Opens the design.
        /// </summary>
        public void Open()
        {
            OpenButton.Click();
        }
    }
}
