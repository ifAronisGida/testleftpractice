using HomeZone.UiObjectInterfaces.CutJob;
using HomeZone.UiObjects.TestSettings;

namespace HomeZone.UiCommonFunctions.PageObjectHelpers
{
    public class TcCutJobHelper
    {
        /// <summary>
        /// Delete all test cut jobs
        /// </summary>
        /// <param name="testSettings">test settings</param>
        /// <param name="cutJobs">cut jobs page</param>
        public void DeleteTestCutJobs( TcTestSettings testSettings, TiCutJobs cutJobs )
        {
            cutJobs.Goto();
            cutJobs.ResultColumn.SelectItems( testSettings.NamePrefix );
            if( cutJobs.ResultColumn.Count > 0 )
            {
                cutJobs.Toolbar.Delete();
            }
            cutJobs.ResultColumn.ClearSearch();
        }
    }
}
