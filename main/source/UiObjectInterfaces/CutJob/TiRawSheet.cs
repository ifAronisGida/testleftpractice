using HomeZone.UiObjectInterfaces.Controls;

namespace HomeZone.UiObjectInterfaces.CutJob
{
    public interface TiRawSheet
    {
        TiValueControl<int> Quantity { get; }
        TiValueControl<string> RawSheet { get; }

        void Delete();
    }
}
