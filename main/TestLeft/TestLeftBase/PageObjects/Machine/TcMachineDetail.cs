using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;

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

        private TcLookUpEdit CutMachineTypeLookUpEdit => Find<TcLookUpEdit>( Search.ByUid( "Machine.Detail.Base.TemplateSelection" ) );
        private TcLookUpEdit BendMachineTypeLookUpEdit => Find<TcLookUpEdit>( Search.ByUid( "Machine.Detail.Base.BendTemplateSelection" ) );
        private TcTextEdit NameTextEdit => Find<TcTextEdit>( Search.ByUid( "Machine.Detail.Base.Name" ) );
        private TcTextEdit MachineNumberTextEdit => Find<TcTextEdit>( Search.ByUid( "Machine.Detail.Base.MachineEquipmentNr" ) );
        private TcComboBox LaserPowerComboBox => Find<TcComboBox>( Search.ByUid( "Machine.Detail.Base.LaserPowers" ) );
        private TcTextEdit TransferDirectoryTextEdit => Find<TcTextEdit>( Search.ByUid( "Machine.Detail.Base.TransferDirectory" ) );
        private TcCheckBox CreateSubDirectoryCheckBox => Find<TcCheckBox>( Search.ByUid( "Machine.Detail.Base.CreateSubDirectory" ) );

        /// <summary>
        /// Gets or sets the type of the cut machine.
        /// </summary>
        /// <value>
        /// The type of the cut machine.
        /// </value>
        public string CutMachineType
        {
            set
            {
                CutMachineTypeLookUpEdit.Text = value;
            }

            get
            {
                return CutMachineTypeLookUpEdit.Text;
            }
        }

        /// <summary>
        /// Gets or sets the type of the bend machine.
        /// </summary>
        /// <value>
        /// The type of the bend machine.
        /// </value>
        public string BendMachineType
        {
            set
            {
                BendMachineTypeLookUpEdit.Text = value;
            }

            get
            {
                return BendMachineTypeLookUpEdit.Text;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            set
            {
                NameTextEdit.Text = value;
            }

            get
            {
                return NameTextEdit.Text;
            }
        }

        /// <summary>
        /// Gets or sets the machine number.
        /// </summary>
        /// <value>
        /// The machine number.
        /// </value>
        public string MachineNumber
        {
            set
            {
                MachineNumberTextEdit.Text = value;
            }

            get
            {
                return MachineNumberTextEdit.Text;
            }
        }

        /// <summary>
        /// Selects the laser power via the index of a ComboBoxItem.
        /// </summary>
        /// <value>
        /// The index of the laser power.
        /// </value>
        public int LaserPowerIndex
        {
            set
            {
                LaserPowerComboBox.ClickItem( value );
            }
        }

        /// <summary>
        /// Selects the laser power via the text of a ComboBoxItem.
        /// </summary>
        /// <value>
        /// The laser power value.
        /// </value>
        public string LaserPowerValue
        {
            set
            {
                LaserPowerComboBox.ClickItem( value );
            }
        }

        /// <summary>
        /// Gets the laser power.
        /// </summary>
        /// <value>
        /// The laser power.
        /// </value>
        public string LaserPower
        {
            get
            {
                return LaserPowerComboBox.GetText();
            }
        }

        /// <summary>
        /// Gets or sets the transfer directory.
        /// </summary>
        /// <value>
        /// The transfer directory.
        /// </value>
        public string TransferDirectory
        {
            set
            {
                TransferDirectoryTextEdit.Text = value;
            }

            get
            {
                return TransferDirectoryTextEdit.Text;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a sub directory is created.
        /// </summary>
        /// <value>
        ///   <c>true</c> if sub directory is created; otherwise, <c>false</c>.
        /// </value>
        public bool CreateSubDirectory
        {
            set
            {
                CreateSubDirectoryCheckBox.Checked = value;
            }

            get
            {
                return CreateSubDirectoryCheckBox.Checked;
            }
        }
    }
}
