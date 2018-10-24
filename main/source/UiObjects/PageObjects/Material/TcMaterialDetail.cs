using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;
using UiObjectInterfaces.Material;
using UiObjects.PageObjects.Shell;
using UiObjects.Utilities;


namespace UiObjects.PageObjects.Material
{
    /// <summary>
    /// The detail area of the material category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcMaterialDetail : PageObject, IChildOf<TcDetailContent>, TiMaterialDetail
    {
        protected override Search SearchPattern => Search.ByUid( "Material.Detail.Base" );
        public TiValueControl<string> Id => this.FindMapped<TiValueControl<string>>( "Material.Detail.Base.Name" );
        public TiValueControl<string> Name => this.FindMapped<TiValueControl<string>>( "Material.Detail.Base.ExternalName" );
        public TiValueControl<string> Abbreviation => this.FindMapped<TiValueControl<string>>( "Material.Detail.Base.More.Abbreviation" );
        public TiValueControl<string> EModulus => this.FindMapped<TiValueControl<string>>( "Material.Detail.Base.More.EModulus" );
        public TiValueControl<string> SpecificWeight => this.FindMapped<TiValueControl<string>>( "Material.Detail.Base.More.SpecificWeight" );
        public TiValueControl<string> TensileStrengthMin => this.FindMapped<TiValueControl<string>>( "Material.Detail.Base.More.TensileStrengthMin" );
        public TiValueControl<string> TensileStrength => this.FindMapped<TiValueControl<string>>( "Material.Detail.Base.More.TensileStrength" );
        public TiValueControl<string> TensileStrengthMax => this.FindMapped<TiValueControl<string>>( "Material.Detail.Base.More.TensileStrengthMax" );
    }
}
