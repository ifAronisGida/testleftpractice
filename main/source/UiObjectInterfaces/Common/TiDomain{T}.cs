namespace HomeZone.UiObjectInterfaces.Common
{
    public interface TiDomain<TToolbar> : TiDomain where TToolbar : TiToolbar
    {
        new TToolbar Toolbar { get; }
    }
}
