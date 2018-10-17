using System;
using PageObjectInterfaces.Common;

namespace PageObjectInterfaces.NestingTemplate
{
    public interface TiNestingTemplates : TiDomain
    {
        TiNestingTemplateToolbar Toolbar { get; }
        TiNestingTemplateBaseInfo BaseInfo { get; }
        TiNestingTemplatePartList PartList { get; }

        void WaitForOverlayDisappear( TimeSpan timeout );
    }
}
