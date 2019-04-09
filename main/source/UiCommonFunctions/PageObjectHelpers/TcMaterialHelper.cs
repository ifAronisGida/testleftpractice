using HomeZone.UiObjectInterfaces.Material;
using HomeZone.UiObjects.TestSettings;

namespace HomeZone.UiCommonFunctions.PageObjectHelpers
{
    public class TcMaterialHelper
    {
        /// <summary>
        /// Delete all test materials
        /// </summary>
        /// <param name="testSettings">test settings</param>
        /// <param name="materials">materials page</param>
        public void DeleteTestMaterials( TcTestSettings testSettings, TiMaterials materials )
        {
            materials.Goto();
            materials.ResultColumn.SelectItems( testSettings.NamePrefix );
            if( materials.ResultColumn.Count > 0 )
            {
                materials.Toolbar.Delete();
            }
            materials.ResultColumn.ClearSearch();
        }
    }
}
