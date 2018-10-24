using System;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;
using UiObjectInterfaces.Customer;
using UiObjectInterfaces.Dialogs;
using UiObjects.ControlObjects;
using UiObjects.ControlObjects.Grid;
using UiObjects.PageObjects.Dialogs;
using UiObjects.PageObjects.Part;


namespace UiObjects.PageObjects.Customer
{
    /// <summary>
    /// Customers can be administrated here.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    public class TcCustomers : TcPageObjectBase, IChildOf<TcHomeZoneApp>, TiCustomers
    {
        protected override Search SearchPattern => Search.ByUid( "Customer" );

        internal readonly Lazy<TcOptimizedTableView<TcCustomerRow>> mTableView;

        private TcParts mParts;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcCustomers"/> class.
        /// </summary>
        public TcCustomers()
        {
            mTableView = new Lazy<TcOptimizedTableView<TcCustomerRow>>( () => CustomerGrid.GetOptimizedTableView( underlyingRow => new TcCustomerRow( underlyingRow ) ) );
        }

        public TiValueControl<string> City => Find<TiValueControl<string>>( "Customer.Detail.City" );
        public TiValueControl<string> Comment => Find<TiValueControl<string>>( "Customer.Detail.Comment" );
        public TiValueControl<string> Country => Find<TiValueControl<string>>( "Customer.Detail.Country" );
        public TiValueControl<string> Id => Find<TiValueControl<string>>( "Customer.Detail.No" );
        public TiValueControl<string> Name => Find<TiValueControl<string>>( "Customer.Detail.Name" );
        public TiValueControl<string> PostalCode => Find<TiValueControl<string>>( "Customer.Detail.PostalCode" );
        public TiValueControl<string> Street => Find<TiValueControl<string>>( "Customer.Detail.Street" );

        private TiButton NewCustomerButton => Find<TiButton>( "Customer.Add" );
        private TiButton DeleteCustomerButton => Find<TiButton>( "Customer.Delete" );
        private TcGridControl CustomerGrid => Find<TcGridControl>( Search.ByUid( "Customer.List" ) );
        private TiButton ApplyButton => Find<TiButton>( "Customer.Dialog.Apply" );
        private TiButton CancelButton => Find<TiButton>( "Customer.Dialog.Cancel" );
        private TiButton OkButton => Find<TiButton>( "Customer.Dialog.Ok" );

        /// <summary>
        /// The customer administration dialog is not direct accessible, only via button click in several detail views.
        /// Here we are using the access via part details. So we must switch to parts, create a new part and press the
        /// CustomerOpenAdministrationButton.
        /// To delete the temporary part, CleanUp() should be called afterwards.
        /// </summary>
        public override void Goto()
        {
            if( !VisibleOnScreen )
            {
                mParts = Goto<TcParts>();
                mParts.Toolbar.New();
                mParts.SingleDetail.OpenCustomerAdministration();
            }
        }

        /// <summary>
        /// Creates a new Customer.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="street">The street.</param>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="city">The city.</param>
        /// <param name="country">The country.</param>
        /// <param name="comment">The comment.</param>
        public void NewCustomer( string name, string id, string street, string postalCode, string city, string country, string comment )
        {
            Goto();

            if( SelectedCustomersCount() == 0 )
            {
                CustomerGrid.SelectItem( 0 );
            }

            if( !string.IsNullOrEmpty( Name.Value ) )
            {
                NewCustomerButton.Click();
            }

            Name.Value = name;
            if( !string.IsNullOrEmpty( id ) )
            {
                Id.Value = id;
            }
            Street.Value = street;
            PostalCode.Value = postalCode;
            City.Value = city;
            Country.Value = country;
            Comment.Value = comment;
        }

        /// <summary>
        /// Clicks on the apply button.
        /// </summary>
        public void Apply()
        {
            ApplyButton.Click();
        }

        /// <summary>
        /// Clicks on the cancel button.
        /// </summary>
        public void Cancel()
        {
            CancelButton.Enabled.WaitFor( TimeSpan.FromSeconds( 10 ) );
            CancelButton.Click();
            CleanUp();
        }

        /// <summary>
        /// Clicks on the select button.
        /// </summary>
        public void Select()
        {
            OkButton.Click();
            CleanUp();
        }

        /// <summary>
        /// Returns the amount of customers.
        /// </summary>
        /// <returns>The amount of customers.</returns>
        public int Count()
        {
            return CustomerGrid.RowCount;
        }

        /// <summary>
        /// Returns the amount of currently selected customers.
        /// </summary>
        /// <returns>The amount of currently selected customers.</returns>
        public int SelectedCustomersCount()
        {
            return CustomerGrid.SelectedCount;
        }

        /// <summary>
        /// Selects the customer with the given name.
        /// </summary>
        /// <param name="name">The name of the customer to select.</param>
        /// <returns>true if successful</returns>
        public bool SelectCustomer( string name )
        {
            var count = Count();

            CustomerGrid.UnselectAll();

            for( var rowIndex = 0; rowIndex < count; rowIndex++ )
            {
                var tableRow = mTableView.Value.GetRow( rowIndex );
                if( tableRow.Name == name )
                {
                    CustomerGrid.SelectItem( rowIndex );

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Selects customers whose names contain the given substring.
        /// </summary>
        /// <param name="substring">The substring to search for.</param>
        public void SelectOnlyCustomersWithNameContaining( string substring )
        {
            var count = Count();

            CustomerGrid.UnselectAll();

            for( var rowIndex = 0; rowIndex < count; rowIndex++ )
            {
                var tableRow = mTableView.Value.GetRow( rowIndex );
                if( tableRow.Name.Contains( substring ) )
                {
                    CustomerGrid.SelectItem( rowIndex );
                }
            }
        }

        /// <summary>
        /// Deletes customers with the given name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>true if successful</returns>
        public bool DeleteCustomer( string name )
        {
            if( !SelectCustomer( name ) )
            {
                return false;
            }

            DeleteSelectedCustomers();
            return true;
        }

        /// <summary>
        /// Deletes customers whose names contain the given substring.
        /// Used to remove customers created for tests.
        /// </summary>
        /// <param name="substring">The substring to search for.</param>
        public void DeleteCustomersWithNameContaining( string substring )
        {
            SelectOnlyCustomersWithNameContaining( substring );

            DeleteSelectedCustomers();
        }

        /// <summary>
        /// Deletes the selected customers.
        /// </summary>
        public void DeleteSelectedCustomers()
        {
            if( SelectedCustomersCount() > 0 )
            {
                DeleteCustomerButton.Click();

                var dialog = On<TiMessageBox, TcMessageBox>();
                if( dialog.MessageBoxExists() )
                {
                    dialog.Yes();
                }
            }
        }

        /// <summary>
        /// Deletes the temporarily created part.
        /// See summary of Goto().
        /// </summary>
        private void CleanUp()
        {
            mParts?.Toolbar.Delete();

            var dialog = On<TiMessageBox, TcMessageBox>();
            if( dialog != null && dialog.MessageBoxExists() )
            {
                dialog.Yes();
            }
        }
    }
}
