using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects
{
    public abstract class TcPageObjectBase : PageObject
    {
        /// <summary>
        /// Finds the specified uid.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <param name="uid">The uid.</param>
        /// <returns></returns>
        public TInterface Find<TInterface>( string uid ) where TInterface : class
        {
            return TcControlMapper.Map<TInterface>( this.FindGeneric( Search.ByUid( uid ) ) );
        }

        /// <summary>
        /// Waits until PageObject is visible.
        /// </summary>
        /// <returns>true if visible</returns>
        public bool WaitUntilVisible()
        {
            return VisibleOnScreen.TryWaitFor();
        }
    }
}
