using HomeZone.UiCommonFunctions.TestSettings;
using HomeZone.UiObjectInterfaces.Part;

namespace HomeZone.UiCommonFunctions.PageObjectHelpers
{
    public class TcPartHelper
    {
        public void ImportPart( TcTestSettings testSettings, TiParts parts, string filePath )
        {
            parts.Toolbar.Import( filePath );
            parts.WaitForDetailOverlayAppear();
            parts.WaitForDetailOverlayDisappear();
            parts.SingleDetail.Name.Value = testSettings.NamePrefix + parts.SingleDetail.Name.Value;
        }
        
        public void DeleteTestParts( TcTestSettings testSettings, TiParts parts )
        {
            parts.Goto();
            parts.ResultColumn.SelectItems( testSettings.NamePrefix );
            if( parts.ResultColumn.Count > 0 )
            {
                parts.Toolbar.Delete();
            }
            parts.ResultColumn.ClearSearch();
        }
    }
}
