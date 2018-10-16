using System;
using PageObjectInterfaces.Controls;
using PageObjectInterfaces.NestingTemplate;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.NestingTemplate
{
    internal class TcNestingTemplateBaseInfo : TcExpandablePageObject, IChildOf<TcNestingTemplates>, TiNestingTemplateBaseInfo
    {
        public TiValueControl<string> Name => Find<TiValueControl<string>>( "CutJobTemplate.Detail.Base.Description" );
        public TiValueControl<string> RawMaterial => Find<TiValueControl<string>>( "CutJobTemplate.Detail.Base.RawMaterial" );
        public TiValueControl<string> ID => Find<TiValueControl<string>>( "CutJobTemplate.Detail.Base.Name", expandOnAccess: true );

        protected override Search SearchPattern => Search.ByUid( "CutJobTemplate.Detail.Base" );
    }
}
