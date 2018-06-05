using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects;

namespace TestLeft.TestLeftBase.PageObjects.Flux
{
    /// <summary>
    /// The Flux ProcessObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.ProcessObject" />
    public class TcFluxApp : ProcessObject
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:TestLeft.TestLeftBase.PageObjects.Flux.TcFluxApp" /> class.
        /// </summary>
        /// <param name="process">The Flux process.</param>
        public TcFluxApp(IProcess process) : base(process)
        {
        }
    }
}
