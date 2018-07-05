namespace TestLeft.TestLeftBase.ControlObjects.Grid
{
    public interface TiTableRowFactory<T>
    {
        T WrapRow(TcTableRow underlyingRow);
    }
}
