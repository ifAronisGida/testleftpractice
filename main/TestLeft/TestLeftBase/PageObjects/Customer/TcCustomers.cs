using System;
using SmartBear.TestLeft.TestObjects.WPF;
using SmartBear.TestLeft.TestObjects.WPF.DevExpress;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.ControlObjects.Grid;
using Trumpf.PageObjects;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Part;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Customer
{
    /// <summary>
    /// Customers can be administrated here.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    public class TcCustomers : PageObject, IChildOf<TcHomeZoneApp>
    {
        protected override Search SearchPattern => Search.ByUid( "Customer" );

        internal readonly Lazy<TcTableView<TcCustomerRow>> mTableView;

        private TcParts mParts;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcCustomers"/> class.
        /// </summary>
        public TcCustomers()
        {
            mTableView = new Lazy<TcTableView<TcCustomerRow>>( () => CustomerGrid.GetTableView( underlyingRow => new TcCustomerRow( underlyingRow ) ) );
        }

        private IDevExpressWPFGridControl HierarchyPanel => Node.Find<IDevExpressWPFGridControl>( new WPFPattern()
        {
            ClrFullClassName = "DevExpress.Xpf.Grid.Hierarchy.HierarchyPanel"
        } );

        private TcTruIconButton NewCustomerButton => Find<TcTruIconButton>( Search.ByUid( "Customer.Add" ) );
        private TcTruIconButton DeleteCustomerButton => Find<TcTruIconButton>( Search.ByUid( "Customer.Delete" ) );
        private TcGridControl CustomerGrid => Find<TcGridControl>( Search.ByUid( "Customer.List" ) );
        private TcTruIconButton ApplyButton => Find<TcTruIconButton>( Search.ByUid( "Customer.Dialog.Apply" ) );
        private TcTruIconButton CancelButton => Find<TcTruIconButton>( Search.ByUid( "Customer.Dialog.Cancel" ) );
        private TcTruIconButton OkButton => Find<TcTruIconButton>( Search.ByUid( "Customer.Dialog.Ok" ) );
        private TcTextEdit CityTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.City" ) );
        private TcTextEdit CommentTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.Comment" ) );
        private TcTextEdit CountryTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.Country" ) );
        private TcTextEdit IdTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.No" ) );
        private TcTextEdit NameTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.Name" ) );
        private TcTextEdit PostalCodeTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.PostalCode" ) );
        private TcTextEdit StreetTextEdit => Find<TcTextEdit>( Search.ByUid( "Customer.Detail.Street" ) );

        /// <summary>
        /// The customer administration dialog is not direct accessible, only via button click in several detail views.
        /// Here we are using the access via part details. So we must switch to parts, create a new part and press the
        /// CustomerOpenAdministrationButton.
        /// To delete the temporary part, CleanUp() should be called afterwards.
        /// </summary>
        public override void Goto()
        {
            if( VisibleOnScreen )
            {
                return;
            }

            mParts = Goto<TcParts>();
            mParts.NewPart();
            mParts.SingleDetail.CustomerOpenAdministrationButton.Click();
        }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get => NameTextEdit.Text;
            set => NameTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the identifier of the customer.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string ID
        {
            get => IdTextEdit.Text;
            set => IdTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the address of the customer.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address
        {
            get => StreetTextEdit.Text;
            set => StreetTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the postal code of the customer.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public string PostalCode
        {
            get => PostalCodeTextEdit.Text;
            set => PostalCodeTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the city of the customer.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City
        {
            get => CityTextEdit.Text;
            set => CityTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the country of the customer.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country
        {
            get => CountryTextEdit.Text;
            set => CountryTextEdit.Text = value;
        }

        /// <summary>
        /// Gets or sets the comment about the customer.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment
        {
            get => CommentTextEdit.Text;
            set => CommentTextEdit.Text = value;
        }

        /// <summary>
        /// Creates a new Customer.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="address">The address.</param>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="city">The city.</param>
        /// <param name="country">The country.</param>
        /// <param name="comment">The comment.</param>
        public void NewCustomer( string name, string id, string address, string postalCode, string city, string country, string comment )
        {
            Goto();

            if( !string.IsNullOrEmpty( Name ) )
            {
                NewCustomerClick();
            }

            Name = name;
            if( !string.IsNullOrEmpty( id ) )
            {
                ID = id;
            }
            Address = address;
            PostalCode = postalCode;
            City = city;
            Country = country;
            Comment = comment;
        }

        /// <summary>
        /// Clicks on the new customer button.
        /// </summary>
        public void NewCustomerClick()
        {
            NewCustomerButton.Click();
        }

        /// <summary>
        /// Clicks on the delete button.
        /// </summary>
        public void DeleteCustomerClick()
        {
            DeleteCustomerButton.Click();
        }

        /// <summary>
        /// Clicks on the apply button.
        /// </summary>
        public void ApplyClick()
        {
            ApplyButton.Click();
        }

        /// <summary>
        /// Clicks on the cancel button.
        /// </summary>
        public void CancelClick()
        {
            CancelButton.Click();
            CleanUp();
        }

        /// <summary>
        /// Clicks on the select button.
        /// </summary>
        public void SelectClick()
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
            return HierarchyPanel.Children.Count;
        }

        /// <summary>
        /// Returns the amount of currently selected customers.
        /// </summary>
        /// <returns>The amount of currently selected customers.</returns>
        public int SelectedCustomersCount()
        {
            return CustomerGrid.Node.GetProperty<int>( "SelectedItems.Count" );
        }

        /// <summary>
        /// Selects the customer with the given name.
        /// </summary>
        /// <param name="name">The name of the customer to select.</param>
        public void SelectCustomer( string name )
        {
            int count = Count();

            CustomerGrid.Node.CallMethod( "UnselectAll" );

            for( int row = 0; row < count; row++ )
            {
                var rowControl = HierarchyPanel.Children[ row ];
                var text = rowControl.Children[ 0 ].Children[ 5 ].Children[ 0 ].GetProperty<string>( "DisplayText" );
                if( text == name )
                {
                    CustomerGrid.Node.CallMethod( "SelectItem", rowControl.GetProperty<int>( "WPFControlIndex" ) - 1 );

                    break;
                }
            }
        }

        /// <summary>
        /// Selects customers whose names contain the given substring.
        /// </summary>
        /// <param name="substring">The substring to search for.</param>
        public void SelectOnlyCustomersWithNameContaining( string substring )
        {
            int count = Count();

            CustomerGrid.Node.CallMethod( "UnselectAll" );

            for( int row = 0; row < count; row++ )
            {
                var rowControl = HierarchyPanel.Children[ row ];
                var text = rowControl.Children[ 0 ].Children[ 5 ].Children[ 0 ].GetProperty<string>( "DisplayText" );
                if( text.Contains( substring ) )
                {
                    CustomerGrid.Node.CallMethod( "SelectItem", rowControl.GetProperty<int>( "WPFControlIndex" ) - 1 );
                }
            }
        }

        /// <summary>
        /// Deletes customers whose names contain the given substring.
        /// Used to remove customers created for tests.
        /// </summary>
        /// <param name="substring">The substring to search for.</param>
        public void DeleteCustomersWithNameContaining( string substring )
        {
            SelectOnlyCustomersWithNameContaining( substring );

            if( SelectedCustomersCount() > 0 )
            {
                DeleteCustomerClick();

                var dialog = On<TcMessageBox>();
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
        public void CleanUp()
        {
            mParts?.Toolbar.DeleteButton.Click();

            var dialog = On<TcMessageBox>();
            if( dialog != null && dialog.MessageBoxExists() )
            {
                dialog.YesButton.Click();
            }
        }
    }
}
