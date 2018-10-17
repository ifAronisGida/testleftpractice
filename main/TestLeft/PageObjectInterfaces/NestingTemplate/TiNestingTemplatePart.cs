using PageObjectInterfaces.Controls;

namespace PageObjectInterfaces.NestingTemplate
{
    public interface TiNestingTemplatePart
    {
        TiButton PartLink { get; }
        int Quantity { get; }
        string CuttingProgram { get; }
    }
}
