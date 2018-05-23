using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using Trumpf.PageObjects.Waiting;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Dialogs;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Shell;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Common;

namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// PageObject for the parts category.
    /// </summary>
    /// <seealso cref="RepeaterObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcMainTabControl}" />
    public class TcParts : RepeaterObject, IChildOf<TcMainTabControl>
    {
        private TcPartToolbar mToolbar;
        private TcResultColumn mResultColumn;
        private TcPartSingleDetail mSingleDetail;
        private TcPartSingleDetailDesign mSingleDetailDesign;
        private TcPartSingleDetailBendSolutions mSingleDetailBendSolutions;
        private TcPartSingleDetailCutSolutions mSingleDetailCutSolutions;

        /// <summary>
        /// Gets the detail overlay.
        /// </summary>
        /// <value>
        /// The detail overlay.
        /// </value>
        public TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );

        /// <summary>
        /// Gets the toolbar.
        /// </summary>
        /// <value>
        /// The toolbar.
        /// </value>
        public TcPartToolbar Toolbar
        {
            get
            {
                if( mToolbar == null )
                {
                    mToolbar = On<TcPartToolbar>();
                }

                return mToolbar;
            }
        }

        /// <summary>
        /// Gets the result column.
        /// </summary>
        /// <value>
        /// The result column.
        /// </value>
        public TcResultColumn ResultColumn
        {
            get
            {
                if( mResultColumn == null )
                {
                    mResultColumn = On<TcResultColumn>();
                }

                return mResultColumn;
            }
        }

        /// <summary>
        /// Gets the single detail.
        /// </summary>
        /// <value>
        /// The single detail.
        /// </value>
        public TcPartSingleDetail SingleDetail
        {
            get
            {
                if( mSingleDetail == null )
                {
                    mSingleDetail = On<TcPartSingleDetail>();
                }

                return mSingleDetail;
            }
        }

        /// <summary>
        /// Gets the single detail design.
        /// </summary>
        /// <value>
        /// The single detail design.
        /// </value>
        public TcPartSingleDetailDesign SingleDetailDesign
        {
            get
            {
                if( mSingleDetailDesign == null )
                {
                    mSingleDetailDesign = On<TcPartSingleDetailDesign>();
                }

                return mSingleDetailDesign;
            }
        }

        /// <summary>
        /// Gets the single detail bend solutions.
        /// </summary>
        /// <value>
        /// The single detail bend solutions.
        /// </value>
        public TcPartSingleDetailBendSolutions SingleDetailBendSolutions
        {
            get
            {
                if( mSingleDetailBendSolutions == null )
                {
                    mSingleDetailBendSolutions = On<TcPartSingleDetailBendSolutions>();
                }

                return mSingleDetailBendSolutions;
            }
        }

        /// <summary>
        /// Gets the single detail cut solutions.
        /// </summary>
        /// <value>
        /// The single detail cut solutions.
        /// </value>
        public TcPartSingleDetailCutSolutions SingleDetailCutSolutions
        {
            get
            {
                if( mSingleDetailCutSolutions == null )
                {
                    mSingleDetailCutSolutions = On<TcPartSingleDetailCutSolutions>();
                }

                return mSingleDetailCutSolutions;
            }
        }

        /// <summary>
        /// Goto the page object, i.e. perform necessary action to make the page object visible on screen, do nothing if the page is already visible on screen.
        /// </summary>
        public override void Goto()
        {
            base.Goto();
            Goto<TcDomains>().Part.Click();
            VisibleOnScreen.WaitFor();
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
        /// Creates a new part.
        /// </summary>
        public void NewPart()
        {
            Toolbar.NewPartButton.Click();
        }

        /// <summary>
        /// Imports the specified part from the given filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>true if successful; otherwise false</returns>
        public bool Import( string filename )
        {
            Toolbar.ImportButton.Click();

            var openDlg = On<TcOpenFileDialog>();
            return openDlg.SetFilename( filename );
        }

        /// <summary>
        /// Boosts the part via toolbar.
        /// </summary>
        public void BoostPart()
        {
            Toolbar.BoostButton.Click();
        }

        /// <summary>
        /// Saves the part.
        /// </summary>
        public void SavePart()
        {
            Toolbar.SaveButton.Click();
        }

        /// <summary>
        /// Deletes the part.
        /// </summary>
        public void DeletePart()
        {
            Toolbar.DeleteButton.Click();

            var dialog = On<TcMessageBox>();
            if( dialog.MessageBoxExists() )
            {
                dialog.Yes();
            }
        }

        /// <summary>
        /// Selects the part via identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void SelectPart( string id )
        {
            ResultColumn.SelectItem( id );
        }

        /// <summary>
        /// Selects the parts containing the given search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <returns>The amount of selected parts.</returns>
        public int SelectParts( string searchText )
        {
            return ResultColumn.SelectItems( searchText );
        }

        /// <summary>
        /// Selects all parts.
        /// </summary>
        /// <returns>The amount of selected parts.</returns>
        public int SelectAll()
        {
            return ResultColumn.SelectAll();
        }

        public void CreatePartOrder()
        {
            Toolbar.CreatePartOrderButton.Click();
        }

        public void CreateCutJob()
        {
            Toolbar.CreateCutJobButton.Click();
        }
    }
}
