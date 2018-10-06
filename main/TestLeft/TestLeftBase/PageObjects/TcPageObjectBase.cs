using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects;
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
        /// Returns the interface of the given PageObject.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TPageObject">The type of the page object.</typeparam>
        /// <returns>The interface of the given PageObject</returns>
        public TInterface On<TInterface, TPageObject>() where TInterface : class where TPageObject : class, IPageObject
        {
            return On<TPageObject>() as TInterface;
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
