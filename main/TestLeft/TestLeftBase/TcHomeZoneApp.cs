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

        /// <summary>
        /// Goto the page object. If the current page object cannot directly navigate to
        /// the target, it may forward it to its child page objects. Throws if the page object
        /// cannot be navigated to.
        /// </summary>
        /// <typeparam name="TInterface">The interface of the target page object.</typeparam>
        /// <typeparam name="TPageObject">The target page object type.</typeparam>
        /// <returns>Interface of the target page object</returns>
        public TInterface Goto<TInterface, TPageObject>() where TInterface : class where TPageObject : class, IPageObject
        {
            return Goto<TPageObject>() as TInterface;
        }

        /// <summary>
        /// Gets the interface of the PageObject.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TPageObject">The type of the page object.</typeparam>
        /// <returns>Interface of the target page object</returns>
        public TInterface On<TInterface, TPageObject>() where TInterface : class where TPageObject : class, IPageObject
        {
            return On<TPageObject>() as TInterface;
        }
    }
}
