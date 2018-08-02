using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Material
{
    /// <summary>
    /// The detail area of the material category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcMaterialDetail : PageObject, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "Material.Detail.Base" );
        private TcTextEdit IdTextEdit => Find<TcTextEdit>( Search.ByUid( "Material.Detail.Base.Name" ) );
        private TcTextEdit NameTextEdit => Find<TcTextEdit>( Search.ByUid( "Material.Detail.Base.ExternalName" ) );
        private TcTextEdit AbbreviationTextEdit => Find<TcTextEdit>( Search.ByUid( "Material.Detail.Base.More.Abbreviation" ) );
        private TcTextEdit EModulusTextEdit => Find<TcTextEdit>( Search.ByUid( "Material.Detail.Base.More.EModulus" ) );
        private TcTextEdit SpecificWeightTextEdit => Find<TcTextEdit>( Search.ByUid( "Material.Detail.Base.More.SpecificWeight" ) );
        private TcTextEdit TensileStrengthMinTextEdit => Find<TcTextEdit>( Search.ByUid( "Material.Detail.Base.More.TensileStrengthMin" ) );
        private TcTextEdit TensileStrengthTextEdit => Find<TcTextEdit>( Search.ByUid( "Material.Detail.Base.More.TensileStrength" ) );
        private TcTextEdit TensileStrengthMaxTextEdit => Find<TcTextEdit>( Search.ByUid( "Material.Detail.Base.More.TensileStrengthMax" ) );

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id
        {
            get => IdTextEdit.Text;
            set => IdTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get => NameTextEdit.Text;
            set => NameTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the abbreviation.
        /// </summary>
        /// <value>
        /// The abbreviation.
        /// </value>
        public string Abbreviation
        {
            get => AbbreviationTextEdit.Text;
            set => AbbreviationTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the e modulus.
        /// </summary>
        /// <value>
        /// The e modulus.
        /// </value>
        public string EModulus
        {
            get => EModulusTextEdit.Text;
            set => EModulusTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the specific weight.
        /// </summary>
        /// <value>
        /// The specific weight.
        /// </value>
        public string SpecificWeight
        {
            get => SpecificWeightTextEdit.Text;
            set => SpecificWeightTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the tensile strength minimum.
        /// </summary>
        /// <value>
        /// The tensile strength minimum.
        /// </value>
        public string TensileStrengthMin
        {
            get => TensileStrengthMinTextEdit.Text;
            set => TensileStrengthMinTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the tensile strength.
        /// </summary>
        /// <value>
        /// The tensile strength.
        /// </value>
        public string TensileStrength
        {
            get => TensileStrengthTextEdit.Text;
            set => TensileStrengthTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the tensile strength maximum.
        /// </summary>
        /// <value>
        /// The tensile strength maximum.
        /// </value>
        public string TensileStrengthMax
        {
            get => TensileStrengthMaxTextEdit.Text;
            set => TensileStrengthMaxTextEdit.Text = value;
        }
    }
}
