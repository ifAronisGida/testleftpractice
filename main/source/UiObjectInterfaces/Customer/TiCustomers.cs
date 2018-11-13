using HomeZone.UiObjectInterfaces.Controls;

namespace HomeZone.UiObjectInterfaces.Customer
{
    public interface TiCustomers
    {
        void Goto();

        TiValueControl<string> City { get; }
        TiValueControl<string> Comment { get; }
        TiValueControl<string> Country { get; }
        TiValueControl<string> Id { get; }
        TiValueControl<string> Name { get; }
        TiValueControl<string> PostalCode { get; }
        TiValueControl<string> Street { get; }

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
        void NewCustomer( string name, string id, string street, string postalCode, string city, string country, string comment );

        /// <summary>
        /// Clicks on the apply button.
        /// </summary>
        void Apply();

        /// <summary>
        /// Clicks on the cancel button.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Clicks on the select button.
        /// </summary>
        void Select();

        /// <summary>
        /// Returns the amount of customers.
        /// </summary>
        /// <returns>The amount of customers.</returns>
        int Count();

        /// <summary>
        /// Returns the amount of currently selected customers.
        /// </summary>
        /// <returns>The amount of currently selected customers.</returns>
        int SelectedCustomersCount();

        /// <summary>
        /// Selects the customer with the given name.
        /// </summary>
        /// <param name="name">The name of the customer to select.</param>
        /// <returns>true if successful</returns>
        bool SelectCustomer( string name );

        /// <summary>
        /// Selects customers whose names contain the given substring.
        /// </summary>
        /// <param name="substring">The substring to search for.</param>
        void SelectOnlyCustomersWithNameContaining( string substring );

        /// <summary>
        /// Deletes customers with the given name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>true if successful</returns>
        bool DeleteCustomer( string name );

        /// <summary>
        /// Deletes customers whose names contain the given substring.
        /// Used to remove customers created for tests.
        /// </summary>
        /// <param name="substring">The substring to search for.</param>
        void DeleteCustomersWithNameContaining( string substring );

        /// <summary>
        /// Deletes the selected customers.
        /// </summary>
        void DeleteSelectedCustomers();
    }
}
