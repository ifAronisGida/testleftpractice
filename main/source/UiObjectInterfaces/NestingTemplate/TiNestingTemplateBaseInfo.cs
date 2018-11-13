using HomeZone.UiObjectInterfaces.Controls;

namespace HomeZone.UiObjectInterfaces.NestingTemplate
{
    public interface TiNestingTemplateBaseInfo
    {
        TiValueControl<string> Name { get; }
        TiValueControl<string> RawMaterial { get; }
        
        TiValueControl<string> ID { get; }
    }
}
