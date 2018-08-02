using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects;

namespace TestLeft.TestLeftBase.PageObjects.Design
{
    /// <summary>
    /// The Design ProcessObject.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.ProcessObject" />
    public class TcDesignApp : ProcessObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:TestLeft.TestLeftBase.PageObjects.Design.TcDesignApp" /> class.
        /// </summary>
        /// <param name="process">The Design process.</param>
        /// <inheritdoc />
        public TcDesignApp( IProcess process ) : base( process )
        {
        }
    }
}
