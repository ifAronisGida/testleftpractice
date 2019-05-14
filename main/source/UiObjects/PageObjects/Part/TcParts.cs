using System;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.PageObjects.Shell;

namespace HomeZone.UiObjects.PageObjects.Part
{
    /// <summary>
    /// PageObject for the parts category.
    /// </summary>
    /// <seealso cref="IChildOf{T}" />
    public class TcParts : TcDomain<TiPartToolbar>, IChildOf<TcMainTabControl>, TiParts
    {
        /// <summary>
        /// Gets the toolbar.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        public override TiPartToolbar Toolbar => On<TcPartToolbar>( cache: true );

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
        public TiPartSingleDetailDesign SingleDetailDesign => On<TcPartSingleDetailDesign>(true);

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

        protected override TimeSpan DefaultOverlayAppearTimeout => TcPageObjectSettings.Instance.PartOverlayAppearTimeout;
        protected override TimeSpan DefaultOverlayDisappearTimeout => TcPageObjectSettings.Instance.PartOverlayDisappearTimeout;

        /// <summary>
        /// Deletes the given part. The part should not be used in part orders or nestings.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public bool DeletePart( string id )
        {
            if( !ResultColumn.SelectItem( id ) )
            {
                ResultColumn.ClearSearch();
                return false;
            }

            Toolbar.Delete();
            ResultColumn.ClearSearch();
            return true;
        }

        protected override void DoGoto()
        {
            Goto<TcDomains>().Part.Click();
        }
    }
}
