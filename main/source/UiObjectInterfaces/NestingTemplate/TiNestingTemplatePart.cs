using HomeZone.UiObjectInterfaces.Controls;

namespace HomeZone.UiObjectInterfaces.NestingTemplate
{
    public interface TiNestingTemplatePart
    {
        TiButton PartLink { get; }
        int Quantity { get; }
        string CuttingProgram { get; }
    }
}
