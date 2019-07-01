using HomeZone.UiObjectInterfaces.Controls;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;


namespace HomeZone.UiObjects.PageObjects.Shell
{
    public enum TeDomain
    {
        Part,
        PartOrder,
        CutJob,
        Material,
        Workplace,
        JobTemplate
    }

    /// <summary>
    /// The domains and filters PageObject.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="IChildOf{T}" />
    public class TcDomainsAndFilters : TcPageObjectBase, IChildOf<TcMainTabControl>
    {
        protected override Search SearchPattern => Search.ByUid( "DomainsAndFilters" );

        private TiButton PartOrder => Find<TiButton>( "DomainSelector.PART_ORDER" );
        private TiButton CutJob => Find<TiButton>( "DomainSelector.CUT_JOB" );
        private TiButton Part => Find<TiButton>( "DomainSelector.PART" );
        private TiValueControl<int> More => Find<TiValueControl<int>>( "DomainSelectorsList2" );

        public void GotoDomain( TeDomain target )
        {
            switch( target )
            {
                case TeDomain.Part:
                    Part.Click();
                    break;
                case TeDomain.PartOrder:
                    PartOrder.Click();
                    break;
                case TeDomain.CutJob:
                    CutJob.Click();
                    break;
                case TeDomain.Material:
                    More.Value = 0;
                    break;
                case TeDomain.Workplace:
                    More.Value = 1;
                    break;
                case TeDomain.JobTemplate:
                    More.Value = 2;
                    break;
            }
        }
    }
}
