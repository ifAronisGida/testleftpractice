using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects;

namespace TestLeft.TestLeftBase.PageObjects.Cut
{
    /// <summary>
    /// The Cut ProcessObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.ProcessObject" />
    public class TcCutApp : ProcessObject
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="TcCutApp" /> class.
        /// </summary>
        /// <param name="process">The Cut process.</param>
        public TcCutApp( IProcess process ) : base( process )
        {
        }
    }
}
