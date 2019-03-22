using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjects.PageObjects.Dialogs;
using HomeZone.UiObjects.Utilities;

namespace HomeZone.UiObjects.PageObjects.Part
{
    /// <summary>
    /// The design detail area of the part category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcPartSingleDetailDesign : ControlObject, TiPartSingleDetailDesign
    {
        protected override Search SearchPattern => Search.ByControlName( "DesignSolutionPanel" );

        private TiButton ImportButton => this.FindMapped<TiButton>( "Part.Detail.Design.Import" );
        private TiButton OpenButton => this.FindMapped<TiButton>( "Part.Detail.Design.Open" );
        private TiButton BoostButton => this.FindMapped<TiButton>( "Part.Detail.Design.Calculate" );

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

        /// <summary>
        /// Opens the design.
        /// </summary>
        public void Open()
        {
            OpenButton.Click();
        }

        public void Boost()
        {
            BoostButton.Click();
        }
    }
}
