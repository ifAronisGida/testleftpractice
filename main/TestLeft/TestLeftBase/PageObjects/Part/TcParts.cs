﻿using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using Trumpf.PageObjects.Waiting;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.PageObjects.Common;

namespace TestLeft.TestLeftBase.PageObjects.Part
{
    /// <summary>
    /// PageObject for the parts category.
    /// </summary>
    /// <seealso cref="RepeaterObject" />
    /// <seealso cref="Trumpf.PageObjects.IChildOf{TcMainTabControl}" />
    public class TcParts : RepeaterObject, IChildOf<TcMainTabControl>
    {
        private readonly Lazy<TcPartToolbar> mToolbar;
        private readonly Lazy<TcResultColumn> mResultColumn;

        private readonly Lazy<TcPartSingleDetail> mSingleDetail;
        private readonly Lazy<TcPartSingleDetailDesign> mSingleDetailDesign;
        private readonly Lazy<TcPartSingleDetailBendSolutions> mSingleDetailBendSolutions;
        private readonly Lazy<TcPartSingleDetailCutSolutions> mSingleDetailCutSolutions;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcParts"/> class.
        /// </summary>
        public TcParts()
        {
            mToolbar = new Lazy<TcPartToolbar>( () => On<TcPartToolbar>() );
            mResultColumn = new Lazy<TcResultColumn>( () => On<TcResultColumn>() );
            mSingleDetail = new Lazy<TcPartSingleDetail>( () => On<TcPartSingleDetail>() );
            mSingleDetailDesign = new Lazy<TcPartSingleDetailDesign>( () => On<TcPartSingleDetailDesign>() );
            mSingleDetailBendSolutions = new Lazy<TcPartSingleDetailBendSolutions>( () => On<TcPartSingleDetailBendSolutions>() );
            mSingleDetailCutSolutions = new Lazy<TcPartSingleDetailCutSolutions>( () => On<TcPartSingleDetailCutSolutions>() );
        }

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
        public TcPartToolbar Toolbar => mToolbar.Value;

        /// <summary>
        /// Gets the result column.
        /// </summary>
        /// <value>
        /// The result column.
        /// </value>
        public TcResultColumn ResultColumn => mResultColumn.Value;

        /// <summary>
        /// Gets the single detail.
        /// </summary>
        /// <value>
        /// The single detail.
        /// </value>
        public TcPartSingleDetail SingleDetail => mSingleDetail.Value;

        /// <summary>
        /// Gets the single detail design.
        /// </summary>
        /// <value>
        /// The single detail design.
        /// </value>
        public TcPartSingleDetailDesign SingleDetailDesign => mSingleDetailDesign.Value;

        /// <summary>
        /// Gets the single detail bend solutions.
        /// </summary>
        /// <value>
        /// The single detail bend solutions.
        /// </value>
        public TcPartSingleDetailBendSolutions SingleDetailBendSolutions => mSingleDetailBendSolutions.Value;

        /// <summary>
        /// Gets the single detail cut solutions.
        /// </summary>
        /// <value>
        /// The single detail cut solutions.
        /// </value>
        public TcPartSingleDetailCutSolutions SingleDetailCutSolutions => mSingleDetailCutSolutions.Value;

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

            var dialog = On<TcPartComputeAllConfirmation>();
            if( dialog.DialogBoxExists() )
            {
                dialog.Ok();
            }
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
