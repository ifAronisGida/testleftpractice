using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using TestLeft.TestLeftBase.ControlObjects;

namespace TestLeft.TestLeftBase.PageObjects.Shell
{
    /// <summary>
    /// The domains / categories PageObject.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDomainsAndFilters}" />
    public class TcDomains : PageObject, IChildOf<TcDomainsAndFilters>
    {
        protected override Search SearchPattern => Search.ByUid( "DomainSelectorsList" );

        /// <summary>
        /// Gets the part order selector.
        /// </summary>
        /// <value>
        /// The part order.
        /// </value>
        public TcDomainSelector PartOrder => Find<TcDomainSelector>( Search.ByUid( "DomainSelector.PART_ORDER" ) );

        /// <summary>
        /// Gets the cut job selector.
        /// </summary>
        /// <value>
        /// The cut job.
        /// </value>
        public TcDomainSelector CutJob => Find<TcDomainSelector>( Search.ByUid( "DomainSelector.CUT_JOB" ) );

        /// <summary>
        /// Gets the part selector.
        /// </summary>
        /// <value>
        /// The part.
        /// </value>
        public TcDomainSelector Part => Find<TcDomainSelector>( Search.ByUid( "DomainSelector.PART" ) );
    }
}
