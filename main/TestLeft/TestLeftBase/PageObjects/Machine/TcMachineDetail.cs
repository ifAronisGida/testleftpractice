using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.Utilities;

namespace TestLeft.TestLeftBase.PageObjects.Machine
{
    /// <summary>
    /// The detail area of the machine category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcMachineDetail : PageObject, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "Machine.Details" );

        private TcLookUpEdit CutMachineTypeLookUpEdit => TcControlMapper.Map<TcLookUpEdit>( this.FindGeneric( Search.ByUid( "Machine.Detail.Base.TemplateSelection" ) ) );
        private TcLookUpEdit BendMachineTypeLookUpEdit => TcControlMapper.Map<TcLookUpEdit>( this.FindGeneric( Search.ByUid( "Machine.Detail.Base.BendTemplateSelection" ) ) );
        public TiValueControl<string> Name => this.FindGeneric<TiValueControl<string>>( "Machine.Detail.Base.Name" );
        public TiValueControl<string> MachineNumber => this.FindGeneric<TiValueControl<string>>( "Machine.Detail.Base.MachineEquipmentNr" );
        private TcComboBox LaserPowerComboBox => Find<TcComboBox>( Search.ByUid( "Machine.Detail.Base.LaserPowers" ) );
        public TiValueControl<string> TransferDirectory => this.FindGeneric<TiValueControl<string>>( "Machine.Detail.Base.TransferDirectory" );
        public TiValueControl<bool> CreateSubDirectory => TcControlMapper.Map<TiValueControl<bool>>( this.FindGeneric( Search.ByUid( "Machine.Detail.Base.CreateSubDirectory" ) ) );

        /// <summary>
        /// Gets or sets the type of the cut machine.
        /// </summary>
        /// <value>
        /// The type of the cut machine.
        /// </value>
        public string CutMachineType
        {
            set => CutMachineTypeLookUpEdit.Text = value;

            get => CutMachineTypeLookUpEdit.Text;
        }

        /// <summary>
        /// Gets or sets the type of the bend machine.
        /// </summary>
        /// <value>
        /// The type of the bend machine.
        /// </value>
        public string BendMachineType
        {
            set => BendMachineTypeLookUpEdit.Text = value;

            get => BendMachineTypeLookUpEdit.Text;
        }

        /// <summary>
        /// Selects the laser power via the index of a ComboBoxItem.
        /// </summary>
        /// <value>
        /// The index of the laser power.
        /// </value>
        public int LaserPowerIndex
        {
            set => LaserPowerComboBox.ClickItem( value );
        }

        /// <summary>
        /// Selects the laser power via the text of a ComboBoxItem.
        /// </summary>
        /// <value>
        /// The laser power value.
        /// </value>
        public string LaserPowerValue
        {
            set => LaserPowerComboBox.ClickItem( value );
        }

        /// <summary>
        /// Gets the laser power.
        /// </summary>
        /// <value>
        /// The laser power.
        /// </value>
        public string LaserPower => LaserPowerComboBox.GetText();

        /// <summary>
        /// Opens the machine configuration for bend.
        /// </summary>
        public void OpenMachineConfigurationBend()
        {
            var button = Node.Find<IControl>( Search.ByUid( "Machine.Detail.Base.OpenConfigurationDialog" ) );
            button.Click();
        }
    }
}
