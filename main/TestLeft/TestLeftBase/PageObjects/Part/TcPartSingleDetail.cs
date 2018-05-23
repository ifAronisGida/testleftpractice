using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TcTruIconButton = TestLeft.TestLeftBase.ControlObjects.TcTruIconButton;


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

        private TcTextEdit NameTextEdit => Find<TcTextEdit>( Search.ByUid( "Part.Detail.Base.Description" ) );
        private TcLookUpEdit CustomerLookUpEdit => Find<TcLookUpEdit>( Search.ByUid( "EditCustomerProperty.EditValue" ) );
        internal TcTruIconButton CustomerOpenAdministrationButton => Find<TcTruIconButton>( Search.ByUid( "EditCustomerProperty.OpenAdministration" ) );
        private TcTextEdit DrawingNumberTextEdit => Find<TcTextEdit>( Search.ByUid( "Part.Detail.Base.DrawingNumber" ) );
        private TcTextEdit DrawingVersionTextEdit => Find<TcTextEdit>( Search.ByUid( "Part.Detail.Base.DrawingVersion" ) );
        private TcGroupPanel DetailGroupPanel => Find<TcGroupPanel>( Search.ByUid( "Part.Detail.Base" ) );
        private TcTextEdit IdTextEdit => Find<TcTextEdit>( Search.ByUid( "Part.Detail.Base.Name" ) );
        private TcTextEdit ExternalNameTextEdit => Find<TcTextEdit>( Search.ByUid( "Part.Detail.Base.More.ExternalName" ) );
        private TcCheckBox ArchivableCheckBox => Find<TcCheckBox>( Search.ByUid( "Part.Detail.Archivable" ) );
        private TcTextEdit NoteTextEdit => Find<TcTextEdit>( Search.ByUid( "Part.Detail.Base.More.Note" ) );

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            set
            {
                NameTextEdit.Text = value;
            }

            get
            {
                return NameTextEdit.Text;
            }
        }

        /// <summary>
        /// Waits for name TextBox enabled.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        public void WaitForNameEnabled( TimeSpan timeout )
        {
            Wait.For( () => NameTextEdit.Enabled, timeout );
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
            set
            {
                CustomerLookUpEdit.Text = value;
            }

            get
            {
                return CustomerLookUpEdit.Text;
            }
        }

        /// <summary>
        /// Gets or sets the drawing number.
        /// </summary>
        /// <value>
        /// The drawing number.
        /// </value>
        public string DrawingNumber
        {
            set
            {
                DrawingNumberTextEdit.Text = value;
            }

            get
            {
                return DrawingNumberTextEdit.Text;
            }
        }

        /// <summary>
        /// Gets or sets the drawing version.
        /// </summary>
        /// <value>
        /// The drawing version.
        /// </value>
        public string DrawingVersion
        {
            set
            {
                DrawingVersionTextEdit.Text = value;
            }

            get
            {
                return DrawingVersionTextEdit.Text;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the more area is expanded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if more is expanded; otherwise, <c>false</c>.
        /// </value>
        public bool IsMoreExpanded
        {
            set { DetailGroupPanel.IsMoreExpanded = value; }

            get { return DetailGroupPanel.IsMoreExpanded; }
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
                IdTextEdit.Text = value;
            }

            get
            {
                IsMoreExpanded = true;
                return IdTextEdit.Text;
            }
        }

        /// <summary>
        /// Gets or sets the external name.
        /// </summary>
        /// <value>
        /// The external name.
        /// </value>
        public string ExternalName
        {
            set
            {
                IsMoreExpanded = true;
                ExternalNameTextEdit.Text = value;
            }

            get
            {
                IsMoreExpanded = true;
                return ExternalNameTextEdit.Text;
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
                ArchivableCheckBox.Checked = value;
            }

            get
            {
                IsMoreExpanded = true;
                return ArchivableCheckBox.Checked;
            }
        }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        public string Note
        {
            set
            {
                IsMoreExpanded = true;
                NoteTextEdit.Text = value;
            }

            get
            {
                IsMoreExpanded = true;
                return NoteTextEdit.Text;
            }
        }
    }
}
