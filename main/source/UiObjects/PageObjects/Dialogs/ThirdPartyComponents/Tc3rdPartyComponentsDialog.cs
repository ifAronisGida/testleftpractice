using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.Dialogs.ThirdPartyComponents;
using HomeZone.UiObjects.ControlObjects;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.Dialogs.ThirdPartyComponents
{
    public class Tc3rdPartyComponentsDialog : TcPageObjectBase, IChildOf<TcHomeZoneApp>, Ti3rdPartyComponentsDialog
    {
        protected override Search SearchPattern => Search.ByUid( "Tc3rdPartyComponents" );

        private TcButton LicenseTextButton => Find<TcButton>( "HomeZoneLicenseTextButton", depth: 20 );

        //internal readonly Lazy<TcOptimizedTableView<Tc3rdPartyComponentRow>> mHomeZoneTableView;

        private TcGridControl HomeZoneGrid => Find<TcGridControl>( Search.ByUid( "HomeZoneLicenseGrid" ), depth: 4 );

        private TiButton OkButton => Find<TiButton>( "OkButton" );

        //public Tc3rdPartyComponentsDialog()
        //{
        //    mHomeZoneTableView = new Lazy<TcOptimizedTableView<Tc3rdPartyComponentRow>>( () => HomeZoneGrid.GetOptimizedTableView( underlyingRow => new Tc3rdPartyComponentRow( underlyingRow ) ) );
        //}

        public int HomeZoneLicenseCount => HomeZoneGrid.RowCount;

        //public Ti3rdPartyComponentRow GetHomeZoneLicenseRow( int row )
        //{
        //    return mHomeZoneTableView.Value.GetRow( row );
        //}

        public Ti3rdPartyComponentLicenseTextDialog ShowLicenseText()
        {
            LicenseTextButton.Click();
            return On<Tc3rdPartyComponentLicenseTextDialog>();
        }

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        public void Close()
        {
            OkButton.Click();
        }
    }
}
