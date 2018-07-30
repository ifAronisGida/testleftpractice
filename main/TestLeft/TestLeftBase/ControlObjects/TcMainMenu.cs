using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The main menu.
    /// </summary>
    /// <seealso cref="ControlObject" />
    public class TcMainMenu : ControlObject
    {
        protected override Search SearchPattern => Search.Any;

        //IDriver driver = new LocalDriver();

        //IControl menuItem = driver.Find<IProcess>(new ProcessPattern()
        //{
        //    ProcessName = "Trumpf.TruTops.Control.Shell"
        //}).Find<IControl>(new WPFPattern()
        //{
        //    ClrFullClassName = "System.Windows.Controls.Primitives.PopupRoot"
        //}, 2).Find<IControl>(new WPFPattern()
        //{
        //    Uid = "ShellView.Menu.Settings"
        //}, 3);
    }
}
