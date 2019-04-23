#region HEADER
//--------------------------------------------------------------------------------------------------
// All rights reserved to TRUMPF GmbH + Co. KG, Germany
// -------------------------------------------------------------------------------------------------
//
//$File: $
//$Author: $
//$Revision: $ - $Date: $ 
// -------------------------------------------------------------------------------------------------
#endregion

#region USING

using HomeZone.UiObjectInterfaces.Dialogs;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;

#endregion

namespace HomeZone.UiObjects.PageObjects.Dialogs
{
    /// <summary>
    /// TcOpenFileDialog handles open file dialogs.
    /// </summary>
    /// <seealso cref="RepeaterObject" />
    public class TcOpenFileDialogBase : RepeaterObject, TiOpenFileDialog
    {
        // Remark: public class TcOpenFileDialog<T> : RepeaterObject, IChildOf<T>, TiOpenFileDialog where T : IPageObject lead to runtime problems. Therefore, inheritance has been chosen

        #region private constants
        #endregion

        #region constructor
        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Enters the given filename and clicks the open button.
        /// </summary>
        /// <param name="filename">The filename to enter.</param>
        /// <returns></returns>
        public bool SetFilename( string filename )
        {
            FindDialog().Cast<IOpenFileDialog>().OpenFile( filename );

            return true;
        }

        public void OpenAll(string directory)
        {
            var breadcrumb = FindBreadcrumb();
            breadcrumb.Click( breadcrumb.Width - 50, breadcrumb.Height / 2 );
            breadcrumb.Keys( directory );
            breadcrumb.Keys( "[Enter]" );

            var fileList = FindFileList();
            fileList.Click();
            fileList.Keys( "[Home]^![End][Enter]" );
        }

        #endregion

        #region private methods
        private IControl FindBreadcrumb()
        {
            return Node.Find<IControl>( new WindowPattern()
            {
                WndClass = "msctls_progress32"
            } );
        }

        private IControl FindFileList()
        {
            var pattern = new ControlPattern();
            pattern.Add( "AutomationId", "FolderLayoutContainer" );

            return Node.Find<IControl>( pattern );
        }

        private IWindow FindDialog() => Parent.Node.Find<IWindow>( new WindowPattern { WndClass = "#32770" }, 1 );
        #endregion

        #region public static members
        #endregion

        #region private static members
        #endregion

        #region private members
        #endregion

        #region properties
        #endregion
    }
}
