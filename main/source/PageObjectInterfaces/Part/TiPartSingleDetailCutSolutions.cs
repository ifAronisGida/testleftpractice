namespace PageObjectInterfaces.Part
{
    public interface TiPartSingleDetailCutSolutions
    {
        /// <summary>
        /// Creates a new cut solution.
        /// </summary>
        void New();

        int Count { get; }

        void OpenCutSolution( string name );
    }
}
