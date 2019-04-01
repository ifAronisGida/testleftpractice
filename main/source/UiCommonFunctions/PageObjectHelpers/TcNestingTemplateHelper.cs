using HomeZone.UiObjects.TestSettings;
using HomeZone.UiObjectInterfaces.NestingTemplate;

namespace HomeZone.UiCommonFunctions.PageObjectHelpers
{
    public class TcNestingTemplateHelper
    {
        /// <summary>
        /// Delete all test nesting templates
        /// </summary>
        /// <param name="testSettings">test settings</param>
        /// <param name="nestingTemplate">nesting template page</param>
        public void DeleteTestNestingTemplates( TcTestSettings testSettings, TiNestingTemplates nestingTemplate )
        {
            nestingTemplate.Goto();
            nestingTemplate.ResultColumn.SelectItems( testSettings.NamePrefix );
            if( nestingTemplate.ResultColumn.Count > 0 )
            {
                nestingTemplate.Toolbar.Delete();
            }
            nestingTemplate.ResultColumn.ClearSearch();
        }
    }
}
