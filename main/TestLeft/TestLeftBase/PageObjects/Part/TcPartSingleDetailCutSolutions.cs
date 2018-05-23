using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Shell;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// The cut solutions area of the part category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcPartSingleDetailCutSolutions : PageObject, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "Part.Detail.CutSolutions" );

        private TcTruIconButton NewButton => Find<TcTruIconButton>( Search.ByUid( "Part.Detail.CutSolutions.AddSolution" ) );

        /// <summary>
        /// Creates a new cut solution.
        /// </summary>
        public void New()
        {
            NewButton.Click();
        }
    }
}
