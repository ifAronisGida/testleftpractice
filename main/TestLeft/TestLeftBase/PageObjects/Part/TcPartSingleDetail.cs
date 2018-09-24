﻿using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.Utilities;
using TestLeft.TestLeftBase.PageObjects.Customer;

namespace TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// The upper detail area of the part category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcPartSingleDetail : PageObjectBase, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "Part.Details" );

        public TiValueControl<string> Name => Find<TiValueControl<string>>( "Part.Detail.Base.Description" );
        public TiValueControl<string> DrawingNumber => this.FindGeneric<TiValueControl<string>>( "Part.Detail.Base.DrawingNumber" );
        public TiValueControl<string> DrawingVersion => this.FindGeneric<TiValueControl<string>>( "Part.Detail.Base.DrawingVersion" );
        public TiValueControl<string> IdTextEdit => this.FindGeneric<TiValueControl<string>>( "Part.Detail.Base.Name" );
        public TiValueControl<string> ExternalName => this.FindGeneric<TiValueControl<string>>( "Part.Detail.Base.More.ExternalName" );
        public TiValueControl<string> Note => this.FindGeneric<TiValueControl<string>>( "Part.Detail.Base.More.Note" );
        private TiValueControl<string> CustomerLookUpEdit => Find<TiValueControl<string>>( "EditCustomerProperty.EditValue" );
        private TiButton CustomerOpenAdministrationButton => Find<TiButton>( "EditCustomerProperty.OpenAdministration" );
        private TcGroupPanel DetailGroupPanel => Find<TcGroupPanel>( Search.ByUid( "Part.Detail.Base" ) );
        private TiValueControl<bool> ArchivableCheckBox => this.FindGeneric<TiValueControl<bool>>( "Part.Detail.Archivable" );

        /// <summary>
        /// Waits for name TextBox enabled.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        public void WaitForNameEnabled( TimeSpan timeout )
        {
            Wait.For( () => Name.Enabled, timeout );
        }

        /// <summary>
        /// Gets or sets the customer.
        /// The customer must exist already in the customer administration.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public string Customer
        {
            set => CustomerLookUpEdit.Value = value;

            get => CustomerLookUpEdit.Value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the more area is expanded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if more is expanded; otherwise, <c>false</c>.
        /// </value>
        public bool IsMoreExpanded
        {
            set => DetailGroupPanel.IsMoreExpanded = value;

            get => DetailGroupPanel.IsMoreExpanded;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id
        {
            set
            {
                IsMoreExpanded = true;
                IdTextEdit.Value = value;
            }

            get
            {
                IsMoreExpanded = true;
                return IdTextEdit.Value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this part is archivable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if archivable; otherwise, <c>false</c>.
        /// </value>
        public bool Archivable
        {
            set
            {
                IsMoreExpanded = true;
                ArchivableCheckBox.Value = value;
            }

            get
            {
                IsMoreExpanded = true;
                return ArchivableCheckBox.Value;
            }
        }

        public void OpenCustomerAdministration()
        {
            CustomerOpenAdministrationButton.Click();
        }
    }
}
