using System;
using UiObjectInterfaces.Controls;
using UiObjectInterfaces.Customer;


namespace UiObjectInterfaces.Part
{
    public interface TiPartSingleDetail
    {
        TiValueControl<string> Name { get; }
        TiValueControl<string> DrawingNumber { get; }
        TiValueControl<string> DrawingVersion { get; }
        TiValueControl<string> ExternalName { get; }
        TiValueControl<string> Note { get; }

        /// <summary>
        /// Waits for name TextBox enabled.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        void WaitForNameEnabled( TimeSpan timeout );

        /// <summary>
        /// Gets or sets the customer.
        /// The customer must exist already in the customer administration.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        string Customer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the more area is expanded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if more is expanded; otherwise, <c>false</c>.
        /// </value>
        bool IsMoreExpanded { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this part is archivable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if archivable; otherwise, <c>false</c>.
        /// </value>
        bool Archivable { get; set; }

        TiCustomers OpenCustomerAdministration();
    }
}
