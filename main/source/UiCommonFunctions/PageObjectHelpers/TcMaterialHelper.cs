﻿using HomeZone.UiCommonFunctions.TestSettings;
using HomeZone.UiObjectInterfaces.Shell;
using HomeZone.UiObjectInterfaces.Material;
using System;

namespace HomeZone.UiCommonFunctions.PageObjectHelpers
{
    public class TcMaterialHelper
    {
        /// <summary>
        /// Delete all test materials
        /// </summary>
        /// <param name="testSettings">test settings</param>
        /// <param name="materials">materials page</param>
        public void DeleteTestMaterials( TcTestSettings testSettings, TiMaterials materials, TiMainTabControl mainTab )
        {
            materials.Goto();
            materials.ResultColumn.SelectItems( testSettings.NamePrefix );
            if( materials.ResultColumn.Count > 0 )
            {
                materials.Toolbar.Delete();
                mainTab.WaitForTabOverlayDisappear( TimeSpan.FromMinutes( 1 ) );
            }
            materials.ResultColumn.ClearSearch();
        }
    }
}
