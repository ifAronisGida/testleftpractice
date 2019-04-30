using HomeZone.UiObjectInterfaces.Controls;

namespace HomeZone.UiObjectInterfaces.Part
{
    public interface TiPartSingleDetailDesign
    {
        /// <summary>
        /// Opens the design.
        /// </summary>
        void Open();

        /// <summary>
        /// Imports the specified design from the given filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        bool Import( string filename );

        void Boost();

        void Delete();

        TiValueControl<string> Material { get; }
        TiValueControl<string> RawMaterial { get; }
        TiValueControl<string> Unfolding { get; }
        TiValueControl<string> PermittedNestingOrientations { get; }

        bool RotateToGrainDirection { get; set; }
    }
}
