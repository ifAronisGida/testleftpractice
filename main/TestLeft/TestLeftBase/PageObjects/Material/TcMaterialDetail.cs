using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.Utilities;

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
        public TiValueControl<string> Id => TcControlMapper.Map<TiValueControl<string>>( this.FindGeneric( Search.ByUid( "Material.Detail.Base.Name" ) ) );
        public TiValueControl<string> Name => TcControlMapper.Map<TiValueControl<string>>( this.FindGeneric( Search.ByUid( "Material.Detail.Base.ExternalName" ) ) );
        public TiValueControl<string> Abbreviation => TcControlMapper.Map<TiValueControl<string>>( this.FindGeneric( Search.ByUid( "Material.Detail.Base.More.Abbreviation" ) ) );
        public TiValueControl<string> EModulus => TcControlMapper.Map<TiValueControl<string>>( this.FindGeneric( Search.ByUid( "Material.Detail.Base.More.EModulus" ) ) );
        public TiValueControl<string> SpecificWeight => TcControlMapper.Map<TiValueControl<string>>( this.FindGeneric( Search.ByUid( "Material.Detail.Base.More.SpecificWeight" ) ) );
        public TiValueControl<string> TensileStrengthMin => TcControlMapper.Map<TiValueControl<string>>( this.FindGeneric( Search.ByUid( "Material.Detail.Base.More.TensileStrengthMin" ) ) );
        public TiValueControl<string> TensileStrength => TcControlMapper.Map<TiValueControl<string>>( this.FindGeneric( Search.ByUid( "Material.Detail.Base.More.TensileStrength" ) ) );
        public TiValueControl<string> TensileStrengthMax => TcControlMapper.Map<TiValueControl<string>>( this.FindGeneric( Search.ByUid( "Material.Detail.Base.More.TensileStrengthMax" ) ) );
    }
}
