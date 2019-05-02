using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.PageObjects.Shell;
using HomeZone.UiObjects.Utilities;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.Part
{
    public class TcPartBulkDetailDesign : TcPageObjectBase, IChildOf<TcDetailContent>, TiPartBulkDetailDesign
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrderBulk.Detail.Design" );

        private TiButton BoostButton => this.FindMapped<TiButton>( "PartOrderBulk.Detail.Design.Calculate" );

        public void Boost()
        {
            BoostButton.Click();
        }

        public TiValueControl<string> Material => Find<TiValueControl<string>>( "PartOrderBulk.Detail.Design.Material.Selection" );
        public TiValueControl<string> RawMaterial => Find<TiValueControl<string>>( "PartOrderBulk.Detail.Design.RawMaterial.Selection" );
        public TiValueControl<string> Unfolding => Find<TiValueControl<string>>( "PartOrderBulk.Detail.Design.Unfolding.Selection" );
        public TiValueControl<string> PermittedNestingOrientations => Find<TiValueControl<string>>( "PartOrderBulk.Detail.Design.PermittedNestingOrientations" );
        private TcGroupPanel GroupPanel => Find<TcGroupPanel>( Search.ByUid( "PartOrderBulk.Detail.Design" ) );
        private TiValueControl<bool> RotateToGrainDirectionCheckBox => Find<TiValueControl<bool>>( "PartOrderBulk.Detail.Design.RotateToGrainDirection" );

        /// <summary>
        /// Gets or sets a value indicating whether the more area is expanded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if more is expanded; otherwise, <c>false</c>.
        /// </value>
        public bool IsMoreExpanded
        {
            set => GroupPanel.IsMoreExpanded = value;

            get => GroupPanel.IsMoreExpanded;
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
