using PageObjectInterfaces.Controls;
using PageObjectInterfaces.Part;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// The cut solutions area of the part category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcPartSingleDetailCutSolutions : TcPageObjectBase, IChildOf<TcDetailContent>, TiPartSingleDetailCutSolutions
    {
        protected override Search SearchPattern => Search.ByUid( "Part.Detail.CutSolutions" );

        private IListBox CutSolutionList => Node.Find<IListBox>( Search.ByUid( "Part.Detail.CutSolutions.List" ) );
        private TiButton NewButton => Find<TiButton>( "Part.Detail.CutSolutions.AddSolution" );

        /// <summary>
        /// Creates a new cut solution.
        /// </summary>
        public void New()
        {
            NewButton.Click();
        }

        public int Count => CutSolutionList.wItemCount;

        public void OpenCutSolution( string name )
        {
            var openButton = CutSolutionList.Find<IButton>( Search.ByUid( "Part.Detail.CutSolutions.List." + name + ".OpenSolution" ), 5 );
            if( openButton.VisibleOnScreen )
            {
                openButton.Click();
            }
        }
    }
}
