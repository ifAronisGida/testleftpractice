namespace PageObjectInterfaces.NestingTemplate
{
    public interface TiNestingTemplatePartList
    {
        int PartCount { get; }

        TiNestingTemplatePart GetRow( int index );
    }
}
