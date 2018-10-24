using UiObjectInterfaces.Common;


namespace UiObjectInterfaces.Part
{
    public interface TiPartToolbar : TiVisibility
    {
        bool CanSave { get; }
        bool CanDelete { get; }
        bool CanRevert { get; }
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
        /// Saves the part.
        /// </summary>
        void Save();

        /// <summary>
        /// Deletes the part.
        /// </summary>
        void Delete();

        /// <summary>
        /// Reverts a part.
        /// </summary>
        void Revert();

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
