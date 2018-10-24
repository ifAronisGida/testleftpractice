using UiObjectInterfaces.Controls;


namespace UiObjectInterfaces.CutJob
{
    public interface TiRawSheet
    {
        TiValueControl<int> Quantity { get; }
        TiValueControl<string> RawSheet { get; }

        void Delete();
    }
}
