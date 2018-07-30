using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trumpf.PageObjects;


namespace TestLeft.TestLeftBase.PageObjects.Settings
{
    /// <summary>
    /// The settings dialog.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.RepeaterObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    public class TcSettings : RepeaterObject, IChildOf<TcHomeZoneApp>
    {
        public override void Goto()
        {
            //IDriver driver = new LocalDriver();

            //IControl menuItem = driver.Find<IProcess>( new ProcessPattern()
            //{
            //    ProcessName = "Trumpf.TruTops.Control.Shell"
            //} ).Find<IControl>( new WPFPattern()
            //{
            //    ClrFullClassName = "Trumpf.TruTops.Control.Shell.Views.TcShellView"
            //}, 2 ).Find<IWPFMenu>( new WPFPattern()
            //{
            //    ClrFullClassName = "System.Windows.Controls.Menu"
            //}, 13 ).Find<IControl>( new WPFPattern()
            //{
            //    ClrFullClassName = "System.Windows.Controls.MenuItem",
            //    WPFControlText = "xxx"
            //} );
        }
    }
}
