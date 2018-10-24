namespace UiObjectInterfaces.CutJob
{
    public interface TiRawSheetList
    {
        int Count { get; }

        TiRawSheet GetRawSheet( int index );
    }
}
