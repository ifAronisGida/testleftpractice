using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.Part
{
    public interface TiPartToolbar : TiToolbar
    {
        bool CanBoost { get; }

        /// <summary>
        /// Creates a new part.
        /// </summary>
        void New();

        /// <summary>
        /// Imports the specified part from the given filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>true if successful; otherwise false</returns>
        bool Import( string filename );

        /// <summary>
        /// Boosts the part via toolbar.
        /// </summary>
        void Boost();

        /// <summary>
        /// Creates the part order.
        /// </summary>
        void CreatePartOrder();

        /// <summary>
        /// Creates the cut job.
        /// </summary>
        void CreateCutJob();
    }
}
