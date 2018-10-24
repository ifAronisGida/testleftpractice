using UiObjectInterfaces.Controls;


namespace UiObjectInterfaces.Material
{
    public interface TiMaterialDetail
    {
        TiValueControl<string> Id { get; }
        TiValueControl<string> Name { get; }
        TiValueControl<string> Abbreviation { get; }
        TiValueControl<string> EModulus { get; }
        TiValueControl<string> SpecificWeight { get; }
        TiValueControl<string> TensileStrengthMin { get; }
        TiValueControl<string> TensileStrength { get; }
        TiValueControl<string> TensileStrengthMax { get; }
    }
}
