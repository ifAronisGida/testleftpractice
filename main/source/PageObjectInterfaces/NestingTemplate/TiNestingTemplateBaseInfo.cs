using PageObjectInterfaces.Controls;

namespace PageObjectInterfaces.NestingTemplate
{
    public interface TiNestingTemplateBaseInfo
    {
        TiValueControl<string> Name { get; }
        TiValueControl<string> RawMaterial { get; }
        
        TiValueControl<string> ID { get; }
    }
}
