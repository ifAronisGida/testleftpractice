namespace HomeZone.UiObjectInterfaces.Dialogs.ThirdPartyComponents
{
    public interface Ti3rdPartyComponentRow
    {
        string Component { get; }

        string Version { get; }
        string Author { get; }
        string Wbsite { get; }
        string Description { get; }
        string LicenseType { get; }

        void ShowLicenseText();
    }
}
