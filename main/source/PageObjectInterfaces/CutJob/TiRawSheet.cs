using PageObjectInterfaces.Controls;

namespace PageObjectInterfaces.CutJob
{
    public interface TiRawSheet
    {
        TiValueControl<int> Quantity { get; }
        TiValueControl<string> RawSheet { get; }

        void Delete();
    }
}
