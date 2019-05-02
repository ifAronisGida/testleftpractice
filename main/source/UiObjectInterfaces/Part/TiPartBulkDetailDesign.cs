using HomeZone.UiObjectInterfaces.Controls;

namespace HomeZone.UiObjectInterfaces.Part
{
     public interface TiPartBulkDetailDesign
    {
        void Boost();

        TiValueControl<string> Material { get; }
        TiValueControl<string> RawMaterial { get; }
        TiValueControl<string> Unfolding { get; }
        TiValueControl<string> PermittedNestingOrientations { get; }

        bool RotateToGrainDirection { get; set; }
    }
}
