using System;
using UiObjectInterfaces.Common;


namespace UiObjectInterfaces.NestingTemplate
{
    public interface TiNestingTemplates : TiDomain
    {
        TiNestingTemplateToolbar Toolbar { get; }
        TiNestingTemplateBaseInfo BaseInfo { get; }
        TiNestingTemplatePartList PartList { get; }

        void WaitForOverlayDisappear( TimeSpan timeout );
    }
}
