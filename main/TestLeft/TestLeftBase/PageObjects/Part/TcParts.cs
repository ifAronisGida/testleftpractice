using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using Trumpf.PageObjects.Waiting;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;
using PageObjectInterfaces.Part;

namespace TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// PageObject for the parts category.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcMainTabControl}" />
    public class TcParts : TcDomain, IChildOf<TcMainTabControl>, TiParts
    {
        /// <summary>
        /// Gets the detail overlay.
        /// </summary>
        /// <value>
        /// The detail overlay.
        /// </value>
        private TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );

        /// <summary>
        /// Gets the toolbar.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        public TiPartToolbar Toolbar => On<TcPartToolbar>( cache: true );

        /// <summary>
        /// Gets the single detail.
        /// </summary>
        /// <value>
        /// The single detail.
        /// </value>
        public TiPartSingleDetail SingleDetail => On<TcPartSingleDetail>( cache: true );

        /// <summary>
        /// Gets the single detail design.
        /// </summary>
        /// <value>
        /// The single detail design.
        /// </value>
        public TiPartSingleDetailDesign SingleDetailDesign => On<TcPartSingleDetailDesign>( cache: true );

        /// <summary>
        /// Gets the single detail bend solutions.
        /// </summary>
        /// <value>
        /// The single detail bend solutions.
        /// </value>
        public TiPartSingleDetailBendSolutions SingleDetailBendSolutions => On<TcPartSingleDetailBendSolutions>( cache: true );

        /// <summary>
        /// Gets the single detail cut solutions.
        /// </summary>
        /// <value>
        /// The single detail cut solutions.
        /// </value>
        public TiPartSingleDetailCutSolutions SingleDetailCutSolutions => On<TcPartSingleDetailCutSolutions>( cache: true );

        /// <summary>
        /// Goto the page object, i.e. perform necessary action to make the page object visible on screen, do nothing if the page is already visible on screen.
        /// </summary>
        public override void Goto()
        {
            if( Toolbar.IsVisible )
            {
                return;
            }

            base.Goto();
            Goto<TcDomains>().Part.Click();
        }

        /// <summary>
        /// Waits for detail overlay appear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitForDetailOverlayAppear( TimeSpan timeout )
        {
            return TryWait.For( () => DetailOverlay.VisibleOnScreen, timeout );
        }

        /// <summary>
        /// Waits for detail overlay disappear.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitForDetailOverlayDisappear( TimeSpan timeout )
        {
            return TryWait.For( () => !DetailOverlay.VisibleOnScreen, timeout );
        }

        /// <summary>
        /// Deletes the given part.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public bool DeletePart( string id )
        {
            if( !ResultColumn.SelectItem( id ) )
            {
                return false;
            }

            Toolbar.Delete();
            return true;
        }
    }
}
