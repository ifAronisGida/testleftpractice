using Trumpf.PageObjects;

namespace TestLeft.TestLeftBase
{
    /// <summary>
    /// The HomeZone ProcessObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.ProcessObject" />
    public class TcHomeZoneApp : ProcessObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TcHomeZoneApp"/> class.
        /// </summary>
        /// <param name="processname">The name of the HomeZone process.</param>
        public TcHomeZoneApp( string processname ) : base( processname )
        {
        }

        public TInterface Goto<TInterface, TPageObject>() where TInterface : class where TPageObject : class, IPageObject
        {
            return Goto<TPageObject>() as TInterface;
        }
    }
}
