using HomeZone.UiObjectInterfaces.Dialogs.ThirdPartyComponents;
using HomeZone.UiObjects.ControlObjects.Grid;

namespace HomeZone.UiObjects.PageObjects.Dialogs.ThirdPartyComponents
{
    public class Tc3rdPartyComponentRow : Ti3rdPartyComponentRow
    {
        private readonly TcOptimizedTableRow mRow;

        public Tc3rdPartyComponentRow( TcOptimizedTableRow row )
        {
            mRow = row;
        }

        //private IControlObject LicenseTextButton => mRow.Find<IControlObject>( Search.ByUid("HomeZoneLicenseTextButton"), depth: 3 );

        public string Component => mRow.GetContent( 0 );
        public string Version => mRow.GetContent( 1 );
        public string Author => mRow.GetContent( 2 );
        public string Wbsite => mRow.GetContent( 3 );
        public string Description => mRow.GetContent( 4 );
        public string LicenseType => mRow.GetContent( 5 );

        public void ShowLicenseText()
        {
            //LicenseTextButton.Click();
        }
    }
}
