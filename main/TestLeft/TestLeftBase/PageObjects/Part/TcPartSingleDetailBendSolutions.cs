using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// The bend solutions area of the part category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcPartSingleDetailBendSolutions : PageObject, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "Part.Detail.BendSolutions" );

        private IListBox BendSolutionList => Node.Find<IListBox>( Search.ByUid( "Part.Detail.BendSolutions.List" ) );
        private TcTruIconButton NewButton => Find<TcTruIconButton>( Search.ByUid( "Part.Detail.BendSolutions.AddSolution" ) );

        /// <summary>
        /// Creates a new bend solution.
        /// </summary>
        public void New()
        {
            NewButton.Click();
        }

        public int Count => BendSolutionList.wItemCount;

        public void OpenBendSolution( string name )
        {
            var openButton = BendSolutionList.Find<IButton>( Search.ByUid( "Part.Detail.BendSolutions.List." + name + ".Detail.OpenSolution" ), 5 );
            if( openButton.VisibleOnScreen )
            {
                openButton.Click();
            }
        }
        /*
                IDriver driver = new LocalDriver();

                IControl tcTruIconButton = driver.Find<IProcess>(new ProcessPattern()
                {
                    ProcessName = "Trumpf.TruTops.Control.Shell"
                }).Find<IControl>(new WPFPattern()
                {
                    ClrFullClassName = "Trumpf.TruTops.Control.Shell.Views.TcShellView"
                }, 2).Find<IControl>(new WPFPattern()
                {
                    WPFControlName = "MainTabControl"
                }, 12).Find<IListBox>(new WPFPattern()
                {
                    WPFControlName = "BendSolutionListe"
                }, 15).Find<IControl>(new WPFPattern()
                {
                    Uid = "Part.Detail.BendSolutions.List.Bend1.Detail.OpenSolution"
                }, 5);

                object uidValue = tcTruIconButton.GetProperty<object>("Uid");
                */
    }
}
