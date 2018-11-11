using System;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjects.Utilities;

namespace UiObjects.PageObjects
{
    public abstract class TcPageObjectBase : PageObject
    {
        /// <summary>
        /// Finds the specified uid.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <param name="uid">The uid.</param>
        /// <param name="predicate"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public TInterface Find<TInterface>( string uid, Predicate<IControl> predicate = null, int? depth = null ) where TInterface : class
        {
            return TcControlMapper.Map<TInterface>( this.FindGeneric( Search.ByUid( uid ), predicate, depth ) );
        }

        public TInterface FindByControlName<TInterface>( string controlName ) where TInterface : class
        {
            return TcControlMapper.Map<TInterface>( this.FindGeneric( Search.ByControlName( controlName ) ) );
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
        /// PageObject is visible or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisible => VisibleOnScreen.Value;
    }
}
