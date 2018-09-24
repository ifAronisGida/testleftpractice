using System;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.Settings;
using TestLeft.TestLeftBase.Utilities;
using TestLeft.TestLeftBase.ControlObjects;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobSolution : PageObjectBase, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail.JobSolution" );

        //private TcComboBox MachineCombo => Find<TcComboBox>( Search.ByUid( "CutJob.Detail.JobSolution.Machine" ) );
        //private TcLookUpEdit TechnoProfile => this.FindGeneric<TcLookUpEdit>( "CutJob.Detail.JobSolution.TechnologyProfile" );
        //private TcTruIconButton AddPresetRawSheetButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.AddPresetRawSheet" ) );
        //private TcLookUpEdit NestingModeEdit => this.FindGeneric<TcLookUpEdit>( "CutJob.Detail.JobSolution.NestingMode" );
        //private TcLookUpEdit LaserTechnologyTableEdit => this.FindGeneric<TcLookUpEdit>( "CutJob.Detail.JobSolution.LaserTechnologyTable" );
        //private TcLookUpEdit LaserProcessRule => this.FindGeneric<TcLookUpEdit>( "CutJob.Detail.JobSolution.LaserProcessRule" );
        //private TcTruIconButton OpenSetupPlanButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.OpenSetupPlan" ) );
        //private TcTruIconButton OpenReleaseFolderButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.OpenReleaseFolder" ) );

        public TiValueControl<string> Note => this.FindGeneric<TiValueControl<string>>( "CutJob.Detail.JobSolution.Comment" );
        public TcRawSheetList RawSheets => Find<TcRawSheetList>();

        private TiButton AddPresetRawSheetButton => Find<TiButton>( "CutJob.Detail.JobSolution.AddPresetRawSheet" );
        private TiButton DeleteButton => Find<TiButton>( "CutJob.Detail.JobSolution.Delete" );
        private TiButton BoostButton => Find<TiButton>( "Part.Detail.JobSolution.ButtonBar.Calculate" );
        private TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );

        public void DeleteProgram()
        {
            var deleteBtn = DeleteButton;

            if( deleteBtn.Enabled )
            {
                deleteBtn.Click();

                var dialog = On<TcMessageBox>();
                if( dialog.MessageBoxExists() )
                {
                    dialog.Yes();
                }
            }
        }

        public void Boost()
        {
            if( BoostButton.Enabled )
            {
                BoostButton.Click();

                WaitForDetailOverlayAppear( TcSettings.SavingTimeout );
                WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );
            }
        }

        public TcRawSheet AddRawSheet()
        {
            AddPresetRawSheetButton.Click();

            return RawSheets.GetRawSheet( RawSheets.Count - 1 );
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
