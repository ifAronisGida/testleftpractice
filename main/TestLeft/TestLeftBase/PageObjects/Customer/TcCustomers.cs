using Trumpf.PageObjects;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Part;

namespace TestLeft.TestLeftBase.PageObjects.Customer
{
    /// <summary>
    /// Customers can be administrated here.
    /// </summary>
    /// <seealso cref="RepeaterObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcHomeZoneApp}" />
    public class TcCustomers : RepeaterObject, IChildOf<TcHomeZoneApp>
    {
        private TcParts mParts;
        private TcCustomersView mCustomersView;

        /// <summary>
        /// The customer administration dialog is not direct accessible, only via button click in several detail views.
        /// Here we are using the access via part details. So we must switch to parts, create a new part and press the
        /// CustomerOpenAdministrationButton.
        /// To delete the temporary part, CleanUp() should be called afterwards.
        /// </summary>
        public override void Goto()
        {
            mParts = On<TcParts>();
            mParts.Goto();
            mParts.NewPart();
            mParts.SingleDetail.CustomerOpenAdministrationButton.Click();
            mCustomersView = On<TcCustomersView>();
            mCustomersView.VisibleOnScreen.WaitFor();
            //mCustomersView.NameTextEdit.VisibleOnScreen.WaitFor();
        }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return mCustomersView.NameTextEdit.Text;
            }
            set
            {
                mCustomersView.NameTextEdit.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the identifier of the customer.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string ID
        {
            get
            {
                return mCustomersView.IdTextEdit.Text;
            }
            set
            {
                mCustomersView.IdTextEdit.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the address of the customer.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address
        {
            get
            {
                return mCustomersView.StreetTextEdit.Text;
            }
            set
            {
                mCustomersView.StreetTextEdit.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the postal code of the customer.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public string PostalCode
        {
            get
            {
                return mCustomersView.PostalCodeTextEdit.Text;
            }
            set
            {
                mCustomersView.PostalCodeTextEdit.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the city of the customer.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City
        {
            get
            {
                return mCustomersView.CityTextEdit.Text;
            }
            set
            {
                mCustomersView.CityTextEdit.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the country of the customer.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country
        {
            get
            {
                return mCustomersView.CountryTextEdit.Text;
            }
            set
            {
                mCustomersView.CountryTextEdit.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the comment about the customer.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment
        {
            get
            {
                return mCustomersView.CommentTextEdit.Text;
            }
            set
            {
                mCustomersView.CommentTextEdit.Text = value;
            }
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
            if( mCustomersView == null )
            {
                Goto();
            }

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
            mCustomersView.NewCustomerButton.Click();
        }

        /// <summary>
        /// Clicks on the delete button.
        /// </summary>
        public void DeleteCustomerClick()
        {
            mCustomersView.DeleteCustomerButton.Click();
        }

        /// <summary>
        /// Clicks on the apply button.
        /// </summary>
        public void ApplyClick()
        {
            mCustomersView.ApplyButton.Click();
        }

        /// <summary>
        /// Clicks on the cancel button.
        /// </summary>
        public void CancelClick()
        {
            mCustomersView.CancelButton.Click();
            CleanUp();
        }

        /// <summary>
        /// Clicks on the select button.
        /// </summary>
        public void SelectClick()
        {
            mCustomersView.OkButton.Click();
            CleanUp();
        }

        /// <summary>
        /// Returns the amount of customers.
        /// </summary>
        /// <returns>The amount of customers.</returns>
        public int Count()
        {
            return mCustomersView.HierarchyPanel.Children.Count;
        }

        /// <summary>
        /// Returns the amount of currently selected customers.
        /// </summary>
        /// <returns>The amount of currently selected customers.</returns>
        public int SelectedCustomersCount()
        {
            return mCustomersView.CustomerGrid.Node.GetProperty<int>( "SelectedItems.Count" );
        }

        /// <summary>
        /// Selects the customer with the given name.
        /// </summary>
        /// <param name="name">The name of the customer to select.</param>
        public void SelectCustomer( string name )
        {
            int count = Count();

            mCustomersView.CustomerGrid.Node.CallMethod( "UnselectAll" );

            for( int row = 0; row < count; row++ )
            {
                var rowControl = mCustomersView.HierarchyPanel.Children[ row ];
                var text = rowControl.Children[ 0 ].Children[ 5 ].Children[ 0 ].GetProperty<string>( "DisplayText" );
                if( text == name )
                {
                    mCustomersView.CustomerGrid.Node.CallMethod( "SelectItem", rowControl.GetProperty<int>( "WPFControlIndex" ) - 1 );

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

            mCustomersView.CustomerGrid.Node.CallMethod( "UnselectAll" );

            for( int row = 0; row < count; row++ )
            {
                var rowControl = mCustomersView.HierarchyPanel.Children[ row ];
                var text = rowControl.Children[ 0 ].Children[ 5 ].Children[ 0 ].GetProperty<string>( "DisplayText" );
                if( text.Contains( substring ) )
                {
                    mCustomersView.CustomerGrid.Node.CallMethod( "SelectItem", rowControl.GetProperty<int>( "WPFControlIndex" ) - 1 );
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
