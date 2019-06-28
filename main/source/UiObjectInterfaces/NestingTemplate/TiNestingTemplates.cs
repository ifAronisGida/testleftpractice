using System;
using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.NestingTemplate
{
    public interface TiNestingTemplates : TiDomain<TiNestingTemplateToolbar>
    {
        TiNestingTemplateBaseInfo BaseInfo { get; }
        TiNestingTemplatePartList PartList { get; }
    }
}
