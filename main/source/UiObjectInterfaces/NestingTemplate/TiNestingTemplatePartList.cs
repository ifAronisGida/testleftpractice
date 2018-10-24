namespace UiObjectInterfaces.NestingTemplate
{
    public interface TiNestingTemplatePartList
    {
        int PartCount { get; }

        TiNestingTemplatePart GetRow( int index );
    }
}
