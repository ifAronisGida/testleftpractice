using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.PageObjects.Dialogs;
using HomeZone.UiObjects.PageObjects.Shell;
using HomeZone.UiObjects.Utilities;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.Part
{
    /// <summary>
    /// The design detail area of the part category.
    /// </summary>
    /// <seealso cref="TcPageObjectBase" />
    /// <seealso cref="IChildOf{TcDetailContent}" />
    public class TcPartSingleDetailDesign : TcPageObjectBase, IChildOf<TcDetailContent>, TiPartSingleDetailDesign
    {
        protected override Search SearchPattern => Search.ByUid( "Part.Detail.Design" );

        private TiButton ImportButton => this.FindMapped<TiButton>( "Part.Detail.Design.Import" );
        private TiButton BoostButton => this.FindMapped<TiButton>( "Part.Detail.Design.Calculate" );
        private TiButton OpenButton => this.FindMapped<TiButton>( "Part.Detail.Design.Open" );
        private TiButton DeleteButton => this.FindMapped<TiButton>( "Part.Detail.Design.Delete" );

        public TiValueControl<string> Material => Find<TiValueControl<string>>( "Part.Detail.Design.Material.Selection" );
        public TiValueControl<string> RawMaterial => Find<TiValueControl<string>>( "Part.Detail.Design.RawMaterial.Selection" );
        public TiValueControl<string> Unfolding => Find<TiValueControl<string>>( "Part.Detail.Design.Unfolding.Selection" );
        public TiValueControl<string> PermittedNestingOrientations => Find<TiValueControl<string>>( "Part.Detail.Design.PermittedNestingOrientations" );
        private TcGroupPanel SolutionPanel => Find<TcGroupPanel>( Search.ByUid( "Part.Detail.Design" ) );
        private TiValueControl<bool> RotateToGrainDirectionCheckBox => Find<TiValueControl<bool>>( "Part.Detail.Design.RotateToGrainDirection" );

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

        public void Delete()
        {
            DeleteButton.Click();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the more area is expanded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if more is expanded; otherwise, <c>false</c>.
        /// </value>
        public bool IsMoreExpanded
        {
            set => SolutionPanel.IsMoreExpanded = value;

            get => SolutionPanel.IsMoreExpanded;
        }

        public bool RotateToGrainDirection
        {
            set
            {
                IsMoreExpanded = true;
                RotateToGrainDirectionCheckBox.Value = value;
            }

            get
            {
                IsMoreExpanded = true;
                return RotateToGrainDirectionCheckBox.Value;
            }
        }

    }
}
