using PageObjectInterfaces.Controls;
using PageObjectInterfaces.Machine;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Machine
{
    /// <summary>
    /// The detail area of the machine category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcMachineDetail : TcPageObjectBase, IChildOf<TcDetailContent>, TiMachineDetail
    {
        protected override Search SearchPattern => Search.ByUid( "Machine.Details" );

        private TiValueControl<string> CutMachineTypeLookUpEdit => Find<TiValueControl<string>>( "Machine.Detail.Base.TemplateSelection" );
        private TiValueControl<string> BendMachineTypeLookUpEdit => Find<TiValueControl<string>>( "Machine.Detail.Base.BendTemplateSelection" );
        public TiValueControl<string> Name => Find<TiValueControl<string>>( "Machine.Detail.Base.Name" );
        public TiValueControl<string> MachineNumber => Find<TiValueControl<string>>( "Machine.Detail.Base.MachineEquipmentNr" );
        public TiValueControl<string> LaserPower => Find<TiValueControl<string>>( "Machine.Detail.Base.LaserPowers" );
        public TiValueControl<string> TransferDirectory => Find<TiValueControl<string>>( "Machine.Detail.Base.TransferDirectory" );
        public TiValueControl<bool> CreateSubDirectory => Find<TiValueControl<bool>>( "Machine.Detail.Base.CreateSubDirectory" );

        /// <summary>
        /// Gets or sets the type of the cut machine.
        /// </summary>
        /// <value>
        /// The type of the cut machine.
        /// </value>
        public string CutMachineType
        {
            get => CutMachineTypeLookUpEdit.Value;

            set => CutMachineTypeLookUpEdit.Value = value;
        }

        /// <summary>
        /// Gets or sets the type of the bend machine.
        /// </summary>
        /// <value>
        /// The type of the bend machine.
        /// </value>
        public string BendMachineType
        {
            get => BendMachineTypeLookUpEdit.Value;

            set => BendMachineTypeLookUpEdit.Value = value;
        }

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
