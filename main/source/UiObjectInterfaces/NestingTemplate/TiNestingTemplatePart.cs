using UiObjectInterfaces.Controls;


namespace UiObjectInterfaces.NestingTemplate
{
    public interface TiNestingTemplatePart
    {
        TiButton PartLink { get; }
        int Quantity { get; }
        string CuttingProgram { get; }
    }
}
