using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Dialogs;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.Shell;
using Trumpf.TruTops.Control.TestLeft.TestLeftBase.Settings;
using TcTruIconButton = Trumpf.TruTops.Control.TestLeft.TestLeftBase.ControlObjects.TcTruIconButton;


namespace Trumpf.TruTops.Control.TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobSolution : PageObject, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail.JobSolution" );

        internal TcTruIconButton ReleaseButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.Release" ) );

        internal TcTruIconButton OpenButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.Open" ) );

        internal TcTruIconButton DeleteButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.Delete" ) );

        internal TcComboBox MachineCombo => Find<TcComboBox>( Search.ByUid( "CutJob.Detail.JobSolution.Machine" ) );//ComboBoxEdit

        internal TcLookUpEdit TechnoProfile => Find<TcLookUpEdit>( Search.ByUid( "CutJob.Detail.JobSolution.TechnologyProfile" ) );

        //internal ToggleButton technoProfileFavotite => Find<ToggleButton>( Search.ByUid( "CutJob.Detail.JobSolution.TechnologyProfileFavorite" ) );
        //internal SpinEdit MaxQuantity => Find<SpinEdit>( Search.ByUid( "CutJob.Detail.JobSolution.MaxQuantity" ) );

        internal TcTruIconButton RemovePresetRawSheetButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.RemovePresetRawSheet" ) );

        internal TcTruIconButton AddPresetRawSheetButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.AddPresetRawSheet" ) );

        internal TcLookUpEdit NestingModeEdit => Find<TcLookUpEdit>( Search.ByUid( "CutJob.Detail.JobSolution.NestingMode" ) );

        internal TcLookUpEdit LaserTechnologyTableEdit => Find<TcLookUpEdit>( Search.ByUid( "CutJob.Detail.JobSolution.LaserTechnologyTable" ) );

        internal TcLookUpEdit LaserProcessRule => Find<TcLookUpEdit>( Search.ByUid( "CutJob.Detail.JobSolution.LaserProcessRule" ) );

        //internal ToggleButton laserTechnologyRuleSetCombinationFavorite => Find<ToggleButton>( Search.ByUid( "CutJob.Detail.JobSolution.SetLaserTechnologyRuleSetCombinationFavorite" ) );

        internal TcTextEdit NoteTextEdit => Find<TcTextEdit>( Search.ByUid( "CutJob.Detail.JobSolution.Comment" ) );

        //internal TcTextBlock dateOfLastChange => Find<TcTextBlock>( Search.ByUid( "CutJob.Detail.JobSolution.DateOfLastChange" ) );

        //internal TcTextBlock totalWasteInPercent => Find<TcTextBlock>( Search.ByUid( "CutJob.Detail.JobSolution.TotalWasteInPercent" ) );

        //internal TcTextBlock targetProcessingTime => Find<TcTextBlock>( Search.ByUid( "CutJob.Detail.JobSolution.TargetProcessingTime" ) );

        internal TcTruIconButton OpenSetupPlanButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.OpenSetupPlan" ) );

        internal TcTruIconButton OpenReleaseFolderButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.OpenReleaseFolder" ) );

        internal TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );

        internal TcTruIconButton BoostButton => Find<TcTruIconButton>( Search.ByUid( "Part.Detail.JobSolution.ButtonBar.Calculate" ) );

        internal TcComboBox RawSheetComboBox => Find<TcComboBox>( Search.ByControlName( "rawsheetComboBox" ) );


        public string Note
        {
            set { NoteTextEdit.Text = value; }
            get { return NoteTextEdit.Text; }
        }

        public void SelectMachine(int index)
        {
            MachineCombo.ClickItem(index);
        }

        public void SelectRawSheet( int index )
        {
            RawSheetComboBox.ClickItem( index );
        }

        public void Delete()
        {
            if (DeleteButton.Enabled)
            {
                DeleteButton.Click();

                var dialog = On<TcMessageBox>();
                if (dialog.MessageBoxExists())
                {
                    dialog.Yes();
                }
            }
        }

        public void Boost()
        {
            if ( BoostButton.Enabled)
            {
                BoostButton.Click();

                WaitForDetailOverlayAppear(TcSettings.SavingTimeout);
                WaitForDetailOverlayDisappear(TcSettings.SavingTimeout);
            }
        }

        public bool WaitForDetailOverlayAppear( TimeSpan timeout )
        {
            return TryWait.For( () => DetailOverlay.VisibleOnScreen, timeout );
        }

        public bool WaitForDetailOverlayDisappear( TimeSpan timeout )
        {
            return TryWait.For( () => !DetailOverlay.VisibleOnScreen, timeout );
        }

    }
}
