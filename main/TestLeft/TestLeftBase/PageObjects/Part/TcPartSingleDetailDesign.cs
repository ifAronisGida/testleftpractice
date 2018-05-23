using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Dialogs;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// The design detail area of the part category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcPartSingleDetailDesign : PageObject, IChildOf<TcPartSingleDetail>
    {
        protected override Search SearchPattern => Search.ByUid( "Part.Detail.Design" );

        internal TcTruIconButton ImportButton => Find<TcTruIconButton>( Search.ByUid( "Part.Detail.Design.Import" ) );

        /// <summary>
        /// Imports the specified design from the given filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public bool Import( string filename )
        {
            ImportButton.Click();

            var openDlg = On<TcOpenFileDialog>();
            return openDlg.SetFilename( filename );
        }
    }
}
