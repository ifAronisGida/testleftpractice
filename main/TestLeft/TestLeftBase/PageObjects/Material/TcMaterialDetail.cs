using PageObjectInterfaces.Controls;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Material
{
    /// <summary>
    /// The detail area of the material category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcMaterialDetail : TcPageObjectBase, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "Material.Detail.Base" );

        public TiValueControl<string> Id => Find<TiValueControl<string>>( "Material.Detail.Base.Name" );
        public TiValueControl<string> Name => Find<TiValueControl<string>>( "Material.Detail.Base.ExternalName" );
        public TiValueControl<string> Abbreviation => Find<TiValueControl<string>>( "Material.Detail.Base.More.Abbreviation" );
        public TiValueControl<string> EModulus => Find<TiValueControl<string>>( "Material.Detail.Base.More.EModulus" );
        public TiValueControl<string> SpecificWeight => Find<TiValueControl<string>>( "Material.Detail.Base.More.SpecificWeight" );
        public TiValueControl<string> TensileStrengthMin => Find<TiValueControl<string>>( "Material.Detail.Base.More.TensileStrengthMin" );
        public TiValueControl<string> TensileStrength => Find<TiValueControl<string>>( "Material.Detail.Base.More.TensileStrength" );
        public TiValueControl<string> TensileStrengthMax => Find<TiValueControl<string>>( "Material.Detail.Base.More.TensileStrengthMax" );
    }
}
