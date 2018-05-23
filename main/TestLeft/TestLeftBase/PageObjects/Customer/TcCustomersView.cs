using SmartBear.TestLeft.TestObjects.WPF;
using SmartBear.TestLeft.TestObjects.WPF.DevExpress;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Customer
{
    /// <summary>
    /// TcCustomersView provides access to the controls of the customer view.
    /// It is used by <seealso cref="TcCustomers" />
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    internal class TcCustomersView : PageObject, IChildOf<TcHomeZoneApp>
    {
        protected override Search SearchPattern => Search.ByUid( "Customer" );

        internal IDevExpressWPFGridControl HierarchyPanel => Node.Find<IDevExpressWPFGridControl>( new WPFPattern()
        {
            ClrFullClassName = "DevExpress.Xpf.Grid.Hierarchy.HierarchyPanel"
        } );

        internal TcTruIconButton NewCustomerButton => Find<TcTruIconButton>( Search.ByUid( "Customer.Add" ) );
        internal TcTruIconButton DeleteCustomerButton => Find<TcTruIconButton>( Search.ByUid( "Customer.Delete" ) );
        internal TcGridControl CustomerGrid => Find<TcGridControl>( Search.ByUid( "Customer.List" ) );
        internal TcTruIconButton ApplyButton => Find<TcTruIconButton>( Search.ByUid( "Customer.Dialog.Apply" ) );
        internal TcTruIconButton CancelButton => Find<TcTruIconButton>( Search.ByUid( "Customer.Dialog.Cancel" ) );
        internal TcTruIconButton OkButton => Find<TcTruIconButton>( Search.ByUid( "Customer.Dialog.Ok" ) );

        internal TcTextEdit CityTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.City" ) );
        internal TcTextEdit CommentTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.Comment" ) );
        internal TcTextEdit CountryTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.Country" ) );
        internal TcTextEdit IdTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.No" ) );
        internal TcTextEdit NameTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.Name" ) );
        internal TcTextEdit PostalCodeTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.PostalCode" ) );
        internal TcTextEdit StreetTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.Street" ) );
    }
}
