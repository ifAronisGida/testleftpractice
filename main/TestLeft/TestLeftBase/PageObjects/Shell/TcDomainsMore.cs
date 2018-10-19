using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Shell
{
    /// <summary>
    /// Some categories are hidden inside the more area.
    /// With this class we get access to materials, workplaces and cut job templates.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDomainsAndFilters}" />
    public class TcDomainsMore : PageObject, IChildOf<TcDomainsAndFilters>
    {
        protected override Search SearchPattern => Search.ByUid( "DomainSelectorsList2" );

        /// <summary>
        /// Opens the category material.
        /// </summary>
        public void GotoMaterial()
        {
            Node.SetProperty( "SelectedIndex", 0 );
        }

        /// <summary>
        /// Opens the category workplace.
        /// </summary>
        public void GotoWorkplace()
        {
            Node.SetProperty( "SelectedIndex", 1 );
        }

        /// <summary>
        /// Opens the category cut job template.
        /// </summary>
        public void GotoCutJobTemplate()
        {
            Node.SetProperty( "SelectedIndex", 2 );
        }
    }
}
