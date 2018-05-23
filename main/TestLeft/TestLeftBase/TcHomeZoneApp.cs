using Trumpf.PageObjects;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase
{
    /// <summary>
    /// The HomeZone ProcessObject.
    /// </summary>
    public class TcHomeZoneApp : ProcessObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TcHomeZoneApp"/> class.
        /// </summary>
        /// <param name="processname">The name of the HomeZone process.</param>
        public TcHomeZoneApp( string processname ) : base( processname )
        {
        }
    }
}
