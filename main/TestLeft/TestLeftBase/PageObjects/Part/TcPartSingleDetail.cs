using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TcTruIconButton = TestLeft.TestLeftBase.ControlObjects.TcTruIconButton;
using TestLeft.TestLeftBase.Utilities;

namespace TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// The upper detail area of the part category.
    /// </summary>
    /// <seealso cref="PageObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcDetailContent}" />
    public class TcPartSingleDetail : PageObject, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "Part.Details" );

        public TiValueControl<string> Name => this.FindGeneric<TiValueControl<string>>( "Part.Detail.Base.Description" );
        private TcLookUpEdit CustomerLookUpEdit => this.FindGeneric<TcLookUpEdit>( "EditCustomerProperty.EditValue" );
        internal TcTruIconButton CustomerOpenAdministrationButton => Find<TcTruIconButton>( Search.ByUid( "EditCustomerProperty.OpenAdministration" ) );
        public TiValueControl<string> DrawingNumber => this.FindGeneric<TiValueControl<string>>( "Part.Detail.Base.DrawingNumber" );
        public TiValueControl<string> DrawingVersion => this.FindGeneric<TiValueControl<string>>( "Part.Detail.Base.DrawingVersion" );
        private TcGroupPanel DetailGroupPanel => Find<TcGroupPanel>( Search.ByUid( "Part.Detail.Base" ) );
        public TiValueControl<string> IdTextEdit => this.FindGeneric<TiValueControl<string>>( "Part.Detail.Base.Name" );
        public TiValueControl<string> ExternalName => this.FindGeneric<TiValueControl<string>>( "Part.Detail.Base.More.ExternalName" );
        private TiValueControl<bool> ArchivableCheckBox => this.FindGeneric<TiValueControl<bool>>( "Part.Detail.Archivable" );
        public TiValueControl<string> Note => this.FindGeneric<TiValueControl<string>>( "Part.Detail.Base.More.Note" );

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
            set => CustomerLookUpEdit.Text = value;

            get => CustomerLookUpEdit.Text;
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
    }
}
