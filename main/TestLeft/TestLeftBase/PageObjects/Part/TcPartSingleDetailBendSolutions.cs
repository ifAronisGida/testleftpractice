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
    }
}
